using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public GameObject settingsPanel;

    public void ArcadeMode()
    {
        SceneManager.LoadScene(2);
    }
    public void Credits()
    {
        SceneManager.LoadScene(18);
    }
    public void Settings()
    {
        settingsPanel.SetActive(true);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
