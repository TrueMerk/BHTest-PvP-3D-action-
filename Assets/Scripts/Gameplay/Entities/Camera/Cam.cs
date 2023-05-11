using Mirror;
using UnityEngine;

namespace Gameplay.Entities.Camera
{
    public class Cam : NetworkBehaviour
    {
        [SerializeField]private float _speed = 5.0f;
        [SerializeField] private GameObject _playerCam;
        private Vector3 _mousePos;
        private UnityEngine.Camera _goCamera;
        

        private void Start()
        {
            _goCamera = gameObject.GetComponent<UnityEngine.Camera>();
            if (!isLocalPlayer)
            {
                _playerCam.gameObject.SetActive(false);
            }
        }

        private void Update()
        {
            _mousePos = Input.mousePosition;
        }

        private void FixedUpdate()
        {
            var h = _speed * Input.GetAxis("Mouse X");
            var v = _speed * Input.GetAxis("Mouse Y");
        
           _playerCam.transform.Translate(h*Time.deltaTime,v*Time.deltaTime,0);
        }
    }
}