using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] public Rigidbody rb;
    public float speed;
    public float jumpForce;
    bool isOnGround;
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveX, 0f, moveZ);
        transform.Translate(movement * (speed * Time.deltaTime));
        
        if (isOnGround && Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }
        if (Input.GetMouseButton(1))
        {
            Vector3 move = Vector3.zero;
            float horInput = Input.GetAxis("Horizontal");
            float vertInput = Input.GetAxis("Vertical");
            if (horInput != 0 || vertInput != 0)
            {
                move.x = horInput;
                move.z = vertInput;
                Quaternion tmp = target.rotation;
                target.eulerAngles = new Vector3(0, target.eulerAngles.y, 0);
                move = target.TransformDirection(move);
                target.rotation = tmp;
                transform.rotation = Quaternion.LookRotation(move);
            }
        }
        if (transform.position.y < -10f)
        {
            transform.position = new Vector3(0f, 20f, 0f);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            isOnGround = true;
        }
    }
}
