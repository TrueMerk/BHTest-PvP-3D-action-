using Gameplay.Components;
using Gameplay.Entities.Player;
using UnityEngine;

namespace Gameplay.Entities.Bullet
{
    public class BulletDamageDealer : MonoBehaviour
    {


        private int _view;
        
        private void OnTriggerEnter(Collider other)
        {

            var player = other.GetComponent<UnitController>();
            var health = other.GetComponent<HealthComponent>();


            // if (player != null && !player.photonView.IsMine)
            // {
            //     // Вызвать метод TakeDamage у компонента здоровья через RPC
            //     health.photonView.RPC("TakeDamage", RpcTarget.Others);
            //
            //     // Деактивировать пулю
            //     gameObject.SetActive(false);
            // }
            

        }
        
    }
}

