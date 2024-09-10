using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SubtitleHandler : MonoBehaviour
{
    public static bool Language;
    void Start()
    {

        //Language = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void chooseEnglish()
    {
        Language = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void chooseTurkce()
    {
        Language = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
