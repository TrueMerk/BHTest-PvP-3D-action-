using Gameplay.Components;
using Gameplay.Components.Input;
using Mirror;
using UnityEngine;


namespace Gameplay.Entities.Player
{
    public class UnitController : NetworkBehaviour
    {
        [SerializeField] private MovementComponent _movementComponent;
        [SerializeField] private InputComponent _inputComponent;
        [SerializeField] private AttackComponent _attackComponent;
        
        
        
        public void Update()
        {
            var direction = _inputComponent.GetMovementDirection();
           
            var rotation = _inputComponent.GetRotation();
            
            var isAttack = _inputComponent.IsAttacking();
            var canAttack = _attackComponent.CanAttack;
            
            
            if (!isLocalPlayer)
            {
                return;
            }
            _movementComponent.Rotate(rotation);
            if (direction!=Vector3.zero)
            {
                //_animationComponent.PlayRunningAnimation();
                _movementComponent.Move(Vector3.forward*Time.deltaTime);
            }
        
            else if (!canAttack || !isAttack)
            {
                    // _animationComponent.PlayIdleAnimation();
            }
        
            if(canAttack && isAttack)
            {
                //_animationComponent.PlayAttackAnimation();
                _attackComponent.Attack();
            }
                
        }

        
    }
}
