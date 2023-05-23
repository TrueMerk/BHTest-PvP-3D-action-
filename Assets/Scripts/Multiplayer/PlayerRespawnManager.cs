using System.Collections;
using System.Collections.Generic;
using Gameplay.Entities.Player;
using Mirror;
using UnityEngine;

namespace Multiplayer
{
    public class PlayerRespawnManager : NetworkBehaviour
    {
        public float respawnTime = 5f;
        public List<GameObject> activePlayers = new List<GameObject>();
        private List<PlayerRespawn> playerRespawns = new List<PlayerRespawn>();

        private void Start()
        {
            
            foreach (var player in activePlayers)
            {
                var playerRespawn = player.GetComponent<PlayerRespawn>();
                if (playerRespawn != null)
                {
                    playerRespawns.Add(playerRespawn);
                }
            }
        }
        

        public void RespawnAllPlayers()
        {
            StartCoroutine(RespawnAllPlayersCoroutine());
        }

        private IEnumerator RespawnAllPlayersCoroutine()
        {
            foreach (var playerRespawn in playerRespawns)
            {
                playerRespawn.TRpcRespawn();
                yield return new WaitForSeconds(respawnTime);
            }
        }
    }
}