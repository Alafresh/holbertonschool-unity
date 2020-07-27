using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class DontDestroyAudio : MonoBehaviour
{
    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("music");
        if (objs.Length > 1)
            Destroy(this.gameObject);

        DontDestroyOnLoad(this.gameObject);

    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Level01")
        {
            Destroy(this.gameObject);
        }
        if (SceneManager.GetActiveScene().name == "Level02")
            Destroy(this.gameObject);

        if (SceneManager.GetActiveScene().name == "Level03")
            Destroy(this.gameObject);
    }
}
