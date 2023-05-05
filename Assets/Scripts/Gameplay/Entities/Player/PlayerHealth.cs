using Mirror;
using Multiplayer;
using UnityEngine;


namespace Gameplay.Entities.Player
{
    public class PlayerHealth : NetworkBehaviour
    {
        [SerializeField] private PlayerColor _color;
        
        [SyncVar(hook = nameof(OnHealthChanged))]
        public int health = 3;

        private void OnHealthChanged(int oldValue, int newValue)
        {
            Debug.Log($"Health changed from{oldValue}to{newValue}");
            
            _color.ChangeColor(Color.black);
        }

        public void TakeDamage(int damage)
        {
            if (isServer)
            {
                health-=damage;
                
            }
            else
            {
                CMDTakeDamage(damage);
            }
            
        }

        [Command]
        private void CMDTakeDamage(int damage)
        {
            health-=damage;
            if (health <= 0)
            {
                gameObject.SetActive(false);
            }
        }
        
    }
}
