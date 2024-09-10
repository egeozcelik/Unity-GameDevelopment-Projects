using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class tutorialChanger2 : MonoBehaviour
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
            gameObject.GetComponent<TextMeshPro>().SetText("Double Jump to crush minions");
        }
        else
            gameObject.GetComponent<TextMeshPro>().SetText("Minyonlari ezmek için çift zipla");
    }
}
