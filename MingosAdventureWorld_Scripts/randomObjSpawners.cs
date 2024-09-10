using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomObjSpawners : MonoBehaviour
{
    
    public GameObject obj;
    public float timeRate;
    public float maxspeed;
    public float minspeed;

    public float min;
    public float max;
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
        float rnds = UnityEngine.Random.Range(minspeed, maxspeed);
        GameObject throwable = Instantiate(obj, new Vector3(1230f, rnd, 0), Quaternion.identity);
        throwable.GetComponent<Rigidbody2D>().AddForce(Vector2.right * rnds, ForceMode2D.Force);

        Destroy(throwable, 5.5f);
    }
  
}
