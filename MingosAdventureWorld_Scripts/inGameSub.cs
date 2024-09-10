using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public class inGameSub : MonoBehaviour
{
    public TextMeshProUGUI tmp;
    public string subtitle;
    public static int subQueue;
    void Start()
    {
        subQueue = 0;
        subtitle = " ";
    }
    

    void Update()
    {
        Invoke("Sub_1", 0f);
        CancelInvoke("Sub_1");
       
    }
   
    public static void Subs()
    {
        
    }
    void clear()
    {
        tmp.SetText("");
    }
   public  void Sub_1()
    {
        if (SubtitleHandler.Language)
        {
           subtitle = "I have to reach the bottom of the sea.. ";
        }
        else
        {
            subtitle = "Denizin en dibine ulaşmalıyım..";
        }
      
    }
    public void Sub_2()
    {
        if (SubtitleHandler.Language)
        {
            subtitle = "it will be cold and dark there.";
        }
        else
            subtitle = "orası soğuk ve karanlık olacak.";
       
        
       
        
    }
    public void Sub_3()
    {
        if (SubtitleHandler.Language)
        {
            tmp.SetText("");
        }
        else
            tmp.SetText("");


        Invoke("clear", 3f);
    }
}
