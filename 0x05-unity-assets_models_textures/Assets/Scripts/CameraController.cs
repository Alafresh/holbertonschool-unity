using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Range(0.01f, 1.0f)]
    public float smoothFactor = 0.5f;
    [SerializeField]
    public GameObject player;
    public Vector3 offset;
    public float rotationSpeed;
    void LateUpdate()
    {
        Quaternion camAngle =
            Quaternion.AngleAxis(Input.GetAxis("Mouse X") * rotationSpeed, Vector3.up);

        offset = camAngle * offset;
        transform.position = player.transform.position + offset;
        Vector3 newPos = player.transform.position + offset;
        transform.position = Vector3.Slerp(transform.position, newPos, smoothFactor);
        transform.LookAt(player.transform);
    }
}
