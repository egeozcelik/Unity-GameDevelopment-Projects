using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocks : MonoBehaviour
{
    //static game control
    public static bool RockActivated;// to get stable the rocks when player have not pushed the button
    //timing offsets
    public float slideRate;
    public float timeRate;

    //speed
    public float speed;
    //positions
    public float Yrate;
    private float UpY;
    private float DownY;
    private float maxX;
    private float minX;
    public float xpos;
    public float ypos;

    void Start()
    {
        RockActivated = false;
        timeRate = 0f;
        slideRate = 0.02f;
        speed = .1f;
        UpY = 10f;
        DownY = -10f;
        Yrate = 5f;
        Offset();
        InvokeRepeating("RockSlide", timeRate, slideRate);
    }

    // Update is called once per frame
    void Update()
    {
        if (!Ball.isDead)
        {
            if (speed < .8f)
            {
                getFaster();

            }
        }
        else
        {
            if (speed >.2f)
            {
                getSlower();
            }
          
        }
        if (transform.position.y > UpY)
        {
            Offset();
        }
    }

    void FixedUpdate()
    {


    }
    void Offset()
    {
        //BURADA KAYALARIN ÖZELLÝKLERÝNÝ DEÐÝÞTÝR(RENK VS)
        if (this.tag == "LeftRock")
        {
            maxX = -2.2f;
            minX = -2.8f;

        }

        if (this.tag == "RightRock")
        {
            maxX = 3.36f;
            minX = 2.14f;
        }
        xpos = Random.Range(minX, maxX);
        ypos = Random.Range(DownY - Yrate, DownY);
        transform.position = new Vector3(xpos, ypos, 0f);
    }
    void getFaster()
    {
        speed += 0.01f * Time.deltaTime;
    }

    void getSlower()
    {
        speed -= 0.5f * Time.deltaTime;
    }
    void RockSlide()
    {
        if (RockActivated)
        {
            transform.Translate(0f, speed, 0f);
        }

    }
}
