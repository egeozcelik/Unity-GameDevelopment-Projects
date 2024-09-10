using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    //COMPONENTS
    [SerializeField] Rigidbody2D physics;
    [SerializeField] public LayerMask groundLayer;
    [SerializeField] public Transform feet;
    [SerializeField] Animator CameraAnim;
    [SerializeField] Camera Camera;
    //Variables
    [SerializeField] float speed = 10f;
    [SerializeField] float jumpPower = 45f;
    [SerializeField] int extraJump = 1;
    private int jumpCount = 0;
    private bool isGrounded;
    private float mx;
    private float jumpCoolDown;
    //private bool isDoubleJumped;

    void Start()
    {
        CameraAnim = Camera.GetComponent<Animator>() as Animator;
       // isDoubleJumped = false;
        physics = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        mx = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
        CheckGrounded();
      
    }

    private void Jump()
    {
        if (isGrounded || jumpCount < extraJump)
        {
            physics.velocity = new Vector2(physics.velocity.x, jumpPower);
            jumpCount++;
        }

    }

    void CheckGrounded()
    {
        if (Physics2D.OverlapCircle(feet.position, 0.5f, groundLayer))
        {
            isGrounded = true;
            jumpCount = 0;
            jumpCoolDown = Time.time + .2f;
           

        }
        else if (Time.time < jumpCoolDown)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }
    void FixedUpdate()
    {
        physics.velocity = new Vector2(mx * speed, physics.velocity.y);

    }
}
