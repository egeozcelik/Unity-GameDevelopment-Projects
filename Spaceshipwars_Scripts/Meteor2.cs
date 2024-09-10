using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor2 : MonoBehaviour
{
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
