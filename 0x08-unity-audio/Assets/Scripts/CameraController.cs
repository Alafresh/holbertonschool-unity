using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float rotSpeed = 0.3f;
    private float rotY;
    private float rotX;
    private Vector3 offset;
    Quaternion tmp;
    public bool isInverted;

    void Start()
    {
        rotX = transform.eulerAngles.x;
        rotY = transform.eulerAngles.y;
        offset = target.position - transform.position;
        tmp = Quaternion.Euler(0, rotY, 0);

        if (PlayerPrefs.GetInt("Check") == 1)
            isInverted = true;
        else
            isInverted = false;
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

            if (isInverted == true)
            {

                float verInput = Input.GetAxis("Vertical");
                if (verInput != 0)
                {
                    rotX += verInput * rotSpeed;
                }
                else
                {
                    rotX += -Input.GetAxis("Mouse Y") * rotSpeed * 3;
                }
            }
            else
            {
                float verInput = Input.GetAxis("Vertical");
                if (verInput != 0)
                {
                    rotX += verInput * rotSpeed;
                }
                else
                {
                    rotX += Input.GetAxis("Mouse Y") * rotSpeed * 3;
                }
            }

            Quaternion rotation = Quaternion.Euler(rotX, rotY, 0);
            transform.position = target.position - (rotation * offset);
            transform.LookAt(target);
            tmp = rotation;
        }
    }
    public void isInvertedY()
    {
        isInverted = true;
    }
    public void isNotInvertedY()
    {
        isInverted = false;
    }
}
