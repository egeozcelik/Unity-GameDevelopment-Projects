using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class tutorialChanger5 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (SubtitleHandler.Language)
        {
            gameObject.GetComponent<TextMeshPro>().SetText("You need to press the Up button a little longer to double jump");
        }
        else
            gameObject.GetComponent<TextMeshPro>().SetText("Cift ziplamak icin Yukari butonuna biraz daha uzun basman gerek");
    }
}
