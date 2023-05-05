using Mirror;
using Multiplayer;
using UnityEngine;

namespace Gameplay.Entities.Player
{
    public class PlayerWinPopup : NetworkBehaviour
    {
        [SerializeField] private WinPopup _winPopup;
        
        public void Show()
        {
            if (isServer)
            {
                _winPopup.ShowWinner(connectionToClient.connectionId.ToString());
                RpcShow();
            }
            else if (isClient)
            {
                CmdShow();
            }
        }

        [ClientRpc]
        private void RpcShow()
        {
            if (_winPopup!=null)
            {
                _winPopup.ShowWinner("Имя");
            }
            
        }

        [Command]
        private void CmdShow()
        {
            if (_winPopup!=null)
            {
                _winPopup.ShowWinner(connectionToClient.connectionId.ToString());
            }
        }
        
        [ClientRpc]
        public void Hide()
        {
            _winPopup.Hide();
        }
    }
}
