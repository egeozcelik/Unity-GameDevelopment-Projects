using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static bool gameFinish;
    
    private GameObject rotating;
    private GameObject mainCircle;
    public GameObject deathPanel;
    public GameObject arrows;
    public GameObject restartImage;
    public GameObject soundEffect;
    
    public Animator animator;
    
    public Button RetryButton;

    public SoundEffects sfx;

    void Start()
    {
    
        soundEffect = GameObject.FindGameObjectWithTag("SoundEffect");
        sfx = soundEffect.GetComponent<SoundEffects>();


        gameFinish = false;
        
        arrows = GameObject.Find("Arrows");
        rotating = GameObject.FindGameObjectWithTag("TurningCircle");
        mainCircle = GameObject.FindGameObjectWithTag("MainCircle");
        
        RetryButton.interactable = false;
    }
    public void GameOver()
    {
        if (!gameFinish)
        {
            sfx.gameover();
            arrows.SetActive(false);
            rotating.GetComponent<rotating>().enabled = false;
            mainCircle.GetComponent<mainCircle>().enabled = false;
            StartCoroutine("panelOpen");
            animator.SetTrigger("gameover");
            //for open the panel just once
            gameFinish = true;
        }
    }
    IEnumerator panelOpen()
    {
        yield return new WaitForSeconds(2f);
        adsTrigger();
        deathPanel.SetActive(true);
        StartCoroutine("buttonsOpen");

    }
    IEnumerator buttonsOpen()
    {
        yield return new WaitForSeconds(1f);
        restartImage.SetActive(true);
        RetryButton.interactable = true;
    }
    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void NextLevel()
    {
        PlayerPrefs.SetInt("AdCounter", (PlayerPrefs.GetInt("AdCounter") - 1));
        if (PlayerPrefs.GetInt("AdCounter") < 0 && PlayerPrefs.GetInt("RewardedCounter") != -1)
        {
            Debug.Log("reklama girdi");
            Debug.Log("inter :" + PlayerPrefs.GetInt("AdCounter"));
        }
        else
        {
            Debug.Log("inter :" + PlayerPrefs.GetInt("AdCounter"));
            Debug.Log("else e girdi");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        }

    }

    private void adsTrigger()
    {
        PlayerPrefs.SetInt("RewardedCounter", (PlayerPrefs.GetInt("RewardedCounter") - 1));
        Debug.Log("inter:" + PlayerPrefs.GetInt("AdCounter"));
        Debug.Log("rewarded:" + PlayerPrefs.GetInt("RewardedCounter"));

    }
}
