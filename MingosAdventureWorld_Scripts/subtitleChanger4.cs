using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class subtitleChanger4 : MonoBehaviour
{
    public TextMeshProUGUI tmp;
    private string subtitle;
    void Start()
    {
        Comic_Third();
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
    void Comic_Third()
    {
        Invoke("FirstSubtitle_3", 0.57f);//neler oluyor??
        Invoke("ClearSubtitle", 5.03f);
        Invoke("SecondSubtitle_3", 8.44f);//uğursuzlar denizi bu dağın hemen ardında olması gerekiyor.
        Invoke("ThirdSubtitle_3", 11.39f);//bu dağı aşmam gerek
       
        
    }
    void FirstSubtitle_3()
    {
        if (SubtitleHandler.Language)
        {
            tmp.SetText("What's happening??");
        }
        else
            tmp.SetText("Neler oluyo??");
    }
    void SecondSubtitle_3()
    {
        if (SubtitleHandler.Language)
        {
            tmp.SetText("The Sea of ​​Evil must be right behind this mountain.");
        }
        else
            tmp.SetText("Uğursuzlar denizi bu dağın hemen ardında olması gerekiyor.");

    }
    void ThirdSubtitle_3()
    {
        if (SubtitleHandler.Language)
        {
            tmp.SetText("I have to get over this mountain.");
        }
        else
            tmp.SetText("Bu dağı aşmam lazım.");

    }
  
}
