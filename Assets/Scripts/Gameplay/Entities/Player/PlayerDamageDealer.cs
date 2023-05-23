using System;
using Mirror;
using Multiplayer;
using TMPro;
using UnityEngine;

namespace Gameplay.Entities.Player
{
    public class PlayerDamageDealer : NetworkBehaviour
    {
        
        [SyncVar(hook = nameof(SyncHitCounter))]private int _hitCount = 0;
        [SerializeField] private TMP_Text _text;
        [SerializeField] private int _hitsToWinCount = 0;

        public bool hitsDone;
         
        public Action OnHitsDone;
        private void OnTriggerEnter(Collider other)
        {
            var unitController = other.GetComponent<UnitController>();
            var playerColor = other.GetComponent<PlayerColor>();
            var playerHealth = other.GetComponent<PlayerHealth>();

            if (playerColor!=null && playerHealth.canBeAttacked)
            {
                DealDamage(unitController, playerColor, playerHealth);
            }
            
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
                        health.TakeDamage(1);
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
            if (isLocalPlayer)
            {
                CmdEnable();
            }
        }

        [TargetRpc]
        public void SetToZero()
        {
            if (isLocalPlayer)
            {
                CmdSetToZero();
            }
        }
        
        [Command]
        private void CmdSetToZero()
        {
            _hitCount = 0;
            RpcUpdateHitCount(_hitCount);
        }

        
        [ClientRpc]
        private void RpcUpdateHitCount(int value)
        {
            _hitCount = value;
            if (_text != null)
            {
                _text.text = _hitCount.ToString();
            }
        }
        
        [Command]
        private void CmdDealDamage(PlayerHealth heal)
        {
            
            heal.TakeDamage(1);
            _hitCount++;

        }

        
        [Command]
        private void CmdEnable()
        {
            _hitCount = 0;
        }

        private void SyncHitCounter(int oldValue,int newValue)
        {
            if (_text != null)
            {
                _text.text = _hitCount.ToString();
            }
            
            if (isServer && _hitCount > _hitsToWinCount - 1)
            {
                
                if (OnHitsDone != null)
                {
                    OnHitsDone.Invoke();
                    hitsDone = true;
                }
                
                RpcTriggerHitsDone();
            }
        }
        
        [ClientRpc]
        private void RpcTriggerHitsDone()
        {
            if (isLocalPlayer && OnHitsDone != null)
            {
                if (NetworkServer.active)
                {
                    OnHitsDone.Invoke();
                }
                
            }
        }
        
        
    }
}
