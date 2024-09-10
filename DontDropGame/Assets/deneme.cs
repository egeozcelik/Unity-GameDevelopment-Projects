using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deneme : MonoBehaviour
{
    public Rigidbody2D rb;
    public float yValue;
    public float xValue;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void onTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            
            rb.velocity = new Vector2(xValue, yValue);
            ;
        }
    }
}
