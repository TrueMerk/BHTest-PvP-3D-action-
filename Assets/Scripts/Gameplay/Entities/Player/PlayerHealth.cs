using System.Collections;
using Mirror;
using Multiplayer;
using UnityEngine;


namespace Gameplay.Entities.Player
{
    public class PlayerHealth : NetworkBehaviour
    {
        [SerializeField] private PlayerColor _color;
        [SerializeField] private int _cantTakeDamageTime = 3;
        
        [SyncVar(hook = nameof(OnHealthChanged))]
        public int health = 3;

        [SyncVar(hook = nameof(OnCanBeAttackedChanged))]
        private bool _canBeAttacked = true;

        public bool canBeAttacked
        {
            get { return _canBeAttacked; }
            set { _canBeAttacked = value; }
        }
        
        private void OnCanBeAttackedChanged(bool oldValue, bool newValue)
        {
            // Обработка изменения состояния canBeAttacked
            // ...
        }
        
        
        
        private void OnHealthChanged(int oldValue, int newValue)
        {
            _color.ChangeColor(Color.black);
            //gameObject.GetComponent<BoxCollider>().enabled = false;
            canBeAttacked = false;
            StartCoroutine(Reload());
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
        }
        
        private IEnumerator Reload()
        {
            canBeAttacked = false;
            yield return new WaitForSeconds(_cantTakeDamageTime);
            canBeAttacked = true;
            gameObject.GetComponent<BoxCollider>().enabled = true;
        }
        
    }
}
