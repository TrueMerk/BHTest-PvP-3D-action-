using System;
using Gameplay.Components.Input;
using Gameplay.Entities.Player;
using UnityEngine;
using Zenject;

namespace Gameplay.Entities.Enemy
{
    public class EnemyInput : InputComponent
    {
        [SerializeField] private float _attackDistance = 1;
        private UnitController _unitController;
    
        [Inject]
        public void Construct(UnitController unitController)
        {
            _unitController = unitController;
        }
        

        public override Vector3 GetMovementDirection()
        {
            if (Difference().magnitude <= _attackDistance )
            {
                return Vector3.zero;
            }
            return Difference();
        }

        public override Quaternion GetRotation()
        {
            var target = Quaternion.identity;
            if (Difference().magnitude>1)
            {
                var rotateZ = Math.Atan2(Difference().x, Difference().z) * Mathf.Rad2Deg;
                target = Quaternion.Euler(0f,(float) rotateZ,0f);
            }
            return Quaternion.Lerp(transform.rotation, target, Time.deltaTime * 100);
        }

        public override bool IsAttacking()
        {
            return Difference().magnitude <= _attackDistance;
            
        }

        private Vector3 Difference()
        {
            //var playerPosition = _unitController.transform.position;
            //return playerPosition - transform.position;
            return Vector3.zero;
        }
    }
}
