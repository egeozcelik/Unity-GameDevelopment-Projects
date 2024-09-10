using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class gameover : MonoBehaviour
{
    public int can;
    public  int i = 1;
    public Button adsButton;

    private void Start()
    {
        
    }
    private void Update()
    {

        
        

        if (Can_panel.kalan_can <= 0)
        {
            Invoke("showButton", 1.0f);
            
        }
    }
    void showButton()
    {
            adsButton.gameObject.SetActive(true);

    }

        //void update(){
    //    if (Can_panel.kalancan < 0)
    //{
    //     +1 can? butonu.setactive(true)
    //     Bu buton restart ile üst üste inaktif olarak duracak ads scripti bu butonun içine gömülü olacak.
    //}
    // }
    // public void rewardedAdCagir()
    //  {
    //      //reklamı cagıran fonksiyon
    //  }
    public void restart()
    {
        Can_panel.kalan_can--;
        InterstitialAds.control++;

        if (Can_panel.kalan_can > -1)
        {

            
            Scene activeScene = SceneManager.GetActiveScene();
            int buildIndex = activeScene.buildIndex;
            SceneManager.LoadScene(buildIndex);
            
           

        }
        else
        {
            SceneManager.LoadScene(1);

            Can_panel.kalan_can = 3;
           
        }
    }

    public void nextLevel()
    {
        InterstitialAds.control++;
    Scene activeScene = SceneManager.GetActiveScene();
    int buildIndex = activeScene.buildIndex;

        switch (buildIndex)
        {
            case 0:
                SceneManager.LoadScene(1);
                break;
            case 1:
                SceneManager.LoadScene(2);
                break;
            case 2:
                SceneManager.LoadScene(3);
                break;
            case 3:
                SceneManager.LoadScene(4);
                break;
                //
            case 4:
                SceneManager.LoadScene(5);
                break;
            case 5:
                SceneManager.LoadScene(6);
                break;
            case 6:
                SceneManager.LoadScene(7);
                break;
            case 7:
                SceneManager.LoadScene(8);
                break;
            case 8:
                SceneManager.LoadScene(9);
                break;
            case 9:
                SceneManager.LoadScene(10);
                break;
            case 10:
                SceneManager.LoadScene(11);
                break;
            case 11:
                SceneManager.LoadScene(12);
                break;
            case 12:
                SceneManager.LoadScene(13);
                break;
            case 13:
                SceneManager.LoadScene(14);
                break;
            case 14:
                SceneManager.LoadScene(15);
                break;
            case 15:
                SceneManager.LoadScene(16);
                break;
            case 16:
                SceneManager.LoadScene(17);
                break;
            case 17:
                SceneManager.LoadScene(18);
                break;
            case 18:
                SceneManager.LoadScene(19);
                break;
            case 19:
                SceneManager.LoadScene(20);
                break;
            case 20:
                SceneManager.LoadScene(21);
                break;
            default:
                break;
        }
    }
}
