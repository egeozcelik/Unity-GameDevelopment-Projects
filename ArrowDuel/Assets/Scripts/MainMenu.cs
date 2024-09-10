using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public GameObject bgSound;
    public GameObject AdsGameObject;
    public GameObject pausePanel;
   
    public RewardedAdsScript rewardedScript;
    
    public int level;
    public int loadLevel;
    public static bool isPanelOpen;
   
    public GameManager gm;
    void Start()
    {
        AdsGameObject = GameObject.FindGameObjectWithTag("Ads");
        rewardedScript = AdsGameObject.GetComponent<RewardedAdsScript>();

        bgSound = GameObject.FindGameObjectWithTag("BackgroundSound");
        DontDestroyOnLoad(bgSound);
        
        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        }

        loadLevel = PlayerPrefs.GetInt("LoadLevel");
        isPanelOpen = false;
        level = SceneManager.GetActiveScene().buildIndex;
    }
    public void OpenPanelAnim()
    {

    }
    public void startgame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
    public void nextLevelOnPanel()
    {   //onWonPanel
        gm.NextLevel();

    }
    public void NextLevel()
    {
        StartCoroutine(calledFunction());
    }
    IEnumerator calledFunction()
    {
        InvokeRepeating("SpeedUpCircle", 0f, 0.1f);
        yield return new WaitForSeconds(.7f);
        if (loadLevel == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            SceneManager.LoadScene(loadLevel);
        }
    }
    void SpeedUpCircle()
    {
        OpeningScene.speed *= 3f;
    }
    public void Resume()
    {
        Time.timeScale = 1f;
        isPanelOpen = false;
        pausePanel.SetActive(false);
    }
    public void Menu()
    {
        
        Time.timeScale = 1f;
        SceneManager.LoadScene("Scenes/Opening Scene");
    }

    public void restartOnButton()
    {
        Time.timeScale = 1f;
        
        rewardedScript.UserChoseToWatchAd();
       

    }
    public void restart()
    {
        Time.timeScale = 1f;

        

    }
    public void QuitGame()
    {
        //onPause
        Time.timeScale = 1f;
        Debug.Log("Quite Basidli");
        Application.Quit();
    }
    public void NewGame()
    {
        Debug.Log("quit");
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("Scenes/Opening Scene");
    }
    public void PausePanel()
    {
        isPanelOpen = true;
        Time.timeScale = 0f;
        pausePanel.SetActive(true);

    }
}
