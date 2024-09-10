using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gravityHandler : MonoBehaviour
{
    Mingo player;
    Rigidbody2D rb;
    public float gravityScale; 
    void Start()
    {
        player = FindObjectOfType<Mingo>();
        rb = player.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            rb.gravityScale = gravityScale;
        }
    }
}
