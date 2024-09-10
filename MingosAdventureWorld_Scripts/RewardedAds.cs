using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds;
using GoogleMobileAds.Api;
using System;
using UnityEngine.UI;

public class RewardedAds : MonoBehaviour
{
    // test:ca-app-pub-3940256099942544/5224354917
    public Button rightButton;
    private RewardBasedVideoAd rAd;
    public string id = "";

    public MingoMobilInput input;

    void Start()
    {
        rAd = RewardBasedVideoAd.Instance;
        input = FindObjectOfType<MingoMobilInput>();

        //reklam izlendiğinde
        rAd.OnAdRewarded += VideoRewarded;
        
        //reklam kapatıldığında
        rAd.OnAdClosed += VideoClosed;
        
        this.RequestAds();
    }
    private void Update()
    {
        
    }
    private void VideoClosed(object sender, EventArgs e)
    {
        Mingo.timeScale = 1.0f;
        rightButton.enabled = true;
        Debug.Log("video closed a geldi");
        bugfixing();

        RequestAds();
    }

    private void RequestAds()
    {
        Debug.Log("RequestAdse geldi ");

        AdRequest request = new AdRequest.Builder().Build();

        this.rAd.LoadAd(request, id);
    }
    private void VideoRewarded(object sender,EventArgs e)
    {
        Debug.Log("VideoRewarded a geldi ");
        Reward();
    }
    public void ShowAds()
    {
        rightButton.enabled = false;
            Debug.Log("video gosterildi");
            this.rAd.Show();
            Mingo.timeScale = 0.0f;
        
    }
    private void Reward()
    {
        rightButton.enabled = true;
        bugfixing();
        Mingo.timeScale = 1.0f;

        Debug.Log("Rewarded a geldi ");


    }
    void bugfixing()
    {
        input.RightDown();
        input.RightUp();
        input.Right();
    }
}
