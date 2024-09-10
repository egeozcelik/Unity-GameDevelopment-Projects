using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TubesWakeup : MonoBehaviour
{
    public PurpleMon script;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
           // script.control = true;
           // script.temp();
        }
    }
}
