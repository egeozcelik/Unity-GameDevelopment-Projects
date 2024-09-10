using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class tutorialChanger4 : MonoBehaviour
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
            gameObject.GetComponent<TextMeshPro>().SetText("Reach top of the mountain");
        }
        else
            gameObject.GetComponent<TextMeshPro>().SetText("Dagin zirvesine ulas");
    }
}
