using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinTrigger : MonoBehaviour
{
    public Timer finish;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "player")
        {
            finish.Finish();
        }
    }
}
