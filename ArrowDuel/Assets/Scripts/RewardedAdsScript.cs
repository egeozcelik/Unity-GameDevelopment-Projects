using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using GoogleMobileAds.Api;
using System;


public class RewardedAdsScript : MonoBehaviour
{
    private RewardedAd rewardedAd;

    public Button RestartButton;
    public Button NextLevelButton;

    public Image NextLevelImage;
     
    private int level;
    public string adUnitId;
    public void Start()
    {

#if UNITY_ANDROID
        adUnitId = "ca-app-pub-8966491851338157/9389569895";
#elif UNITY_IPHONE
            adUnitId = "ca-app-pub-3940256099942544/1712485313";
#else
            adUnitId = "unexpected_platform";
#endif

        level = SceneManager.GetActiveScene().buildIndex;
       
        Button _RestartButton = RestartButton.GetComponent<Button>();
       
        
        initialize();
       
        _RestartButton.onClick.AddListener(showAds);
        
        

    }

    public void initialize()
    {
        NextLevelButton.enabled = false;
        NextLevelImage.enabled = false;


        this.rewardedAd = new RewardedAd(adUnitId);

        // Called when an ad request has successfully loaded.
        this.rewardedAd.OnAdLoaded += HandleRewardedAdLoaded;
        // Called when an ad request failed to load.
        this.rewardedAd.OnAdFailedToLoad += HandleRewardedAdFailedToLoad;
        // Called when an ad is shown.
        this.rewardedAd.OnAdOpening += HandleRewardedAdOpening;
        // Called when an ad request failed to show.
        this.rewardedAd.OnAdFailedToShow += HandleRewardedAdFailedToShow;
        // Called when the user should be rewarded for interacting with the ad.
        this.rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
        // Called when the ad is closed.
        this.rewardedAd.OnAdClosed += HandleRewardedAdClosed;

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the rewarded ad with the request.
        this.rewardedAd.LoadAd(request);



    }
    public void HandleRewardedAdLoaded(object sender, EventArgs args)
    {
        NextLevelButton.enabled = true;//HERE
        NextLevelImage.enabled = true;

        Time.timeScale = 1f;

    }

    public void HandleRewardedAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        NextLevelButton.enabled = false;//HERE
        NextLevelImage.enabled = false;

        Debug.Log("yuklenmedi");
        Time.timeScale = 1f;
    }




    public void HandleRewardedAdOpening(object sender, EventArgs args)
    {
        Time.timeScale = 1f;
    }


    public void HandleRewardedAdFailedToShow(object sender, AdErrorEventArgs args)
    {
        Time.timeScale = 1f;
      
        SceneManager.LoadScene("Scenes/level " + (level));

    }

    public void HandleRewardedAdClosed(object sender, EventArgs args)
    {
        Time.timeScale = 1f;
        
        this.rewardedAd.OnUserEarnedReward -= HandleUserEarnedReward;
        this.rewardedAd.OnAdClosed -= HandleRewardedAdClosed;

        SceneManager.LoadScene("Scenes/level " + (level + 1));

    }

    public void HandleUserEarnedReward(object sender, Reward args)
    {
        this.rewardedAd.OnUserEarnedReward -= HandleUserEarnedReward;
        this.rewardedAd.OnAdClosed -= HandleRewardedAdClosed;
      
        Time.timeScale = 1f;
        
        SceneManager.LoadScene("Scenes/level " + (level + 1));

    }
    public void UserChoseToWatchAd()
    {
        if (!(this.rewardedAd.IsLoaded()))
        {
            initialize();
        }


        if (this.rewardedAd.IsLoaded())
        {
            this.rewardedAd.Show();
            PlayerPrefs.SetInt("AdCounter", 3);
        }
    }

    public void showAds()
    {

        if (PlayerPrefs.GetInt("RewardedCounter") < 0)
        {

            if (this.rewardedAd.IsLoaded())
            {

                Time.timeScale = 1f;
               
                this.rewardedAd.Show();
                
                PlayerPrefs.SetInt("RewardedCounter", 2);
                PlayerPrefs.SetInt("AdCounter", 3);

            }
            else
            {
                SceneManager.LoadScene("Scenes/level " + level);//HERE

            }
        }
        else
        {
            Time.timeScale = 1f;

            SceneManager.LoadScene("Scenes/level " + level);
        }
    }


}