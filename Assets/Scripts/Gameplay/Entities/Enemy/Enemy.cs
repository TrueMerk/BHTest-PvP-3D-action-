using Gameplay.Components;
using UnityEngine;
using Zenject;

namespace Gameplay.Entities.Enemy
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private HealthComponent _health;

        private EnemyContainer _container;

        [Inject]
        public void Construct(EnemyContainer container)
        {
            _container = container;
            _health.Dead += DeathMethod;
        }

        private void DeathMethod()
        {
            _container.EnemyList.Remove(this);
        }
    }
}