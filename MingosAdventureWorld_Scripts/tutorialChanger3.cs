using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class tutorialChanger3 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (SubtitleHandler.Language)
        {
            gameObject.GetComponent<TextMeshPro>().SetText("Escape the castle");
        }
        else
            gameObject.GetComponent<TextMeshPro>().SetText("Satodan kurtul");
    }

    // Update is called once per frame
    void Update()
    {
        if (SubtitleHandler.Language)
        {
            gameObject.GetComponent<TextMeshPro>().SetText("Escape the castle");
        }
        else
            gameObject.GetComponent<TextMeshPro>().SetText("Satodan kurtul");
    }
}
