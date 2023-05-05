using Mirror.Core;
using UnityEngine;

namespace Mirror.Examples.AdditiveLevels.Scripts
{
    public class RandomColor : NetworkBehaviour
    {
        // Color32 packs to 4 bytes
        [SyncVar(hook = nameof(SetColor))]
        public Color32 color = Color.black;

        // Unity clones the material when GetComponent<Renderer>().material is called
        // Cache it here and destroy it in OnDestroy to prevent a memory leak
        private Material cachedMaterial;

        private void SetColor(Color32 _, Color32 newColor)
        {
            if (cachedMaterial == null) cachedMaterial = GetComponentInChildren<Renderer>().material;
            cachedMaterial.color = newColor;
        }

        private void OnDestroy()
        {
            Destroy(cachedMaterial);
        }

        public override void OnStartServer()
        {
            base.OnStartServer();

            // This script is on players that are respawned repeatedly
            // so once the color has been set, don't change it.
            if (color == Color.black)
                color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        }
    }
}
