using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffects : MonoBehaviour
{
    public AudioSource shotsound;
    public AudioSource victorySound;
    public AudioSource GameOverSound;

    public void Shot()
   {
       shotsound.Play();
   }

    public void victory()
    {
        victorySound.Play();
    }

    public void gameover()
    {
        GameOverSound.Play();
    }
}
