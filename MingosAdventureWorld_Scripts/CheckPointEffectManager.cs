using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckPointEffectManager : MonoBehaviour
{
    public GameObject Idle;
    public GameObject PlayerIn;
    public bool playerGotIn;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && !playerGotIn)
        {
            Idle.SetActive(false);
            PlayerIn.SetActive(true);
            playerGotIn = true;
        }
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {

            Idle.SetActive(true);
            PlayerIn.SetActive(false);
        }
    }


}
