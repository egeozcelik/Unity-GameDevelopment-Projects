using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class SubtitleChanger2 : MonoBehaviour
{
    public TextMeshProUGUI tmp;
    private string subtitle;
    void Start()
    {
        Comic_First();
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
    void Comic_First()
    {
        Invoke("FirstSubtitle_1", 0.41f);//Bu da ne?
        Invoke("SecondSubtitle_1", 3.11f);//Uğursuzlar denizi mi?

        Invoke("ThirdSubtitle_1", 7.18f);//En azından gideceğim yeri biliyorum.
        Invoke("ClearSubtitle", 9.52f);



    }
    
    void FirstSubtitle_1()
    {
        if (SubtitleHandler.Language)
        {
            tmp.SetText("What is that thing?");
        }
        else
            tmp.SetText("Bu da ne?");
    }
    void SecondSubtitle_1()
    {
        if (SubtitleHandler.Language)
        {
            tmp.SetText("Sea of Evil?");
        }
        else
            tmp.SetText("Uğursuzlar denizi mi?");

    }
    void ThirdSubtitle_1()
    {
        if (SubtitleHandler.Language)
        {
            tmp.SetText("At least I know where I have to go now.");
        }
        else
            tmp.SetText("En azından artık gideceğim yeri biliyorum.");

    }
}


