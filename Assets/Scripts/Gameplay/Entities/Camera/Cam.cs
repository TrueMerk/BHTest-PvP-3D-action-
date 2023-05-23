using Mirror;
using UnityEngine;


namespace Gameplay.Entities.Camera
{

    public class Cam: NetworkBehaviour
    {
        [SerializeField] private Transform _target;  // Ссылка на трансформ персонажа
        [SerializeField] private Vector2 _sensitivity = new Vector2(2.0f, 2.0f);
        [SerializeField] private float _distance = 5.0f;
        [SerializeField] private float _height = 2.0f;
        [SerializeField] private GameObject _playerCam;

        private float rotationX = 0.0f;
        private float rotationY = 0.0f;

        private void Start()
        {
            if (_target == null)
            {
                Debug.LogError("ERROR NO TARGET");
            }
            if (!isLocalPlayer)
            {
                _playerCam.gameObject.SetActive(false);
            }
        }

        private void LateUpdate()
        {
            if (_target == null)
                return;

            rotationX += Input.GetAxis("Mouse X") * _sensitivity.x;
            rotationY -= Input.GetAxis("Mouse Y") * _sensitivity.y;
            rotationY = Mathf.Clamp(rotationY, -90.0f, 90.0f);

            var rotation = Quaternion.Euler(rotationY, rotationX, 0.0f);
            var position = rotation * new Vector3(0.0f, _height, -_distance) + _target.position;

            _playerCam.transform.rotation = rotation;
            _playerCam.transform.position = position;
        }
    }

}