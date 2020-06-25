using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerTrigger : MonoBehaviour
{
    public Timer start;
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "player")
        {
            start.StartTimer();
        }
    }
}
