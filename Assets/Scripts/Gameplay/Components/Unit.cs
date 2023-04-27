using Gameplay.Entities.Player;

using UnityEngine;

namespace Gameplay.Components
{
    public abstract class Unit : MonoBehaviour
    {
        [SerializeField] private AttackComponent _attackComponent;
        [SerializeField] private HealthComponent _health;
        

        public AttackComponent AttackComponent => _attackComponent;
        public HealthComponent HealthComponent => _health;
    }
}
