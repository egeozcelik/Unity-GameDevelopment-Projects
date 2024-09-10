using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class posiScript : MonoBehaviour
{
    [SerializeField]
    public GameObject fire;
    public UnityEngine.Experimental.Rendering.Universal.Light2D posilight;

    public GameObject yengen;
    public GameObject snake;
    Animator posiAnim;
    Transform firepoint;
    public float fireRate;
    public float nextFire;
    public GameObject healthBar;
    public static float posihealth = 10;
    posiScript ps;
    void Start()
    {
        ps = GetComponent<posiScript>();
        firepoint = transform.Find("firepoint");
        fireRate = 1f;
        nextFire = Time.time;
        posiAnim = GetComponent<Animator>();
        InvokeRepeating("yengenSpawner", 5f, 5f);
        InvokeRepeating("snakeSpawner", 0f, 12f);
    }

    // Update is called once per frame
    void Update()
    {
        CanFire();

        if (posihealth < 0)
        {
            DeathOfPosi();
        }
        if (posilight.intensity < 0.01f)
        {
            CancelInvoke("reducePosiLight");
        }
    }
    void CanFire()
    {
        if (posihealth > 0)
        {

            if (Time.time > nextFire)
            {
                Instantiate(fire, firepoint.position, Quaternion.identity);

                nextFire = Time.time + fireRate;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerProjectile")
        {
            posihealth -= 0.3f;
        }
    }
    void DeathOfPosi()
    {
        InvokeRepeating("reducePosiLight", 0,0.5f);
        healthBar.SetActive(false);
        posiAnim.SetBool("isDead", true);
        CancelInvoke("yengenSpawner");
        CancelInvoke("snakeSpawner");

    }
    void yengenSpawner()
    {
        Instantiate(yengen, new Vector3(1054.59f, -97.78f, 0), Quaternion.identity);

    }
    void snakeSpawner()
    {
        Instantiate(snake, new Vector3(1054.59f, -96.78f, 0), Quaternion.identity);

    }
    void reducePosiLight()
    {
        
        posilight.intensity -= 0.01f;
    }
}
