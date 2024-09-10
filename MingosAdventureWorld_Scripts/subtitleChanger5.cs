using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class subtitleChanger5 : MonoBehaviour
{
    public TextMeshProUGUI tmp;
    private string subtitle;
    void Start()
    {
        Comic_Forth();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Comic_Forth()
    {
        Invoke("FirstSubtitle_4", 0.5f);//whoomp!
        
        Invoke("SecondSubtitle_4", 3.21f);//ouch!
        
       
        Invoke("ThirdSubtitle_4", 6.56f);//eh başardım.Artık son aşamadayım.Ama oraya varmam biraz zaman alıcak.
        
        Invoke("ForthSubtitle_4", 10.23f);//....

        Invoke("FifthSubtitle_5", 16.58f);// UĞURSUZLAR DENİZİ

        Invoke("SixthSubtitle_5", 27.19f);// Acaba arkadaşlarımı gerçekten buldum mu?
        Invoke("SeventhSubtitle_6", 32.0f);// Eğer ordalarsa onları almadan geri dönmeyeceğim!
        

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
    void FirstSubtitle_4()
    {
        if (SubtitleHandler.Language)
        {
            tmp.SetText("WHOOMP!");
        }
        else
            tmp.SetText("WHOOMP!");
    }
    void SecondSubtitle_4()
    {
        if (SubtitleHandler.Language)
        {
            tmp.SetText("OUCH! That was harsh fall.");
        }
        else
            tmp.SetText("UPSS! Sert bir düşüş oldu. ");

    }
    void ThirdSubtitle_4()
    {
        if (SubtitleHandler.Language)
        {
            tmp.SetText("Well, I did it. Now I'm in the final stage. But it seems like it will take a while to get there.");
        }
        else
            tmp.SetText("Pekala başardım. Artık son aşamadayım.Ama oraya varmam biraz zaman alıcak gibi.");

    }
    void ForthSubtitle_4()
    {
        if (SubtitleHandler.Language)
        {
            tmp.SetText(".....");
        }
        else
            tmp.SetText(".....");

    }
    void FifthSubtitle_5()
    {
        if (SubtitleHandler.Language)
        {
            tmp.fontStyle = FontStyles.Italic;
            tmp.SetText("*SEA OF EVIL*");
        }
        else
        {
            tmp.fontStyle = FontStyles.Italic;
            tmp.SetText("*UĞURSUZLAR DENİZİ*");
        }

    }
    void SixthSubtitle_5()
    {
        if (SubtitleHandler.Language)
        {

            tmp.fontStyle = FontStyles.Normal;
            tmp.SetText("Did I really find my friends?");
        }
        else
        {
            tmp.fontStyle = FontStyles.Normal;
            tmp.SetText("Acaba arkadaşlarımı gerçekten buldum mu?");

        }

    }
    void SeventhSubtitle_6()
    {
        if (SubtitleHandler.Language)
        {
            tmp.SetText("If they're there, I won't be back without them!");
        }
        else
            tmp.SetText("Eğer ordalarsa onları almadan geri dönmeyeceğim!");

    }
}
