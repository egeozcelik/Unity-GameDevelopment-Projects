using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class tmPro : MonoBehaviour
{
    private TextMeshProUGUI text;
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Can_panel.kalan_can <= 0)
        {
            Invoke("changeText", 1.0f);
        }
    }
    void changeText()
    {
            text.text = "Restart";

    }
}
