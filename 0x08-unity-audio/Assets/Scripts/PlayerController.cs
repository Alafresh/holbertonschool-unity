using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject tay;
    [SerializeField] public Transform target;
    [SerializeField] public Rigidbody rb;
    public float velRotation = 200.0f;
    public float speed;
    public float jumpForce;
    bool isOnGround;
    public Animator anim;
    
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        if (moveZ != 0f)
            anim.SetBool("isMoving", true);
        else
            anim.SetBool("isMoving", false);

        Vector3 movement = new Vector3(moveX, 0f, moveZ);
        transform.Translate(movement * (speed * Time.deltaTime));
        transform.Rotate(0, moveX * Time.deltaTime * velRotation, 0);

        if (isOnGround && Input.GetKey(KeyCode.Space))
        {
            anim.SetBool("ground", true);
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
        if (transform.position.y < -9f)
        {
            transform.position = new Vector3(0f, 40f, 0f);
            anim.SetBool("isFalling", true);
            StartCoroutine(fall());
        }
    }
    IEnumerator fall()
    {
        yield return new WaitForSeconds(1.5f);
        anim.SetBool("isFalling", false);
        anim.SetBool("splat", true);
        yield return new WaitForSeconds(0.5f);
        anim.SetBool("getUp", true);
        yield return new WaitForSeconds(3.5f);
        anim.SetBool("splat", false);
        anim.SetBool("getUp", false);
        tay.transform.localPosition = new Vector3(0.1f, -1f, 0.3f);
        tay.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            isOnGround = true;
            anim.SetBool("ground", false);
        }
    }
}
