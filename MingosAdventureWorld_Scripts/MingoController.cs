using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MingoController : MonoBehaviour
{
    public static int gold = 0;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void GoldGain()
    {
        gold++;
        Debug.Log(gold);
    }
    
}
