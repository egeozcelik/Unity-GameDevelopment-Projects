using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MingoInput : MonoBehaviour
{

    Mingo player;
    
   
    

    void Start()
    {
        player = GetComponent<Mingo>();
      
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && player.isGrounded)
        {
            player.Jump();
            player.canDoubleJump = true;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && !player.isGrounded && player.canDoubleJump)
        {
            player.DoubleJump();
            player.canDoubleJump = false;
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            player.isFire = true;
            player.ShootProjectile();  
        }
    }
 
}
