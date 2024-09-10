using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorial : MonoBehaviour
{
    public static bool tutorialOpen;
    public GameObject tutorialPanel;
    public Animator tutorAnim;
    void Start()
    {
        tutorialOpen = true;
    }

   
    void Update()
    {
        
    }

    public void tutorialOff()
    {
        tutorialPanel.SetActive(false);
        tutorialOpen = false;

    }

    public void startTheGame()
    {
        tutorAnim.SetTrigger("tutorial");
    }
}
