using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;
using UnityEngine.Experimental.Rendering.Universal;
using System;

public class waterHandler : MonoBehaviour
{
    Mingo player;
    Rigidbody2D rb2d;
    public float jumpPower;
    public float doubleJumpPower;
    public float PlayerSpeed;
    public float mass;
    public float GravityScale;

    public bool waterController;
    void Start()
    {
        waterController = false;
        player = FindObjectOfType<Mingo>();
        rb2d = player.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (waterController)
        {
            inWater();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            waterController = true;
            //     player.jumpPower = jumpPower;
            //     player.doublejumpPower = doubleJumpPower;
            //     player.playerSpeed = PlayerSpeed;
            //     rb2d.mass = mass;
            //     rb2d.gravityScale = GravityScale;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            waterController = true;
            //      player.jumpPower = jumpPower;
            //      player.doublejumpPower = doubleJumpPower;
            //      player.playerSpeed = PlayerSpeed;
            //      rb2d.mass = mass;
            //      rb2d.gravityScale = GravityScale;
        }
    }
    void inWater()
    {
        player.jumpPower = jumpPower;
        player.doublejumpPower = doubleJumpPower;
        player.playerSpeed = PlayerSpeed;
        rb2d.mass = mass;
        rb2d.gravityScale = GravityScale;
    }

}
