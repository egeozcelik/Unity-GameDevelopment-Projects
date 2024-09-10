using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Can_panel : MonoBehaviour
{
    public static int kalan_can = 3;
    Text can;
    void Start()
    {
        can = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        can.text = "Health: " + kalan_can.ToString() ;
       
    }
}
