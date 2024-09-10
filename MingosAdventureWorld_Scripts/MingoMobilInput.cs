using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MingoMobilInput : MonoBehaviour
{
    Mingo player;
    Rigidbody2D body2d;
    float playerSpeed;
    public static bool onright;
    public static bool onleft;
    void Start()
    {
        player = FindObjectOfType<Mingo>();
        body2d = player.GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        playerSpeed = player.playerSpeed;
        
    }
    public void Jump()
    {
        
        if (player.isGrounded)
        {
            player.Jump();
            player.canDoubleJump = true;
        }
        else if(player.canDoubleJump)
        {
            player.DoubleJump();
            player.canDoubleJump = false;
        }
    }
    public void JumpLegacy()
    {
        if (player.isGrounded)
        {
            player.Jump();
            player.canDoubleJump = true;
        }
    }
    public void DjumpLegacy()
    {
        if (!player.isGrounded && player.canDoubleJump)
        {
            player.DoubleJump();
            player.canDoubleJump = false;
        }
    }
    public void DJump()
    {
       
        if (!player.isGrounded && player.canDoubleJump)
        {
            player.DoubleJump();
            player.canDoubleJump = false;
        }
    }
    public void Fire()
    {
        player.isFire = true;
        player.ShootProjectile();
    }
    public void Left()
    {
        body2d.velocity = new Vector2(-1 * playerSpeed, body2d.velocity.y);

    }
    public void Right()
    {
        body2d.velocity = new Vector2(1 * playerSpeed, body2d.velocity.y);

    }
    public void LeftDown()
    {
        onleft = true;
        // body2d.velocity = new Vector2(-1 *  playerSpeed, body2d.velocity.y);

    }
    public void RightDown()
    {
        onright = true;
        // body2d.velocity = new Vector2(1 * playerSpeed, body2d.velocity.y);

    }
    public void LeftUp()
    {
        onleft = false;
        // body2d.velocity = new Vector2(-1 *  playerSpeed, body2d.velocity.y);

    }
    public void RightUp()
    {
        onright = false;
        // body2d.velocity = new Vector2(1 * playerSpeed, body2d.velocity.y);

    }
}
