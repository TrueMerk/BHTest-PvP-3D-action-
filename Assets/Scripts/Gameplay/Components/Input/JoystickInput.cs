
using UI;
using UnityEngine;

namespace Gameplay.Components.Input
{
    public class JoystickInput : InputComponent
    {
        
       
        /*[SerializeField] private BtnClicked _attackButton;
        private bool _attack;

        
        private void Start()
        {
            _attackButton.OnPointDown += BtnClicked;
            _attackButton.OnPointUp += BtnUP;
        }

        public override Vector3 GetMovementDirection()
        {
            if (_joystick != null)
            {
                return Vector3.forward * _joystick.Vertical + Vector3.right * _joystick.Horizontal;
            }
            else return Vector3.zero;
        }

        public override Quaternion GetRotation()
        {
            if (_joystick != null)
            {
                var target = Vector3.forward * _joystick.Vertical + Vector3.right * _joystick.Horizontal;
                var rot = Quaternion.LookRotation(target, target);
                return rot;
            }
            else return Quaternion.identity;

        }

        public override bool IsAttacking()
        {
            return _attack;
        }
        
        private void BtnClicked()
        {
            _attack = true;
        }

        private void BtnUP()
        {
            _attack = false;
        }
        
        public void SetJoystick(DynamicJoystick joystickInput)
        {
            _joystick = joystickInput;
            
        }

        public void SetBtn(BtnClicked btn)
        {
            _attackButton = btn;
        }*/
        public override Vector3 GetMovementDirection()
        {
            throw new System.NotImplementedException();
        }

        public override Quaternion GetRotation()
        {
            throw new System.NotImplementedException();
        }

        public override bool IsAttacking()
        {
            throw new System.NotImplementedException();
        }
    }
}
