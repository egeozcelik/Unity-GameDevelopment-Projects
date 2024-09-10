using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class SubtitleChanger : MonoBehaviour
{
    public TextMeshProUGUI tmp;
    private string subtitle;
    private int sceneIndex;
    void Start()
    {
        Comic_Zero();
        




    }


    void Comic_Zero()
    {
        Invoke("FirstSubtitle_0", 1f);//intro
        Invoke("ClearSubtitle", 11f);
        Invoke("SecondSubtitle_0", 23f);//nekadarsıkıcıbirgün

        Invoke("ThirdSubtitle_0", 27f);//ArkadaslarimNerede
        Invoke("ClearSubtitle", 30f);
        Invoke("ForthSubtitle_0", 34f);//Hiçbiri Yok!

        Invoke("FifthSubtitle_0", 38.5f);//NeredeOlduklarınaBakalım


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
    #region Comic_0
    void FirstSubtitle_0()
    {
        if (SubtitleHandler.Language)
        {
            tmp.fontStyle = FontStyles.Italic;
            tmp.SetText("Pollenlake Land. An ordinary day.");
        }
        else
        {
            tmp.fontStyle = FontStyles.Italic;
            tmp.SetText("Polen Gölü Kasabası. Sıradan Bir Gün.");
        }
    }
    void SecondSubtitle_0()
    {
        if (SubtitleHandler.Language)
        {
            tmp.fontStyle = FontStyles.Normal;
            tmp.SetText("Mingo:What a boring day. Huh..");
        }
        else
        {
            tmp.fontStyle = FontStyles.Normal;

            tmp.SetText("Mingo:Ne kadar sıkıcı bir gün.");
        }
    }
    void ThirdSubtitle_0()
    {
        if (SubtitleHandler.Language)
        {
            tmp.SetText("Where are my friends?");
        }
        else
            tmp.SetText("Arkadaşlarım nerede?");

    }
    void ForthSubtitle_0()
    {
        if (SubtitleHandler.Language)
        {
            tmp.SetText("They are gone.");
        }
        else
            tmp.SetText("Hiçbiri yok!");

    }
    void FifthSubtitle_0()
    {
        if (SubtitleHandler.Language)
        {
            tmp.SetText("Let's see what's going on outside!");
        }
        else
            tmp.SetText("Dışarıda neler olup bitiyor bir bakalım!");

    }
    #endregion
   

}
