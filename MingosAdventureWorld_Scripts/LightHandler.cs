using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;
using UnityEngine.Experimental.Rendering.Universal;
using System;

public class LightHandler : MonoBehaviour
{
    public UnityEngine.Experimental.Rendering.Universal.Light2D Globallight;
    public UnityEngine.Experimental.Rendering.Universal.Light2D Mingolight;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Mingolight.intensity > 1f)
        {
            CancelInvoke("IncreaseMingoLight");
        }
        if (Globallight.intensity < 0.01f)
        {
            CancelInvoke("ReduceGlobalLight");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
                InvokeRepeating("ReduceGlobalLight", 1f, 0.5f);
                InvokeRepeating("IncreaseMingoLight", 7f, 0.1f);
         
        }
    }
    void ReduceGlobalLight()
    {
        Globallight.intensity = Globallight.intensity - 0.01f;

    }
    void IncreaseMingoLight()
    {

        Mingolight.intensity += 0.01f;
    }
}
