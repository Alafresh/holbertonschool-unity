using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform target;
    public float rotSpeed = 1.5f;
    private float _rotY;
    private Vector3 _offset;
    Quaternion tmp;

    void Start()
    {
        _rotY = transform.eulerAngles.y;
        _offset = target.position - transform.position;
        tmp = Quaternion.Euler(0, _rotY, 0);
    }

    void LateUpdate()
    {
        transform.position = target.position - (tmp * _offset);
        transform.LookAt(target);
        if (Input.GetMouseButton(1))
        {
            float horInput = Input.GetAxis("Horizontal");
            if (horInput != 0)
            {
                _rotY += horInput * rotSpeed;
            }
            else
            {
                _rotY += Input.GetAxis("Mouse X") * rotSpeed * 3;
            }

            Quaternion rotation = Quaternion.Euler(0, _rotY, 0);
            transform.position = target.position - (rotation * _offset);
            transform.LookAt(target);
            tmp = rotation;
        }
    }
}
