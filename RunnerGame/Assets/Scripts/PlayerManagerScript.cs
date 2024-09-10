using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManagerScript : MonoBehaviour
{
    //COMPONENTS

    [SerializeField] Rigidbody2D physics;
    [SerializeField] BoxCollider2D collider2d;
    [SerializeField] GameManager gm;
    [SerializeField] Animator deadPicAnim;
    [SerializeField] CapsuleCollider2D Collider2d;

    //Variables
    public float runSpeed = 10.0f;


    // Start is called before the first frame update
    void Start()
    {
        physics = GetComponent<Rigidbody2D>();
      
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        
    }
     void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Box")
        {
            Zort();
        }
       
    }

     void Zort()
    {
        Debug.Log("dead"); 
        deadPicAnim.SetTrigger("DeadPicture");
        collider2d.enabled = false;
    }

  
}