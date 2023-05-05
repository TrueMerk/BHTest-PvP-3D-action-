using System.Collections;
using Gameplay.Components;
using UnityEngine;

namespace Gameplay.Entities.Player
{
    public class PlayerShooter : AttackComponent
    {
        [SerializeField] private float _shootRate;
        [SerializeField] private PlayerDamageDealer _playerDamageDealer;
        [SerializeField] private BoxCollider _collider;
        [SerializeField] private int _dashDistance;
        private bool _isReload;
        private bool _enemyExist;

        public override bool CanAttack => !_isReload ;
        
        private void Shoot()
        {
            _collider.isTrigger = true;
            transform.Translate(Vector3.forward*_dashDistance);
            StartCoroutine(Reload());
        }

       
        private IEnumerator Reload()
        {
            _isReload = true;
            yield return new WaitForSeconds(_shootRate/2);
            _collider.isTrigger = false;
            yield return new WaitForSeconds(_shootRate/2);
            _isReload = false;
        }
        
        public override void Attack()
        {
            if (!_isReload)
            {
                Shoot();
            }
            
        }
        
        
    }
}
