using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GoogleMobileAds.Api;
using System;

public class ads_controller : MonoBehaviour
{
    private RewardedAd rewardedAd;
    void Start()
    {
        string adUnitId;
#if UNITY_ANDROID
        adUnitId = "ca-app-pub-8966491851338157/2611352368";//
#elif UNITY_IPHONE
            adUnitId = "ca-app-pub-3940256099942544/1712485313";
#else
            adUnitId = "unexpected_platform";
#endif
        MobileAds.Initialize(initStatus => { });
        this.rewardedAd = new RewardedAd(adUnitId);

        // reklam çağırma başarılı ise
        this.rewardedAd.OnAdLoaded += HandleRewardedAdLoaded;
        // reklam çağırma başarısız ise
        this.rewardedAd.OnAdFailedToLoad += HandleRewardedAdFailedToLoad;
        // Reklam gösterilmeye başladığında
        this.rewardedAd.OnAdOpening += HandleRewardedAdOpening;
        // Reklam gösterilmesinde hata olduğunda.
        this.rewardedAd.OnAdFailedToShow += HandleRewardedAdFailedToShow;
        // Called when the user should be rewarded for interacting with the ad.
        this.rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
        // Called when the ad is closed.
        this.rewardedAd.OnAdClosed += HandleRewardedAdClosed;


        AdRequest request = new AdRequest.Builder().Build();
        
        this.rewardedAd.LoadAd(request);
    }
    public void HandleRewardedAdLoaded(object sender, EventArgs args)
    {
        Debug.Log("reklam yuklendi");
    }

    public void HandleRewardedAdFailedToLoad(object sender, AdErrorEventArgs args)
    {
        Debug.Log("reklam yuklenemedi");

    }

    public void HandleRewardedAdOpening(object sender, EventArgs args)
    {
        Debug.Log("reklam acık");

    }

    public void HandleRewardedAdFailedToShow(object sender, AdErrorEventArgs args)
    {
        Debug.Log("reklam gösterilirken hata olustu");

    }

    public void HandleRewardedAdClosed(object sender, EventArgs args)
    {
        Debug.Log("reklam kapattıldı");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    public void HandleUserEarnedReward(object sender, Reward args)
    {
        string type = args.Type;
        double amount = args.Amount;
        Can_panel.kalan_can++;

    }
    public void UserChoseToWatchAd()
    {
        if (this.rewardedAd.IsLoaded())
        {
            this.rewardedAd.Show();
        }
    }
    void Update()
    {
        
    }
}
