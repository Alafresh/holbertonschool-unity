using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneController : MonoBehaviour
{
    public PlayerController playerScript;
    public GameObject[] elements;
    public GameObject auxCamera;
    void Update()
    {
        if (transform.position == new Vector3(0f, 2.5f, -6.25f))
        {
            foreach (GameObject i in elements)
            {
                i.SetActive(true);
            }
            playerScript.enabled = true;
            auxCamera.SetActive(false);
        }
    }
}
