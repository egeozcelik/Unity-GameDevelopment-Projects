using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;
public class subtitlerChanger3 : MonoBehaviour
{
    public TextMeshProUGUI tmp;
    private string subtitle;
    void Start()
    {
       
        Comic_Second();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void ClearSubtitle()
    {
        if (SubtitleHandler.Language)
        {
            tmp.SetText("");
        }
        else
            tmp.SetText("");
    }
    void Comic_Second()
    {
        Invoke("FirstSubtitle_2", 0.2f);//Valaa Şu şekerlere bak!
       
        Invoke("SecondSubtitle_2", 3.33f);//Cennet böyle bir yer olmalı.
        Invoke("ClearSubtitle", 6.57f);
      
        
    }
    void FirstSubtitle_2()
    {
        if (SubtitleHandler.Language)
        {
            tmp.SetText("VALAA.Look at these Candies.");
        }
        else
            tmp.SetText("VALAA. ŞU ŞEKERLERE DE BİR BAK!");
    }
    void SecondSubtitle_2()
    {
        if (SubtitleHandler.Language)
        {
            tmp.SetText("Heaven must be such a place like these!");
        }
        else
            tmp.SetText("Cennet de böyle bir yer olmalı!");

    }

}
