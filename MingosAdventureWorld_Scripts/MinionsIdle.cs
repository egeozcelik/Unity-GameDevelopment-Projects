using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionsIdle : MonoBehaviour
{
    //rb
    Rigidbody2D enemyBody2D;

    public float enemySpeed;
    Animator EnemyAnim;
    EnemyHealth enemyHealth;

    //duvarıbulma
    [Tooltip("Karakterin duvara degip degmedigini kontrol eder")]
    bool isGrounded;
    Transform groundCheck;
    const float groundCheckRadius = 0.2f;
    [Tooltip("Duvarın ne olduğunu belirler")]
    public LayerMask groundLayer;
    public bool moveRight;


    public float scaleX;
    public float scaleY;



    //ucurumu bulma
    bool onEdge;
    Transform edgeCheck;


    private void Start()
    {
        enemyBody2D = GetComponent<Rigidbody2D>();
        groundCheck = transform.Find("GroundCheck");
        edgeCheck = transform.Find("EdgeCheck");
        EnemyAnim = GetComponent<Animator>();
        enemyHealth = GetComponent<EnemyHealth>();
    }
    private void Update()
    {
        //check we touch the wall
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        //check we near the space
        onEdge = Physics2D.OverlapCircle(edgeCheck.position, groundCheckRadius, groundLayer);

        if (isGrounded || !onEdge)
        {
            moveRight = !moveRight;

        }
        if (!(enemyHealth.currentEnemyHealt <= 0))
        {

            enemyBody2D.velocity = (moveRight) ? new Vector2(enemySpeed, 0) : new Vector2(-enemySpeed, 0);
            transform.localScale = (moveRight) ? new Vector2(-scaleX, scaleY) : new Vector2(scaleX, scaleY);
        }
    }
}
