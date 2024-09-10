using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody2D bulletBody;
    public float bulletSpeed;
    void Start()
    {
        bulletBody = GetComponent<Rigidbody2D>();
        
        bulletBody.AddForce(new Vector2(bulletSpeed,0),ForceMode2D.Impulse);

        Invoke("SelfDestroy", 3);
    }
    void SelfDestroy()
    {
        Destroy(gameObject);
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "boss")
        {
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "border")
        {
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "rock")
        {
            Destroy(gameObject);
        }
    }
}


