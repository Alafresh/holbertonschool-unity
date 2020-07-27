using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;
using System;

public class PauseMenu : MonoBehaviour
{
    public AudioMixerSnapshot paused;
    public AudioMixerSnapshot unPaused;
    private int currentScene;
    public GameObject pauseMenu;
    private void Start()
    {
        unPaused.TransitionTo(.01f);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Pause();
    }
    public void Pause()
    {
        if (Time.timeScale == 1f)
        {
            paused.TransitionTo(.01f);
            Time.timeScale = 0f;
        }
        else
        {
            unPaused.TransitionTo(.01f);
            Time.timeScale = 1f;
        }
        pauseMenu.SetActive(!pauseMenu.activeSelf);
    }
    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }
    public void Restart()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
        Time.timeScale = 1f;
    }
    public void MainMenu()
    {
        unPaused.TransitionTo(.01f);
        SceneManager.LoadScene(0);
    }
    public void Options()
    {
        unPaused.TransitionTo(.01f);
        PlayerPrefs.SetInt("music", 0);
        currentScene = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("Back", currentScene);
        SceneManager.LoadScene(1);
        Debug.Log(PlayerPrefs.GetInt("music"));
    }
}
