using System;
using Mirror;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Multiplayer
{
    public class GameManager : MonoBehaviour
    {
        private GameObject playerPref;

        private void Start()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

            GameObject player = Instantiate(playerPref);
            
            NetworkServer.Spawn(player);
        }
    }
}
