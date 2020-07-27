using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour
{
    public AudioMixerSnapshot unPaused;
    public AudioSource wall;
    public Slider sfx;
    public Slider bgm;
    public AudioMixer mixer;
    public int check;
    public Toggle yAxis;
    public CameraController tmp;

    private void Awake()
    {
        unPaused.TransitionTo(.01f);
        wall.Stop();
        if (PlayerPrefs.GetInt("music") == 0)
            wall.Play();
        else
            wall.Stop();
    }
    public void SetLevel(float sliderValue)
    { 
        mixer.SetFloat("BgmVol", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("MusicVolume", sliderValue);
    }
    public void SetSfx(float sliderValue)
    {
        mixer.SetFloat("SfxVol", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("SFXVolume", sliderValue);
    }

    private void Start()
    {
        if (PlayerPrefs.GetInt("Check") == 1)
            yAxis.isOn = true;
        else
            yAxis.isOn = false;
        sfx.value = PlayerPrefs.GetFloat("SFXVolume", 0.75f);
        bgm.value = PlayerPrefs.GetFloat("MusicVolume", 0.75f);
    }
    public void Back()
    {
        PlayerPrefs.SetInt("music", 1);
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
