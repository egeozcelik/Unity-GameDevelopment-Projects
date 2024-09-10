using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turtle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
      StartCoroutine(StartLoop());
       
    }

    // Update is called once per frame
    void Update()
    {
    }
   


    IEnumerator StartLoop()
    {
        while (true)
        {

            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
            InvokeRepeating("GoRight", 0, 0.1f);
        yield return new WaitForSeconds(5.0f);
            transform.localScale = new Vector3(transform.localScale.x * -1,transform.localScale.y,transform.localScale.z); 
            CancelInvoke("GoRight");
        InvokeRepeating("GoLeft", 0, 0.1f);
        yield return new WaitForSeconds(5.0f);

        CancelInvoke("GoLeft");

        }
        


    }



    private void GoRight()
    {
       // transform.Rotate(new Vector3(0,180,0));
        transform.Translate(0.1f, 0, 0);
    }

    private void GoLeft()
    {
        //transform.Rotate(new Vector3(0,180,0));

        transform.Translate(-0.1f, 0, 0);

    }
}
