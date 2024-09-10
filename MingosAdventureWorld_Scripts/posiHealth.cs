using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class posiHealth : MonoBehaviour
{
    Vector3 localscale;
    void Start()
    {
        localscale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        localscale.x = posiScript.posihealth;
        transform.localScale = localscale;
    }
}
