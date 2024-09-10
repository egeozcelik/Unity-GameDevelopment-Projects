using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject PauseMenuUI;
    public GameObject oyuncuPm;
    public GameObject dusmanPm;
    public Button buton;
    // Update is called once per frame
    void Update()
    {
        buton.GetComponent<SpriteRenderer>();
        if (!(oyuncuPm && dusmanPm))
        {
            buton.enabled = false;
        }
    }
    public void Resume()
    {
        if (oyuncuPm && dusmanPm)
        {

            PauseMenuUI.SetActive(false);
            GameIsPaused = false;

            Time.timeScale = 1f;
        }
    }
    public void Pause()
    {
        if (oyuncuPm && dusmanPm)
        {
            
            PauseMenuUI.SetActive(true);
            Time.timeScale = 0f;
            GameIsPaused = true;
        }
    }
    public void go2menu()
    {
        SceneManager.LoadScene(0);
    }
    public void exitgame()
    {
        Application.Quit();
    }
}
