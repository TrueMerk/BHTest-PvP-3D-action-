using System;
using Mirror.Core;
using Multiplayer;
using TMPro;
using UnityEngine;


namespace Gameplay.Entities.Player
{
    public class PlayerDamageDealer : NetworkBehaviour
    {
        [SyncVar(hook = nameof(SyncHitCounter))]private int _hitCount = 0;
        [SerializeField] private TMP_Text _text;
        
        public Action Damaged;
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
        
        private void OnEnable()
        {
            if (isServer)
            {
                _hitCount = 0;
            }
            else
            {
                CmdEnable();
            }
            
        }

        [Command]
        private void CmdDealDamage(PlayerHealth heal)
        {
            heal.TakeDamage(25);
            _hitCount++;
        }

        [Command]
        private void CmdEnable()
        {
            _hitCount = 0;
        }

        private void SyncHitCounter(int oldValue,int newValue)
        {
            Debug.Log($"hitCounter changed from{oldValue}to{newValue}");
            _text.text = _hitCount.ToString();
            if (_hitCount>2)
            {
                Damaged.Invoke();
            }
        }
    }
}
