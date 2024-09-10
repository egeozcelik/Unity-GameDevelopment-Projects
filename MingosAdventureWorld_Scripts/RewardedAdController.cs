using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardedAdController : MonoBehaviour
{
    private RewardedAds videoAd;
    
    void Start()
    {
        videoAd = FindObjectOfType<RewardedAds>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            videoAd.ShowAds();
            Invoke("selfDestroy", 15f);
        }
       

    }

    private void selfDestroy()
    {
        Destroy(gameObject);
    }
}
