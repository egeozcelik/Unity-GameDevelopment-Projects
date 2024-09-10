using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Panels


    //GameObjects


    //Variables


    // Scripts

    void Start()
    {
        //InitializeTime();
    }

    private void InitializeTime()
    {
        WaitForSeconds(3f);
        InvokeRepeating("TimeSlower", 0f, .2f);
        InvokeRepeating("TimeFaster", 2.5f, .1f);
       
    }


    public void faster()
    {
        InvokeRepeating("TimeFaster", 2.5f, .1f);

    }
    public void slower()
    {
        InvokeRepeating("TimeSlower", 0f, .2f);

    }

    void Update()
    {

    }

    void TimeFaster()
    {
        if (Time.timeScale < 1f)
        {
            Time.timeScale += .1f;
            Debug.Log(Time.timeScale);
        }
        else
            CancelInvoke("TimeFaster");
    }
    void TimeSlower()
    {
        if (Time.timeScale > .2f)
        {
            Time.timeScale -= .1f;
          
        }
        else
            CancelInvoke("TimeSlower");

    }

    IEnumerator WaitForSeconds(float Sec)
    {
        yield return new WaitForSeconds(Sec);
    }

}

