using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class subChanger5v2 : MonoBehaviour
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
            Invoke("sub2", 3f);
            Invoke("selfDostroy", 8f);
        }
    }
    void sub1()
    {
        if (SubtitleHandler.Language)
        {
            tmp.SetText("There! My friends are there!");
        }
        else
            tmp.SetText("İşte! Arkadaşlarım orada!");
    }
    void sub2()
    {
        if (SubtitleHandler.Language)
        {
            tmp.SetText("I have to break this chain");
        }
        else
            tmp.SetText("O zinciri kırmam gerek");
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
    void selfDostroy()
    {
        Destroy(gameObject);
    }
  
}
