using System;
using UnityEngine;

public class Ca : MonoBehaviour
{
    private Vector3 _mousePos;
    private Camera goCamera;
    private float _speed = 5.0f;
    public GameObject go;

    private void Start()
    {
        goCamera = this.gameObject.GetComponent<Camera>();
        
    }

    private void Update()
    {
        _mousePos = UnityEngine.Input.mousePosition;
    }

    private void FixedUpdate()
    {
        var h = _speed * Input.GetAxis("Mouse X");
        var v = _speed * Input.GetAxis("Mouse Y");
        
        transform.Translate(v,h,0);
    }
}
