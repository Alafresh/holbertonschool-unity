using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private int currentScene;
    public GameObject pauseMenu;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Pause();
    }
    public void Pause()
    {
        if (Time.timeScale == 1f)
            Time.timeScale = 0f;
        else
            Time.timeScale = 1f;
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
        SceneManager.LoadScene(0);
    }
    public void Options()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("Back", currentScene);
        SceneManager.LoadScene(1);
    }
}
