using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wakeupPosi : MonoBehaviour
{
    posiScript ps;
    void Start()
    {
        ps = FindObjectOfType<posiScript>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            ps.enabled = true;
        }
    }
}
