using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inGameSubChanger : MonoBehaviour
{
    
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
            inGameSub.subQueue += 1;

        }
    }
}
