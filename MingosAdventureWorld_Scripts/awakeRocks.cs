using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class awakeRocks : MonoBehaviour
{
    public GameObject os;
     objectSpawner osScript;
    void Start()
    {
        osScript = os.GetComponent<objectSpawner>();

    }

    // Update is called once per frame
    void Update()
    {
      
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Destroy(os);

        }
    }
}
