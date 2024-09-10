using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slide3 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0.15f*Time.deltaTime,-0.15f * Time.deltaTime, 0);

    }
}
