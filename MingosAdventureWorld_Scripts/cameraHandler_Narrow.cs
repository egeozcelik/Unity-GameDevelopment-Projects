using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraHandler_Narrow : MonoBehaviour
{
    public Camera _camera;
    public float _view;
   private   bool narrow = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(narrow)
        {
            _camera.fieldOfView -= 0.5f;
        }
        if(_camera.fieldOfView < _view)
        {
            narrow = false;
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            narrow = true;
        }

    }
}
