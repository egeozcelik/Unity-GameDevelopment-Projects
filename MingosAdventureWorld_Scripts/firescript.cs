using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firescript : MonoBehaviour
{
    Mingo player;
    public int damage;
    void Start()
    {
        player = FindObjectOfType<Mingo>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            player.isHurt = true;
            player.currentPlayerHealth -= damage;
        }
    }
    void OnTriggerStay2D(Collider2D other)
    {

        if (other.tag == "Player")
        {
            //ToDo: Oyuncuya zarar ver.
            player.isHurt = false;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            //ToDo: Oyuncuya zarar ver.
            player.isHurt = false;
        }
    }
}
