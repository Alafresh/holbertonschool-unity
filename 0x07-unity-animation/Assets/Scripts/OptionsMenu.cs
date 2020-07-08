using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionsMenu : MonoBehaviour
{
    public int check;
    public Toggle yAxis;
    public CameraController tmp;

    private void Start()
    {
        if (PlayerPrefs.GetInt("Check") == 1)
            yAxis.isOn = true;
        else
            yAxis.isOn = false;
    }
    public void Back()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("Back"));
        Time.timeScale = 1f;
    }
    public void Apply()
    {
        if (yAxis.isOn == true)
        {
            check = 1;
            tmp.isInvertedY();
            PlayerPrefs.SetInt("Check", check);
        }
        else
        {
            check = 0;
            tmp.isNotInvertedY();
            PlayerPrefs.SetInt("Check", check);
        }
        SceneManager.LoadScene(PlayerPrefs.GetInt("Back"));
        Time.timeScale = 1f;
    }
}
