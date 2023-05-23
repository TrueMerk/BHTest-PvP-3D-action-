using System.Collections;
using System.Collections.Generic;
using Gameplay.Entities.Player;
using Mirror;
using UnityEngine;


namespace Multiplayer
{
    public class PlayerNetworkManager : NetworkManager
    {
        public float respawnTime = 5f;
        private GameObject _player;
        public List<GameObject> activePlayers = new List<GameObject>();
        private NetworkConnectionToClient _networkConnection;
        private List<Vector3> VectorPos;
        
        public override void OnServerAddPlayer(NetworkConnectionToClient conn)
        {
            base.OnServerAddPlayer(conn);
            
            var player = conn.identity.gameObject;
            activePlayers.Add(player);
            
            VectorPos = new List<Vector3>();
            
             for (int i = 0; i < startPositions.Count; i++)
             {
                 VectorPos.Add(startPositions[i].position);
             }

             player.GetComponent<NetworkIdentity>().AssignClientAuthority(conn);
             
            foreach (GameObject activePlayer in activePlayers)
            {
                activePlayer.GetComponent<PlayerRespawn>().TRpcSetStartPositions(VectorPos);
                activePlayer.GetComponent<PlayerRespawn>().TRpcSub();
            }
        }

        public void RespawnPlayers()
        {
            StartCoroutine(RespawnPlayersCour());
        }

        
        private IEnumerator RespawnPlayersCour()
        {
            foreach (var player in activePlayers)
            {
                var playerWinPopup = player.GetComponent<PlayerWinPopup>();
                if (player.GetComponent<PlayerDamageDealer>().hitsDone)
                {
                    playerWinPopup.TRpcShow();
                }
                else
                {
                    playerWinPopup.TRpcSetPopupShownFalse();
                }
                
                player.GetComponent<PlayerDamageDealer>().SetToZero();
                yield return new WaitForSeconds(0.1f);
                var playerRespawn = player.GetComponent<PlayerRespawn>();
                playerRespawn.TRpcRespawn();

                playerWinPopup.TRpcSetPopupShownFalse();
                yield return null;
            }
           
    
            yield return new WaitForSeconds(respawnTime / 5);

            yield return new WaitForSeconds(respawnTime);

            foreach (var player in activePlayers)
            {
                var playerWinPopup = player.GetComponent<PlayerWinPopup>();
                playerWinPopup.Hide();
               
                yield return null;
            }
        }
    }
}
