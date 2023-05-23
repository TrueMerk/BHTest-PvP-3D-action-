using Mirror;
using UnityEngine;

namespace Multiplayer
{
    public class PlayerStateController : NetworkBehaviour
    {
        [SyncVar(hook = nameof(OnPlayerActiveStateChanged))]
        private bool isActive = true;

        private void OnPlayerActiveStateChanged(bool oldState, bool newState)
        {
            gameObject.SetActive(newState);
        }

        [Command]
        public void CmdSetPlayerActive(bool activeState)
        {
            if (!isServer)
                return;

            isActive = activeState;
            RpcSetActive(activeState); 
        }

        [ClientRpc]
        private void RpcSetActive(bool activeState)
        {
            gameObject.SetActive(activeState);
            Debug.Log("активности",gameObject.transform);
        }

        [Command]
        public void CmdSetPlayerPosition(Vector3 position)
        {
            transform.position = position;
        }
    }
}