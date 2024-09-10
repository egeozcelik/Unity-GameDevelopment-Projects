using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class bugfixer : MonoBehaviour
{
   public  MingoMobilInput input;
    
    void Start()
    {
        input = FindObjectOfType<MingoMobilInput>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            
            input.RightDown();
            input.RightUp();
            input.Right();
        }
    }
}
