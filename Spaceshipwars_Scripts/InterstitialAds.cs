using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using GoogleMobileAds;
using GoogleMobileAds.Api;
using UnityEngine.SceneManagement;

public class InterstitialAds : MonoBehaviour
{
    private InterstitialAd inter;
    public string idAndroid = "";
    public static int control=1; 
     
    void Start()
    {
        if (control % 5 == 0)
        {
            Time.timeScale = 0;
             this.Request();
        }
      
       
    }
   
    
    void Update()
    {
    
    }
    private void Request()
    {
        string id = idAndroid;
        
        this.inter = new InterstitialAd(id);

        // Called when an ad request has successfully loaded.
        this.inter.OnAdLoaded += HandleOnAdLoaded;
        // Called when an ad request failed to load.
        this.inter.OnAdFailedToLoad += HandleOnAdFailedToLoad;
        // Called when an ad is shown.
        this.inter.OnAdOpening += HandleOnAdOpened;
        //
        this.inter.OnAdClosed += InterstitialClosed;


        AdRequest request = new AdRequest.Builder().Build();
        this.inter.LoadAd(request);


    }

    private void HandleOnAdOpened(object sender, EventArgs e)
    {
        Debug.Log("reklam gösterildi");
    }

    private void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs e)
    {
        this.Request();
        if (this.inter.IsLoaded())
        {
            this.inter.Show();
            Debug.Log("reklam tekrar yüklendi ve show a gidildi.");
        }
        Debug.Log("reklam tekrar yüklendi fakat gösterilemedi");
    }

    private void HandleOnAdLoaded(object sender, EventArgs e)
    {
        Debug.Log("reklam yüklendi");
        ShowAD();
    }

    public void ShowAD()
    {

        this.inter.Show();
        control++;
        Debug.Log(control.ToString()); ;
      
    }
    private void InterstitialClosed(object sender,EventArgs e)
    {
        
        Time.timeScale = 1;
    }
      
        
    void nextLevel()
    {
        Scene activeScene = SceneManager.GetActiveScene();
        int buildIndex = activeScene.buildIndex +1;
        SceneManager.LoadScene(buildIndex);
    }
}
