using Mirror;
using Multiplayer;
using UnityEngine;

namespace Gameplay.Entities.Player
{
    public class PlayerWinPopup : NetworkBehaviour
    {
        [SerializeField] private WinPopup _winPopup;
        private bool _popupShown = false;


        [TargetRpc]
        public void TRpcSetPopupShownFalse()
        {
            
           CmdSetPSF();
        }

        [ClientRpc]
        private void RpcSetPSF()
        {
            _popupShown = false;
        }

        [Command]
        private void CmdSetPSF()
        {
            RpcSetPSF();
        }
        
        [TargetRpc]
        public void TRpcShow()
        {
            if (isLocalPlayer)
            {
                CmdShow();
            }

            if (isServer)
            {
                RpcShow();
            }
        }

        [ClientRpc]
        private void RpcShow()
        {
            Debug.Log("ShowWinner");
            if (_winPopup != null && !_popupShown)
            {
                _popupShown = true;
                _winPopup.ShowWinner(gameObject.GetComponent<NetworkIdentity>().netId.ToString());
            }
            
        }

        [Command]
        private void CmdShow()
        {
            RpcShow();
        }
        
        [ClientRpc]
        public void Hide()
        {
            _winPopup.Hide();
        }
    }
}
