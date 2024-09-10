using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meteor : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("motion", 0, 0.01f);
    }

    // Update is called once per frame
    void Update()
    {

      
        
    }
    void motion()
    {
        if (DelayedStart.countdownover)
        {

            transform.Translate(0, -0.09f, 0);
        }

    }

}
