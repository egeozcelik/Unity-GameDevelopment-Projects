using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowSpawner : MonoBehaviour
{
    public int arrowCount;
    public GameObject Arrows;
    public GameObject rotating;
    private rotating rot;


    void Start()
    {
        rotating = GameObject.FindGameObjectWithTag("TurningCircle");
        rot = rotating.GetComponent<rotating>();
        arrowCount = rot.GetArrowCount(); 
        Arrows = Resources.Load("Arrow1") as GameObject;
        ArrowDestroyer(arrowCount);
    }
    void ArrowDestroyer(int _arrowCount)
    {
        for (int i = _arrowCount + 1; i < 20; i++)
        {
            GameObject.Find("Arrow" + i).GetComponent<Rigidbody2D>().gravityScale = 1f;
            Destroy(GameObject.Find("Arrow" + i),1f);
        }
    }
    public void ExternalArrowDestroyer()
    {
        Destroy(GameObject.Find("Arrow"+arrowCount ));
        arrowCount--;
    }

}
