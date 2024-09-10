using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class subtitleChanger_ending : MonoBehaviour
{
    public TextMeshProUGUI tmp;
    void Start()
    {
        Comic_Ending();
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
    void Comic_Ending()
    {
       
        Invoke("FirstSubtitle_3", 0.02f);//İşte buradasınız
        Invoke("SecondSubtitle_3", 4.0f);//wrapp!
        Invoke("ThirdSubtitle_3", 7.50f);//OXY! Tüm bunları senin planladığını tahmin etmeliydim.
        Invoke("ForthSubtitle_3", 11.0f);//Şimdi ödeşme vakti.
        Invoke("FifthSubtitle_3", 13.32f);//Beni yenebileceğini mi düşünüyorsun ?
        Invoke("SixthSubtitle_3", 17.36f);//wraaah
        Invoke("SeventhSubtitle_3", 19.40f);//Birdahaki sefere senninle yüzleşicem genç ejder.Şimdilik hoşçaklaın
        Invoke("EightSubtitle_3", 23.35f);//Ah sonunda sizi buldum çocuklar.
        Invoke("NinthSubtitle_3", 27.08f);//Şimdi eve dönme vakti.
        Invoke("ClearSubtitle", 33.5f);
        Invoke("TenthSubtitle_3", 36.0f);//Şimdi eve dönme vakti.

    }
    void FirstSubtitle_3()
    {
        if (SubtitleHandler.Language)
        {
            tmp.SetText("Here you are!");
        }
        else
            tmp.SetText("İşte buradasınız!");
    }
    void SecondSubtitle_3()
    {
        if (SubtitleHandler.Language)
        {
            tmp.SetText("Wrapp!");
        }
        else
            tmp.SetText("Wrapp!");

    }
    void ThirdSubtitle_3()
    {
        if (SubtitleHandler.Language)
        {
            tmp.SetText("OXY! I should have guessed you planned all this.");
        }
        else
            tmp.SetText("OXY! Tüm bunları senin planladığını tahmin etmeliydim.");

    }
    void ForthSubtitle_3()
    {
        if (SubtitleHandler.Language)
        {
            tmp.SetText("Now it's time to pay.");
        }
        else
            tmp.SetText("Şimdi ise ödeşme vakti.");

    }
    void FifthSubtitle_3()
    {
        if (SubtitleHandler.Language)
        {
            tmp.SetText("Do you think you can beat me ? ");
        }
        else
            tmp.SetText("Beni yenebileceğini mi düşünüyorsun ?");

    }
    void SixthSubtitle_3()
    {
        if (SubtitleHandler.Language)
        {
            tmp.SetText("Wraaah");
        }
        else
            tmp.SetText("Wraaah");

    }
    void SeventhSubtitle_3()
    {
        if (SubtitleHandler.Language)
        {
            tmp.SetText("Next time I will face you, young dragon.I have more important things to do for now.");
        }
        else
            tmp.SetText("Birdahaki sefere seninle yüzleşicem genç ejder.Şimdilik yapmam gereken daha önemli şeyler var.");

    }
    void EightSubtitle_3()
    {
        if (SubtitleHandler.Language)
        {
            tmp.SetText("Oh finally I found you guys ..");
        }
        else
            tmp.SetText("Ah sonunda sizi buldum çocuklar..");

    }
    void NinthSubtitle_3()
    {
        if (SubtitleHandler.Language)
        {
            tmp.SetText("Now is the time to go home.");
        }
        else
            tmp.SetText("Şimdi eve dönme vakti.");

    }
    void TenthSubtitle_3()
    {
        if (SubtitleHandler.Language)
        {
            tmp.SetText("The end of the Mingo's Adventure World.");
        }
        else
            tmp.SetText("Mingo's Adventure World'ün Sonu.");

    }

}
