using UnityEngine;

namespace Gameplay.Components.Input
{
    public class PlayerInput : InputComponent
    {
        public override Vector3 GetMovementDirection()
        {
            return UnityEngine.Input.GetAxis("Vertical") * Vector3.forward;
        }

        public override Vector3 GetRotation()
        {
            var target =  Vector3.right*UnityEngine.Input.GetAxis("Horizontal");
            return target;
        }

        public override bool IsAttacking()
        {
            return UnityEngine.Input.GetButtonDown("Fire1");
        }
    }
}
