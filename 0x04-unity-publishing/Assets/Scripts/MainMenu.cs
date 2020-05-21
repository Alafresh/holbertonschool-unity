using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Material trapMat;
    public Material goalMat;
    public UnityEngine.UI.Toggle colorblindMode;
    public void PlayMaze()
    {
        if (colorblindMode.isOn)
        {
            trapMat.color = new Color32(255, 112, 0, 1);
            goalMat.color = Color.blue;
        }
        else
        {
            trapMat.color = Color.red;
            goalMat.color = Color.green;
        }
        SceneManager.LoadScene(1);
    }
    public void QuitMaze()
    {
        Application.Quit();
        Debug.Log("Quit Game");
    }
}
