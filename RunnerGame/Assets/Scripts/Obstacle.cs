using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] public float force=.0001f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        InvokeRepeating("method",0f,2f);
        rb.AddForce(new Vector2(-force,0f),ForceMode2D.Impulse);

    }
    void Update()
    {
        transform.Rotate(0f,0f,1f);
    

       // transform.Translate(-.1f,0f,0f);
    }
    void method()
    {
          transform.position=new Vector3(7.65f,3.86f,0f);
        rb.AddForce(new Vector2(-force,0f),ForceMode2D.Impulse);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag=="ground")
        {
            rb.AddForce(new Vector2(0f,75f),ForceMode2D.Impulse);
        }
        
    }
}
