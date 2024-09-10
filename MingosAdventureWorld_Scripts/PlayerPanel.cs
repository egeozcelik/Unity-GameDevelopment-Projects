using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPanel : MonoBehaviour
{
    Text gold;
    void Start()
    {
        gold = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        gold.text = "Gold : " + MingoController.gold.ToString();
    }
}
