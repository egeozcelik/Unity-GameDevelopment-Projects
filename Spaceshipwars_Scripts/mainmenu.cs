using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;


public class mainmenu : MonoBehaviour
{

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
    public AudioMixer audioMixer;
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }
    public GameObject OptionsMenu;
    public GameObject MainMenu;
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
    public void OpenOptions()
    {
        OptionsMenu.SetActive(true);
        MainMenu.SetActive(false);
    }
    public void Back()
    {
        OptionsMenu.SetActive(false);
        MainMenu.SetActive(true);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
