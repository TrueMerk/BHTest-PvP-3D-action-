using System.Collections;
using Mirror;
using UnityEngine;

namespace Multiplayer
{
    public class PlayerColor : NetworkBehaviour
    {
        [SerializeField] private int _colorChangeTime;
        
        private bool _isReload;
        
        [SyncVar(hook = nameof(OnColorChanged))] public Color color;

        private void OnEnable()
        {
            ChangeColor(Color.white);
        }

        private void OnColorChanged(Color newColor, Color oldColor)
        {
            GetComponent<MeshRenderer>().material.color = newColor;
            if (!_isReload)
            {
                StartCoroutine(Reload());
            }
        }

        public void ChangeColor(Color newColor)
        {
            if (isServer)
            {
                color = newColor;
                RpcChangeColor(color);
            }
            
            if (isClient)
            {
                CmdChangeColor(newColor);
            }
        }

        [Command]
        private void CmdChangeColor(Color newColor)
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
