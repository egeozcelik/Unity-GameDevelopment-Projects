using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MingoMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public Animator animator;
    //motion
    public float speed = 15f;
    private float moveInput;
    public float horizontalMove = 0f;
    bool facingRight;

    //jumping
    public bool isGrounded = false;
    public float checkRadius;
    public float jumpForce;
    private float jumpTimeCounter;
    public float jumpTime;
    private bool isJumping = false;

    //fire
    public GameObject fire;
   public Transform firePoint;
    public float fireSpeed;
    void Start()
    {
        facingRight = true;
        jumpTime = 0.35f;
        rb = GetComponent<Rigidbody2D>();
        //firePoint = transform.Find("firePoint");
    }


    void Update()
    {


        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
            animator.SetBool("IsJumping", true);
            jumpTimeCounter = jumpTime;
            rb.velocity = Vector2.up * jumpForce;
        }
        if (Input.GetKey(KeyCode.Space) && isJumping)
        {
            if (jumpTimeCounter > 0)
            {
                rb.velocity = Vector2.up * jumpForce;

                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
                animator.SetBool("IsJumping", false);
            }

        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
            animator.SetBool("IsJumping", false);

        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            letFire();
        }
        moveInput = Input.GetAxisRaw("Horizontal");
    }
    void letFire()
    {

        GameObject f = Instantiate(fire) as GameObject;
        f.transform.position = firePoint.transform.position;
        f.transform.rotation = firePoint.transform.rotation;
        f.GetComponent<Rigidbody2D>().AddForce(transform.forward * fireSpeed,ForceMode2D.Impulse);
 
    }

    private void FixedUpdate()
    {
        horizontalMove = moveInput * speed;

        rb.velocity = new Vector2(horizontalMove, rb.velocity.y);

        if (horizontalMove > 0 && !facingRight)
        {
            flip();

        }
        else if (horizontalMove < 0 && facingRight)
        {
            flip();
        }
    }
    private void flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
