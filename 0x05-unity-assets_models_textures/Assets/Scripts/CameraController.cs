﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform target;
    public float rotSpeed = 0.3f;
    private float rotY;
    private float rotX;
    private Vector3 offset;
    Quaternion tmp;

    void Start()
    {
        rotX = transform.eulerAngles.x;
        rotY = transform.eulerAngles.y;
        offset = target.position - transform.position;
        tmp = Quaternion.Euler(0, rotY, 0);
    }

    void LateUpdate()
    {
        transform.position = target.position - (tmp * offset);
        transform.LookAt(target);
        if (Input.GetMouseButton(1))
        {
            float horInput = Input.GetAxis("Horizontal");
            if (horInput != 0)
            {
                rotY += horInput * rotSpeed;
            }
            else
            {
                rotY += Input.GetAxis("Mouse X") * rotSpeed * 3;
            }

            float verInput = Input.GetAxis("Vertical");
            if (verInput != 0)
            {
                rotX += verInput * rotSpeed;
            }
            else
            {
                rotX += Input.GetAxis("Mouse Y") * rotSpeed * 3;
            }

            Quaternion rotation = Quaternion.Euler(rotX, rotY, 0);
            transform.position = target.position - (rotation * offset);
            transform.LookAt(target);
            tmp = rotation;
        }
    }
}
