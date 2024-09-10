using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grounded : MonoBehaviour
{
    GameObject Player;
   

    void Start()
    {
        Player = gameObject.transform.parent.gameObject;
        
    }

    
    void Update()
    {
        
  
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "SimpleGround")
        {
            Player.GetComponent<MingoMovement>().isGrounded = true;

        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "SimpleGround")
        {
            Player.GetComponent<MingoMovement>().isGrounded = false;

     
        }
    }
}
