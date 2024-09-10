using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walls : MonoBehaviour
{
    public float wallRate; //how much seconds wall will stay
    void Start()
    {
        wallRate = Random.Range(2f,10f);
        StartCoroutine(Close());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Close()
    {
        yield return new WaitForSeconds(wallRate);
        Destroy(gameObject);
    }


}
