using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayedStart : MonoBehaviour
{
    public GameObject countDown;
    public static bool countdownover;


    void Start()
    {
        countdownover = false;
        StartCoroutine("StartDelay");
       
    }
   
    // Update is called once per frame
    void Update()
    {
        
    }
   public IEnumerator StartDelay()
    {
        Time.timeScale = 0;
        float pauseTime = Time.realtimeSinceStartup + 3f;
        while (Time.realtimeSinceStartup < pauseTime)
            yield return 0;
        countDown.gameObject.SetActive(false);
        Time.timeScale = 1;
        countdownover = true;
    }
}
