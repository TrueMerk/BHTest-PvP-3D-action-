using UnityEngine;

namespace Gameplay.Components.Input
{
    public class PlayerInput : InputComponent
    {
        public override Vector3 GetMovementDirection()
        {
            return UnityEngine.Input.GetAxis("Vertical") * Vector3.forward + UnityEngine.Input.GetAxis("Horizontal") * Vector3.right ;
        }

        public override Quaternion GetRotation()
        {
            var target = Vector3.forward *UnityEngine.Input.GetAxis("Vertical") + Vector3.right*UnityEngine.Input.GetAxis("Horizontal");
            var rot = Quaternion.LookRotation(target, target);
            return rot;
        }

        public override bool IsAttacking()
        {
            return UnityEngine.Input.GetButtonDown("Jump");
        }
    }
}
