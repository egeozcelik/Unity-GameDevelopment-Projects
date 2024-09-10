using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused;
    public GameObject PausePanel;
    
    public Button PauseButton;
    public AudioMixer audiomixer;

    void Start()
    {
        GameIsPaused = false;

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnPauseButtonClick()
    {
        Time.timeScale = 0.0f;
        Mingo.timeScale = 0.0f;
        PauseButton.enabled = false;
        PausePanel.SetActive(true);
    }
    public void OnResumeClick()
    {
        PauseButton.enabled = true;

        Time.timeScale = 1.0f;
        Mingo.timeScale = 1.0f;

        PausePanel.SetActive(false);
       
    }
   
    public void OnMainMenuButtonClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
   
    public void setVolume(float volume)
    {
        
        audiomixer.SetFloat("Volume", volume);
    }
    public void setQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
    public void setEnglish()
    {
        SubtitleHandler.Language = true;
        OnResumeClick();

    }
    public void setTurkish()
    {
        SubtitleHandler.Language = false;
        OnResumeClick();

    }
}
