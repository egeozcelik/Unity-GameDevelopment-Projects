using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UIElements;

public class arrow : MonoBehaviour
{
    private Rigidbody2D physics;
   
    [Range(150,200)]   
    public float ArrowSpeed;
    
    public bool hitTheCircle;
    public bool hitTheArrow;

    public static bool IsDead;
    
    public GameObject gm;

    void Start()
    {
        ArrowSpeed = 42.5f;
        physics = GetComponent<Rigidbody2D>();
        gm = GameObject.FindGameObjectWithTag("GameManager");
       
        IsDead = false;
        hitTheCircle = false;
        hitTheArrow = false;
        
    }

    void Update()
    {
        if (!hitTheCircle)
        {
            physics.MovePosition(physics.position + Vector2.up * Time.deltaTime * ArrowSpeed);

        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "TurningCircle")
        {
            hitTheCircle = true;
            transform.SetParent(col.transform);
        }
        if (col.tag == "Arrow")//&& hitTheCircle
        {
            Vibration.Vibrate(500);
            IsDead = true;
            hitTheArrow = true;
            gm.GetComponent<GameManager>().GameOver();
            physics.gravityScale = 2f;
        }
        if (col.tag == "BurningArrow" && hitTheCircle)
        {
            Vibration.Vibrate(500);
            IsDead = true;
            hitTheArrow = true;
            gm.GetComponent<GameManager>().GameOver();
            physics.gravityScale = 2f;
        }
    }
}




    
