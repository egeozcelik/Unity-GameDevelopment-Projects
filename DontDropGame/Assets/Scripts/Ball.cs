using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    //buttons and panels
    public Button tryagainbutton;
    public Button MainMenuButton;
    public GameObject deathPanel;

    //script variables
    public float moveSpeed;
    public float force;
    public static bool isDead;// to slow rocks when die

    //inspector variables
    public Rigidbody2D rb;
    public SpriteRenderer sr;

    //points
    public static float pts;
    public static float _pts;
    public static string point;
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        _pts = 0f;
        pts = 0f;
        isDead = false;
        moveSpeed = 0f;
        rb = GetComponent<Rigidbody2D>();
        force = 100f;
        InvokeRepeating("SetPoints",0f,0.005f);
    }

    // Update is called once per frame
    void Update()
    {
        point = pts + "." + _pts;
       
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Rocks.RockActivated = true;
            moveSpeed = -0.1f;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            Rocks.RockActivated = true;

            moveSpeed = 0.1f;
        }

    }

    void FixedUpdate()
    {
        transform.Translate(moveSpeed, 0f, 0f);
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "RightRock")
        {
            Dead();
        }

        if (collision.tag == "LeftRock")
        {
            Dead();
        }

        if (collision.tag == "ThornyWall")
        {
            Dead();
        }

        if (collision.tag == "PowerWall")
        {

        }

    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name.Equals("LeftWall"))
        {

            moveSpeed = -moveSpeed;

        }

        if (col.gameObject.name.Equals("RightWall"))
        {
            moveSpeed = -moveSpeed;

        }

    }

    void Dead()
    {

        isDead = true;
        sr.enabled = false;
        StartCoroutine(PanelsOn());
    }

    IEnumerator PanelsOn()
    {
        yield return new WaitForSeconds(1f);
        deathPanel.SetActive(true);

        yield return new WaitForSeconds(2f);
        tryagainbutton.gameObject.SetActive(true);
        yield return new WaitForSeconds(.5f);
        MainMenuButton.gameObject.SetActive(true);
    }

    void SetPoints()
    {
        if (Rocks.RockActivated && !isDead)
        {
            _pts += 1f;
            if (_pts > 100f)
            {
                _pts = 0f;
                pts += 1f;
            }
        }
    }

    void getVibrate()
    {
        if (true) // after reach particual point
        {

        }



    }
       

}
