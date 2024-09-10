using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using UnityEngine.SceneManagement;

public class InterstitialAdsScript : MonoBehaviour
{
    private InterstitialAd interstitial;
    private int level;

    void Start()
    {
        MobileAds.Initialize(initStatus => { });
        level = SceneManager.GetActiveScene().buildIndex;

        RequestInterstitial();
    }

    
    void Update()
    {
        if (PlayerPrefs.GetInt("AdCounter") < 0 && PlayerPrefs.GetInt("RewardedCounter") != -1)
        {
            if (this.interstitial.IsLoaded())
            {
                Time.timeScale = 0f;
                this.interstitial.Show();
                Debug.Log("interstitial reklam gösteriliyor");
                PlayerPrefs.SetInt("RewardedCounter", 2);
                PlayerPrefs.SetInt("AdCounter", 3);
                Time.timeScale = 1f;
            }
            else
            {
                 SceneManager.LoadScene("Scenes/Level "+(level+1));
                 PlayerPrefs.SetInt("RewardedCounter", 2);
                 PlayerPrefs.SetInt("AdCounter", 3);

            }
        }
    }

    public void RequestInterstitial()
    {
#if UNITY_ANDROID
        string interstitial = "ca-app-pub-8966491851338157/3099493717";
#elif UNITY_IPHONE
        string adUnitId = "";
#else
        string adUnitId = "";
#endif
        try
        {
            // Initialize an InterstitialAd.
            this.interstitial = new InterstitialAd(interstitial);
            // Create an empty ad request.
            AdRequest request = new AdRequest.Builder().Build();
            // Load the interstitial with the request.
            this.interstitial.LoadAd(request);
            this.interstitial.OnAdClosed += HandleOnAdClosed;
            

        }
        catch (Exception e)
        {
            Debug.Log(e);
            throw;
        }}
   
    public void HandleOnAdClosed(object sender, EventArgs args)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Scenes/Level "+(level+1));

    }
}
