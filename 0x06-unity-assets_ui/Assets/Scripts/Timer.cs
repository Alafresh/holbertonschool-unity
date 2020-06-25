using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText;
    private bool start = false;
    private float startTime;
    public void StartTimer()
    {
        start = true;
    }
    public void Finish()
    {
        start = false;
        timerText.color = Color.green;
        timerText.fontSize = 60;
    }
    private void Start()
    {
        startTime = Time.time;
    }
    private void Update()
    {
        if (start)
        {
            float t = Time.time - startTime;

            string minutes = ((int)t / 60).ToString();
            string seconds = (t % 60).ToString("f2");
            timerText.text = minutes + ":" + seconds;
        }
    }
}
