using System.Collections;
using UnityEngine;

namespace Gameplay.Entities.Bullet
{
    public class BulletLife : MonoBehaviour
    {
        [SerializeField] private float _lifeTime;
    
        private void OnEnable()
        {
            StartCoroutine("LifeRoutine");
        }

        private void OnDisable()
        {
            if (GetComponentInParent<Transform>() != null)
                transform.position = GetComponentInParent<Transform>().position;
        }

        private IEnumerator LifeRoutine()
        {
            yield return new WaitForSecondsRealtime(_lifeTime);
            gameObject.SetActive(false);
        }
    }
}