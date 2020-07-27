using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinTrigger : MonoBehaviour
{
    public GameObject win;
    public Timer finish;
    public GameObject timerCanvas;
    public AudioSource cheeryMonday;
    public AudioSource piano;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "player")
        {
            Time.timeScale = 0f;
            timerCanvas.SetActive(false);
            win.SetActive(true);
            finish.Win();
            cheeryMonday.Stop();
            piano.Play();
            //finish.Finish();
        }
    }
}
