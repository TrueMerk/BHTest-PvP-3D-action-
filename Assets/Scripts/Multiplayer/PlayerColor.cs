using System.Collections;
using Mirror;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Multiplayer
{
    public class PlayerColor : NetworkBehaviour
    {
        [SerializeField] private MeshRenderer _mesh;
        [SyncVar(hook = nameof(OnColorChanged))] public Color color;
        public Color startColor;
        [SerializeField] private int _colorChangeTime;

        private bool _isReload;
        
        
        private void OnColorChanged(Color newColor, Color oldColor)
        {
            GetComponent<MeshRenderer>().material.color = newColor;
            if (!_isReload)
            {
                StartCoroutine(Reload());
            }
            
            Debug.Log($"Color changed from{newColor}to{oldColor}");
        }


        public void ChangeColor(Color newColor)
        {
            if (isServer)
            {
                color = newColor;
                RpcChangeColor(color);
            }
            
            CMDChangeColor(newColor);

        }

        [Command]
        private void CMDChangeColor(Color newColor)
        {
            color = newColor;
        }

        [ClientRpc]
        private void RpcChangeColor(Color newColor)
        {
            GetComponent<MeshRenderer>().material.color = newColor;
        }

        
        private IEnumerator Reload()
        {
            _isReload = true;
                
            yield return new WaitForSeconds(_colorChangeTime);
            ChangeColor(Color.white);
            _isReload = false;
        }
    }
}
