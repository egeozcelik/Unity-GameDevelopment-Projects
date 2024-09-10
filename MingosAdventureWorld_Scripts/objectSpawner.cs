using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectSpawner : MonoBehaviour
{
    public GameObject obj;
    public float timeRate;
    public float speed;
    public float avg;
    
    public float y;

    void Start()
    {
        InvokeRepeating("spawn", 0f, timeRate);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void spawn()
    {
        //firlat
        float rnd = UnityEngine.Random.Range(transform.position.x - avg, transform.position.x + avg);
       GameObject throwable =  Instantiate(obj, new Vector3(rnd, transform.position.y ,0f), Quaternion.identity);
        throwable.GetComponent<Rigidbody2D>().AddForce(Vector2.down * speed,ForceMode2D.Force); 
       
        Destroy(throwable, 7f);
    }
}
