using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slide2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0.75f * Time.deltaTime, 0.075f * Time.deltaTime, 0);   
    }
}
