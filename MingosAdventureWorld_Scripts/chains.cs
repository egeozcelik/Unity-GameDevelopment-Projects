using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class chains : MonoBehaviour
{
    public static float health_chain;
    Rigidbody2D rb;
    public GameObject healthBar;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        health_chain = 10f;

      
    }

    // Update is called once per frame
    void Update()
    {
        if (health_chain < 0.0)
        {
            health_chain = 0.0f;
            rb.gravityScale = 1.0f;
            healthBar.SetActive(false);
            Invoke("nextLevel", 1.5f);    
        }
       


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerProjectile")
        {
            health_chain -= 0.5f;
            Destroy(collision.gameObject);
        }
    }

   
    void nextLevel()
    {
       // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
