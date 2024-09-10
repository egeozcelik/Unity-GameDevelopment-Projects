using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomObjSpawners2 : MonoBehaviour
{
    public GameObject obj;
    public float timeRate;
    
    public float min;
    public float max;
    public float maxSpeed;
    public float minSpeed;

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
        float rnd = UnityEngine.Random.Range(min, max);
        float rndSpeed = UnityEngine.Random.Range(minSpeed, maxSpeed);

        GameObject throwable = Instantiate(obj, new Vector3(1369.4f, rnd, 0), Quaternion.identity);
        throwable.GetComponent<Rigidbody2D>().AddForce(Vector2.left * rndSpeed);

        Destroy(throwable, 5f);
    }
}
