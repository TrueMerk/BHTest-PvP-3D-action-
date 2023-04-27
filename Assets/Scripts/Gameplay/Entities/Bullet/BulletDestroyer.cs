using Gameplay.Entities.Player;
using UnityEngine;

namespace Gameplay.Entities.Bullet
{
    public class BulletDestroyer : MonoBehaviour
    {
        [SerializeField] private BulletDamageDealer _bulletDamageDealer;
        private void OnTriggerEnter(Collider other)
        {
            /*if (!_bulletDamageDealer.FromEnemy)
            {
                var player = other.GetComponent<PlayerUnit>();
                if (player == null)
                {
                    gameObject.SetActive(false);
                }
            }
            else
            {
                var player = other.GetComponent<PlayerUnit>();
                if (player != null)
                {
                    gameObject.SetActive(false);
                }
            }*/
            
        }
    }
}
