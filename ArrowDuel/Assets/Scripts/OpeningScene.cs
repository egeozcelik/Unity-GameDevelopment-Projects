using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpeningScene : MonoBehaviour
{
    public static float speed;
    
    public Text continuetext;

    public GameObject loadGame;
    public GameObject newGame;
    void Start()
    {
        PlayerPrefs.SetInt("AdCounter", 2);
        PlayerPrefs.SetInt("RewardedCounter", 1);

        loadGame.SetActive(false);
        newGame.SetActive(false);
        speed = .1f;
        if (PlayerPrefs.GetInt("LoadLevel") != 0)
        {
            loadGame.SetActive(true);
        }
        else
        {
            newGame.SetActive(true);
        }
    }
    void Update()
    {
        transform.Rotate(0f,0f,speed);
    }
}
