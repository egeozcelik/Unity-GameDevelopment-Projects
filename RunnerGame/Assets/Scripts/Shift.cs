using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shift : MonoBehaviour
{
    public float xPos;
    public float preX;
    public float reX;
    
    void Start()
    {
        
        preX = -10f;
        reX = 11f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-.08f,0f,0f);
        xPos = transform.position.x;
        if (xPos < preX)
        {
            transform.position = new Vector3(reX, -3.47f, 0f);
        }
        
    }

    void OnCollisionEnter(Collision collision)
    {
        
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}
