using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ruzgareff : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed, 0.0f, 0.0f);
    }
   
}
