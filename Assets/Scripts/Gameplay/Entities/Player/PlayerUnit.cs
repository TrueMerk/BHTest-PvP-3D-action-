using System;
using Gameplay.Components;
using UnityEngine;
using Zenject;

namespace Gameplay.Entities.Player
{
    public class PlayerUnit : Unit
    {
        private UnitController _unitController;

        public Action GameOverAction;
        
        [Inject]
        public void Construct(UnitController unitController)
        {
            _unitController = unitController;
        }
        
        private void Start()
        {
            HealthComponent.Dead += Dead;
        }

        private void Dead()
        {
            
        }
    }
}
