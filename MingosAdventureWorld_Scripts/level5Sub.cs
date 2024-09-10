using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;
public class level5Sub : MonoBehaviour
{
    public TextMeshProUGUI tmp;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Invoke("sub1", 0f);
            Invoke("sub2", 5f);
            Invoke("ClearSubtitle", 10f);
        }   
    }
    void sub1()
    {
        if (SubtitleHandler.Language)
        {
            tmp.SetText("Under the sea must be cold and dark..");
        }
        else
            tmp.SetText("Denizin altı soğuk ve karanlık olmalı..");
    }
    void sub2()
    {
        if (SubtitleHandler.Language)
        {
            tmp.SetText("I have to go to the deepest");
        }
        else
            tmp.SetText("En derinine kadar gitmem gerekiyor");
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
}
