using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private int currentScene;
    public void LevelSelect(int level)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(level);
    }
    public void Options()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("Back", currentScene);
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        Debug.Log("Exited");
        Application.Quit();
    }
}
