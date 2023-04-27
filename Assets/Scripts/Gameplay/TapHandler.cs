using UnityEngine;
using UnityEngine.Events;

namespace Gameplay
{
    public class TapHandler : MonoBehaviour
    {
        public UnityEvent onTap;

        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                onTap.Invoke();
            }
        }
    }
}
