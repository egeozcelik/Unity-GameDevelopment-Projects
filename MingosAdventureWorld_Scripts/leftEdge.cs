using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leftEdge : MonoBehaviour
{
    public bool isEdge;
    void Start()
    {
        isEdge = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Ground")
        {
            isEdge = true;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        {
            isEdge = true;
        }
    }
    void Update()
    {
        
    }
}
