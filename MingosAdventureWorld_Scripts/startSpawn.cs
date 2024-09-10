using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startSpawn : MonoBehaviour
{
    public GameObject spawner1;
    public GameObject spawner2;
    public GameObject general;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            // spawner1.SetActive(true);
            // spawner2.SetActive(true);
            spawner1.GetComponent<randomObjSpawners>().enabled = true;
            spawner2.GetComponent<randomObjSpawners2>().enabled = true;
            general.GetComponent<objectSpawner>().enabled = true;
        }
    }
}
