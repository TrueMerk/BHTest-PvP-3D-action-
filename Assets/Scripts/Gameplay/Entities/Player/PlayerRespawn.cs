using System.Collections;
using System.Collections.Generic;
using Mirror;
using Multiplayer;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Gameplay.Entities.Player
{
    public class PlayerRespawn : NetworkBehaviour
    {
        [SerializeField] private Vector3 _respawnPosition;
        [SerializeField] private float respawnTime = 1f;
        private NetworkManager _networkManager;

        private PlayerWinPopup playerWinPopup;
        private PlayerDamageDealer playerDamageDealer;
        [SerializeField] private List<Vector3> startPositions;

        
        private void Start()
        {
            playerWinPopup = GetComponent<PlayerWinPopup>();
            playerDamageDealer = GetComponent<PlayerDamageDealer>();
            
        }
        
        [TargetRpc]
        public void SetPos(Vector3 respawnPosition)
        {
            
            _respawnPosition = respawnPosition;
            if (isLocalPlayer)
            {
                CmdSetRespawnPosition(respawnPosition);
            }
        }
        
        [TargetRpc]
        public void TRpcSetStartPositions(List<Vector3> positions)
        {
            startPositions = positions;
            if (isLocalPlayer)
            {
                CmdSetStartPositions(positions);
            }
        }

        [Command]
        private void CmdSetStartPositions(List<Vector3> positions)
        {
            RpcSetStartPositions(positions);
        }
        
        [ClientRpc]
        private void RpcSetStartPositions(List<Vector3> positions)
        {
            startPositions = positions;
        }
        
        [TargetRpc]
        public void TRpcRespawn()
        {
            StartCoroutine(RespawnCoroutine());
            if (isLocalPlayer)
            {
                CmdRespawn();
            }
        }
        
        private IEnumerator RespawnCoroutine()
        {
            yield return new WaitForSeconds(respawnTime);
            
            transform.position = GetRandomStartPosition();
        }
        
        private Vector3 GetRandomStartPosition()
        {
            if (startPositions.Count == 0)
            {
                Debug.LogWarning("No start positions available.");
                return Vector3.zero;
            }

            int randomIndex = Random.Range(0, startPositions.Count);
            return startPositions[randomIndex];
        }

        [TargetRpc]
        public void TRpcSub()
        {
            if (isLocalPlayer)
            {
                CmdSub();
            }
        }

        [Command]
        private void CmdSub()
        {
         RpcSub();   
        }

        [ClientRpc]
        private void RpcSub()
        {
            PlayerNetworkManager networkManager = NetworkManager.singleton.GetComponent<PlayerNetworkManager>();

            PlayerDamageDealer damageDealer = gameObject.GetComponent<PlayerDamageDealer>();
            if (damageDealer != null)
            {
                damageDealer.OnHitsDone += networkManager.RespawnPlayers;
            }
        }

        [Command]
        private void CmdRespawn()
        {
            RpcRespawn();
        }

        [ClientRpc]
        private void RpcRespawn()
        {
            StartCoroutine(RespawnCoroutine());
        }
        
        [Command]
        public void CmdSetRespawnPosition(Vector3 newPosition)
        {
            RpcSetRespawnPosition(newPosition);
        }

        [ClientRpc]
        private void RpcSetRespawnPosition(Vector3 newPosition)
        {
            _respawnPosition = newPosition;
           
        }
        
    }
}