using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Gameplay.Entities.Player;
using Mirror;
using UnityEngine;

namespace Multiplayer
{
    public class PlayerNetworkManager : NetworkManager
    {
        public List<GameObject> players = new List<GameObject>();
        public float respawnTime = 5f;
        private GameObject _player;
        
        public override void OnServerAddPlayer(NetworkConnectionToClient conn)
        {
            var pos = Random.Range(0, startPositions.Count - 1);
            var player = (GameObject)Instantiate(playerPrefab, startPositions[pos].position, Quaternion.identity);
            players.Add(player);
            player.GetComponent<PlayerDamageDealer>().OnHitsDone += RespawnPlayers;
            _player = player;
            NetworkServer.AddPlayerForConnection(conn, player);
            conn.identity.transform.position = startPositions[pos].position;
        }

        private void RespawnPlayers()
        {
            StartCoroutine(RespawnPlayersCour());
        }
        
        private IEnumerator RespawnPlayersCour()
        {
            foreach (var conn in NetworkServer.connections.Values.Cast<NetworkConnection>().Where(conn => conn.identity != null))
            {
                conn.identity.gameObject.GetComponent<PlayerWinPopup>().Show();
            }
            yield return new WaitForSeconds(respawnTime/5);
            foreach (var conn in NetworkServer.connections.Values.Cast<NetworkConnection>().Where(conn => conn.identity != null))
            {
                conn.identity.gameObject.SetActive(false);
            }

            yield return new WaitForSeconds(respawnTime);

            foreach (var conn in NetworkServer.connections.Values.Cast<NetworkConnection>().Where(conn => conn.identity != null))
            {
                conn.identity.gameObject.SetActive(true);
                conn.identity.gameObject.GetComponent<PlayerWinPopup>().Hide();
                var pos = Random.Range(0, startPositions.Count - 1);
                conn.identity.transform.position = startPositions[pos].position;
            }
        }
    }
}
