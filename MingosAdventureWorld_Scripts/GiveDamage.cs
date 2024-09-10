using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveDamage : MonoBehaviour
{
    [Tooltip("düsman bize ne kadar hasar versin")]
    EnemyHealth eh;
    
    public int damage;
    
    
    
    Mingo player;
    void Start()
    {
        player = FindObjectOfType<Mingo>();
        eh = GetComponent<EnemyHealth>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (eh.currentEnemyHealt > 0)
        {
            if (other.gameObject.tag == "Player")
            {
                //ToDo: Oyuncuya zarar ver.
                player.isHurt = true;
                player.currentPlayerHealth -= damage;
            }
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
