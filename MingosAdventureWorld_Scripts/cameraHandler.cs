using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraHandler : MonoBehaviour
{
    public Camera camera_w;
    public float view;

    private bool wide;

    void Start()
    {
        wide = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (view > camera_w.fieldOfView)
        {
            if (wide)
            {
                getWider();

            }
        }
        if (camera_w.fieldOfView > view)
        {
            wide = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            wide = true;
        }
    }
    void getWider()
    {
        camera_w.fieldOfView += 0.5f;
    }
}
