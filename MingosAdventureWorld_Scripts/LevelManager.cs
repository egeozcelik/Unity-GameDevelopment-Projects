using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public Animator animator;
    private int LeveltoLoad;
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            FadeToLevel(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
    public void FadeToLevel(int LevelIndex)
    {
        LeveltoLoad = LevelIndex;
        animator.SetTrigger("FadeOut");
    }
   public void OnFadeComplete()
    {
        SceneManager.LoadScene(LeveltoLoad);
    }
}
