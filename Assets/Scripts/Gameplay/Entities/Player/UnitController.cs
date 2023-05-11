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

            var rot = new Vector3(rotation.y, rotation.x, rotation.y);
            _movementComponent.Rotate(rot);
            
            if (direction!=Vector3.zero)
            {
                _movementComponent.Move(direction*Time.deltaTime);
            }
        
            else if (!canAttack || !isAttack)
            {
            }
        
            if(canAttack && isAttack)
            {
                _attackComponent.Attack();
            }
        }
    }
}
