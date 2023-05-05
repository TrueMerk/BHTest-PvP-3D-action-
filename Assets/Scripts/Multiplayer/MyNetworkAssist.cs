using Mirror;
using UnityEngine;

namespace Multiplayer
{
    public class MyNetworkAssist : MonoBehaviour
    {
        [SerializeField] private NetworkManager _networkManager;

        private void Start()
        {
            if (!Application.isBatchMode)
            {
                _networkManager.StartClient();
            }
        }

        public void JoinClinet()
        {
            _networkManager.networkAddress = "localhost";
            _networkManager.StartClient();
        }
    }
}