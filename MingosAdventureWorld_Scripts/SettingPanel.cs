using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
public class SettingPanel : MonoBehaviour
{
    public GameObject settingsPanel;
    public AudioMixer audiomixer;
    public void settingsBack()
    {
        settingsPanel.SetActive(false);
    }
    public void LanguageScreen()
    {
        SceneManager.LoadScene(0);
    }
    public void setVolume(float volume)
    {
        audiomixer.SetFloat("Volume", volume);
    }
    public void setQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
}
