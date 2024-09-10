using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [Tooltip("düsmana ne kadar hasar ver")]
    public float damage;
    
    public int maxEnemyHealth;
    public float currentEnemyHealt;
    internal bool gotDamage;

    Rigidbody2D body2D;

    //external
    public bool DeadToUp;
    Rigidbody2D rb;
    
    
    //dead anim
    public Animator MinionsAnim;
    CircleCollider2D CircleCol;
    bool deadbybullet = false;
   
    Mingo player;
    AudioSource au_Soruce;
    AudioClip ac_dead;
    void Start()
    {
        
        currentEnemyHealt = maxEnemyHealth;
        player = FindObjectOfType<Mingo>();
       
        //dead anim
        rb = GetComponent<Rigidbody2D>();
        CircleCol = GetComponent<CircleCollider2D>();
        body2D = GetComponent<Rigidbody2D>();
        au_Soruce = GetComponent<AudioSource>();
        au_Soruce.volume = 0.01f;
        ac_dead = Resources.Load("SoundEffects/EnemyDead") as AudioClip;
        


    }

    // Update is called once per frame
    void Update()
    {
       
       //dead anim
        if (currentEnemyHealt <= 0)
        {
            transform.gameObject.tag = "Untagged";
            //buraya ölme efekti (particle system)
           
            body2D.constraints = RigidbodyConstraints2D.FreezePositionX;
            MinionsAnim.SetBool("IsCrushed", true);
            rb.gravityScale = DeadToUp ? rb.gravityScale -= Time.deltaTime * 10 : rb.gravityScale += Time.deltaTime * 100  ;
            CircleCol.enabled = true;
            body2D.constraints = RigidbodyConstraints2D.FreezeRotation;
            body2D.constraints = RigidbodyConstraints2D.FreezePositionX;

            Invoke("KillMinion", 1.0f);
        }

    }
    private void FixedUpdate()
    {
        if (deadbybullet)
        {
            DeathByBullet();
           
        }
    }
   
    //GiveDamagetoEnemy
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "PlayerItem" && player.canDamage)
        {

            currentEnemyHealt -= damage;
            au_Soruce.PlayOneShot(ac_dead);
        }
      
        if (other.tag == "PlayerProjectile" )
        {

            Destroy(other.gameObject);
            deadbybullet = true;
            au_Soruce.PlayOneShot(ac_dead);
            au_Soruce.volume = 0.2f;
        }
    }

    private void KillMinion()
    {
        
        Destroy(gameObject);
    }
    void DeathByBullet()
    {


        MinionsAnim.SetBool("IsCrushed", true);
        rb.gravityScale = DeadToUp ? rb.gravityScale -= Time.deltaTime * 100 : rb.gravityScale += Time.deltaTime * 100;
        body2D.constraints = RigidbodyConstraints2D.FreezePositionX;

        CircleCol.enabled = true;
        Invoke("KillMinion", 1.0f);
    }
    #region IdleLegacy
    //  IEnumerator StartLoop()
    //  {
    //      while (true)
    //      {
    //
    //          transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    //          InvokeRepeating("GoRight", 0, 0.1f);
    //          yield return new WaitForSeconds(5.0f);
    //          transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    //          CancelInvoke("GoRight");
    //          InvokeRepeating("GoLeft", 0, 0.1f);
    //          yield return new WaitForSeconds(5.0f);
    //
    //          CancelInvoke("GoLeft");
    //
    //      }
    //  }
    //  private void GoRight()
    //  {
    //      // transform.Rotate(new Vector3(0,180,0));
    //      transform.Translate(0.1f, 0, 0);
    //  }
    //
    //  private void GoLeft()
    //  {
    //      //transform.Rotate(new Vector3(0,180,0));
    //
    //      transform.Translate(-0.1f, 0, 0);
    //  } 
    #endregion






}

