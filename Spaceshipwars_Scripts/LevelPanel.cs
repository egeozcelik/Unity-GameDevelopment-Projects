using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

using UnityEngine.SceneManagement;
using TMPro;

public class LevelPanel : MonoBehaviour
{
    public int levelid;
    Text levelText;
    void Start()
    {
        Scene getlevel = SceneManager.GetActiveScene();
        levelid = getlevel.buildIndex;
        levelText = GetComponent<Text>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        levelText.text = "Level: " + levelid.ToString();
    }
}
