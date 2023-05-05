using UnityEngine;

namespace Gameplay.Entities.Camera
{
    public class Cam : MonoBehaviour
    {
        private Vector3 _mousePos;
        private UnityEngine.Camera goCamera;
        private float _speed = 5.0f;
        
        private void Start()
        {
            goCamera = gameObject.GetComponent<UnityEngine.Camera>();
        }

        private void Update()
        {
            _mousePos = Input.mousePosition;
        }

        private void FixedUpdate()
        {
            var h = _speed * Input.GetAxis("Mouse X");
            var v = _speed * Input.GetAxis("Mouse Y");
        
           transform.Translate(h*Time.deltaTime,v*Time.deltaTime,0);
        }
    }
}