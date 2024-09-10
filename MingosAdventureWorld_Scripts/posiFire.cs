using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class posiFire : MonoBehaviour
{
    public float speed;
    Rigidbody2D rb2d;
  
    Vector2 moveDirection;
    Mingo player;
    public int damage;
    void Start()
    {
       
        player = FindObjectOfType<Mingo>();
        rb2d = GetComponent<Rigidbody2D>();
        moveDirection = (player.transform.position - transform.position).normalized * speed;
        rb2d.velocity = new Vector2(moveDirection.x, moveDirection.y);
        Destroy(gameObject, 9f);
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            player.isHurt = true;
            // player.currentPlayerHealth -= damage;
            player.currentPlayerHealth -= damage;
            Destroy(gameObject);
        }
    }
    void Update()
    {
        
    }
}
