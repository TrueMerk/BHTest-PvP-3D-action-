using System;
using UnityEngine;

namespace Gameplay.Entities.Player
{
    public class PlayerMover : MonoBehaviour
    {
        [SerializeField] private float _speed;

        private bool isAttacking = false;
        public Action MovingAction;

        
        void Update()
        {
           
                float h = Input.GetAxis("Horizontal");
                float v = Input.GetAxis("Vertical");
            
                if (h!=0 || v != 0)
                {
                    //_animator.PlayRunningAnimation();
                
                }
            
                else if (Input.GetButtonDown("Jump"))
                {
                    //_animator.PlayAttackAnimation();
                    isAttacking = true;
                }
            
                else if (h==0 && v == 0) 
                {
                    //_animator.PlayIdleAnimation();
                 
                }
                
                transform.Translate(h/100*_speed,v/100*_speed,0);
                
        }
    }
}
