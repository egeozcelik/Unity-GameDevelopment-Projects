using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
   //GameObjects start here
   public GameObject box1;
   public GameObject introBox1;
   private int boxShape;
   private float spawnRate = 3f;
   void Start()
    {
        box1 = Resources.Load("box1") as GameObject;
        introBox1 = Resources.Load("boxIntro1") as GameObject;
        
        InvokeRepeating("Spawn",0,spawnRate);
       
    }

    public void Spawn()
    {
         boxShape = Random.Range(0, 2);
       
         if (boxShape == 0 || boxShape == 1)
         {
             Instantiate(box1,new Vector3(11.72351f, -3.439976f,0),Quaternion.identity);
         }
         if (boxShape == 2)
         {
             Instantiate(introBox1, new Vector3(11.72351f, -3.439976f, 0), Quaternion.identity);
         }

    }
    void Update()
    {
        
    }
}
