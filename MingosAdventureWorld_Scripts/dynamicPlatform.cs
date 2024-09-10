using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dynamicPlatform : MonoBehaviour
{
    
    public float speed;
    public float range;
    void Start()
    {
       
        InvokeRepeating("flip", 0.0f, range);
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void FixedUpdate()
    {
        transform.Translate(-speed * Time.deltaTime, 0.0f, 0.0f);
        
    }
    void flip()
    {
        speed = -speed;
    }
  }
