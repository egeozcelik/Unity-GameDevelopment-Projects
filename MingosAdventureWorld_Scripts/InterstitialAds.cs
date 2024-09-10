using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using GoogleMobileAds;
using System;

public class InterstitialAds : MonoBehaviour
{
    //deneme: ca-app-pub-3940256099942544/1033173712
    private InterstitialAd inter;
    public string idAndroid="";
    public static bool canShowInterstitial;
    void Start()
    {
        canShowInterstitial = false;
        this.request();
     

    }
    private void Update()
    {
        show();
    }
    private void request()
    {
        string id = idAndroid;
        this.inter = new InterstitialAd(id);

        this.inter.OnAdClosed += InterstitialClosed;
        
        AdRequest request = new AdRequest.Builder().Build();
        this.inter.LoadAd(request);
    }
    public void show()
    {
        if (canShowInterstitial)
        {
            Mingo.timeScale = 0f;
           this.inter.Show();
        }
        canShowInterstitial = false;
    }
    private void InterstitialClosed(object sender,EventArgs e)
    {
        Mingo.timeScale = 1f;
        this.request();
    }
}
