using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class tutorialChanger : MonoBehaviour
{
  
    void Start()
    {
        
      
    }

    // Update is called once per frame
    void Update()
    {
        if (SubtitleHandler.Language)
        {
            gameObject.GetComponent<TextMeshPro>().SetText("Welcome to Mingo's Adventure World");
        }
        else
            gameObject.GetComponent<TextMeshPro>().SetText("Mingo's Adventure World'e Hoşgeldin");
    }
}
