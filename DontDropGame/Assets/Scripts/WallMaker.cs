using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMaker : MonoBehaviour
{
    private int wallNumber; //1 power, 2 thorny,
    private float StartTime;
    private float TimeRate;
    public GameObject thornywall;
    public GameObject powerWall;


    void Start()
    {
        StartTime = GetRandomized(25f, 30f);//after how many seconds
        TimeRate = GetRandomized(10f, 30f);//interval time 
        InvokeRepeating("WallChooser", StartTime, TimeRate);
    }

    // Update is called once per frame
    void Update()
    {
        if (Ball.isDead) 
        {
            CancelInvoke("WallChooser");
        }
    }
    void WallChooser()
    {
        wallNumber = Random.Range(1, 3);
        if (wallNumber == 1)
        {
            Instantiate(thornywall);
        }

        if (wallNumber == 2)
        {
            Instantiate(powerWall);
        }
    }

    float GetRandomized(float x, float y)
    {
        return Random.Range(x, y);
    }

}
