using Mirror;
using Multiplayer;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Gameplay.Entities.Player
{
    public class PlayerDamageDealer : NetworkBehaviour
    {
        [SyncVar(hook = nameof(SyncHitCounter))]private int _hitCount = 0;
        [SerializeField] private TMP_Text _text;
        
        [SerializeField]private WinPopup _winPopup;
        [SerializeField] private GameManager _gameManager;
        
        [Inject]
        public void Construct( WinPopup winPopup)
        {
            _winPopup = winPopup;
            Debug.Log(_winPopup);
        }
        
        private void OnTriggerEnter(Collider other)
        {
            
            var unitController = other.GetComponent<UnitController>();
            var playerColor = other.GetComponent<PlayerColor>();
            var playerHealth = other.GetComponent<PlayerHealth>();
            
            DealDamage(unitController,playerColor,playerHealth);

            gameObject.GetComponent<BoxCollider>().isTrigger = false;
        }
        
        
        private void DealDamage(UnitController unitController, PlayerColor playerColor,PlayerHealth health)
        {
            
            if ( unitController!=null && !unitController.gameObject.GetComponent<NetworkIdentity>().isOwned)
            {
                if (playerColor != null)
                {
                    if (isServer)
                    {
                        health.TakeDamage(25);
                        _hitCount++;
                    }
                    else
                    {
                        CmdDealDamage(health);
                    }
                }
            }
        }

        [Command]
        private void CmdDealDamage(PlayerHealth heal)
        {
            heal.TakeDamage(25);
            _hitCount++;
        }

        private void SyncHitCounter(int oldValue,int newValue)
        {
            Debug.Log($"hitCounter changed from{oldValue}to{newValue}");
            _text.text = _hitCount.ToString();
            if (_hitCount>2)
            {
                if (isClient)
                {
                    
                }
            }
            
        }

        [ClientRpc]
        private void RPCShowWinner(string winnerName)
        {
            _winPopup.ShowWinner(winnerName);
        }
        
        [Command]
        private void CMDShowWinner(string winnerName)
        {
            RPCShowWinner(GetComponent<NetworkIdentity>().netId.ToString());
        }
    }
}
