using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


[RequireComponent(typeof(Rigidbody2D))]
public class Mingo : MonoBehaviour
{
    //TimeScale;
    public static float timeScale;


    //rigidbody2d
    Rigidbody2D body2d;
    //colliders
    BoxCollider2D box2D;
    CircleCollider2D circle2D;

   


    [Tooltip("Karakterin ne kadar hizli gideceğini belirler")]
    [Range(0, 20)]
    public float playerSpeed;


    //zıplama AddForce ile zıpllatırken 750,addvelocity ile zıplatırken 15
    [Tooltip("Karakterin ne kadar yükseğe zıplayacağını belirler")]
    [Range(0, 30)]  //force ile zıplatıyor  [Range(0, 20)]
    public float jumpPower;

    [Tooltip("Karakterin 2. ne kadar yükseğe zıplayacağını belirler")]
    [Range(0, 30)]
    public float doublejumpPower;
    internal bool canDoubleJump;
    internal bool canDamage;

    //ateşetme
    public bool isFire;


    //karakteri döndürme
    bool facingRight = true;
    public float deadForce = 5;


    [Tooltip("Karakter yerde mi kontrol eder")]
    internal bool isGrounded; //public gibi davranır inspectorda çıkmaz  
    public Transform groundCheck;
    const float GroundCheckRadius = 0.2f;
    [Tooltip("Yerin ne olduğunu belirler")]
    public LayerMask groundLayer;


    //Animator Controller animasyonları kontrol eder
    Animator playerAnimController;

    //Mingonun Cani.
    public static int totalHealth;
    internal int maxPlayerHealth = 100;
    public int currentPlayerHealth;
    internal bool isHurt;

    public SpriteRenderer sr;


    //oyuncuyu öldür
    internal bool isDead;

    //GameManager
    GameManager gameManager;



    //oyuncunun puanları
    internal float currentPoints = 0;
    internal int point = 1;

    //CheckPoint
    public GameObject startposition;
    GameObject checkPoint;


    //sound
    AudioSource auSource;
    AudioClip au_Jump;
    AudioClip au_Djump;
    AudioClip au_Hurt;
    AudioClip au_PickUpCoin;
    AudioClip au_Fire;
    AudioClip au_Recover;
    AudioClip au_Kill;
    AudioClip au_Checkpoint;
    AudioClip au_Walk;


    //fire
    Transform firePoint;
    GameObject bullet;


    public float DeathAltitude;
    void Start()
    {
        timeScale = 1.0f;
        totalHealth = 3;
        transform.position = startposition.transform.position;
        //rigidbody ayarları
        body2d = GetComponent<Rigidbody2D>();
        body2d.freezeRotation = true;
        body2d.mass = 1;
        body2d.gravityScale = 5;
        body2d.collisionDetectionMode = CollisionDetectionMode2D.Continuous;

        //colliderleri al
        box2D = GetComponent<BoxCollider2D>();
        circle2D = GetComponent<CircleCollider2D>();

        sr = GetComponent<SpriteRenderer>();
        //groundcheck i bul
        groundCheck = transform.Find("GroundCheck");


        //Animator u al
        playerAnimController = GetComponent<Animator>();


        //Canı maximum cana eşitle ve GiveDamage scriptini al

        currentPlayerHealth = maxPlayerHealth;

        //GameManager al
        gameManager = FindObjectOfType<GameManager>();

        //Load Sound Effects
        auSource = GetComponent<AudioSource>();
        au_Jump = Resources.Load("SoundEffects/Jump") as AudioClip;
        au_Djump = Resources.Load("SoundEffects/Djump") as AudioClip;
        au_Hurt = Resources.Load("SoundEffects/Hurt") as AudioClip;
        au_PickUpCoin = Resources.Load("SoundEffects/PickUpCoin") as AudioClip;
        au_Fire = Resources.Load("SoundEffects/Fire") as AudioClip;
        au_Recover = Resources.Load("SoundEffects/Recover") as AudioClip;
        au_Kill = Resources.Load("SoundEffects/Kill") as AudioClip;
        au_Checkpoint = Resources.Load("SoundEffects/Checkpoint") as AudioClip;



        //Fire
        firePoint = transform.Find("firePoint");
        bullet = Resources.Load("Bullet") as GameObject;
    }
    void Update()
    {
        Time.timeScale = timeScale;
        UpdateAnimations();
        ReduceHealth();

        if (totalHealth < -250)
        {
            InterstitialAds.canShowInterstitial = true;
            totalHealth = 3;
        }

        isDead = currentPlayerHealth <= 0;
        if (isDead)
        {
           
            KillPlayer();

        }
        if (transform.position.y <= DeathAltitude)
        {
            isDead = true;
        }
          


        //canimiz max canımızdan yüksekse canımızı max cana eşitle
        if (currentPlayerHealth > maxPlayerHealth)
        {
            currentPlayerHealth = maxPlayerHealth;
        }

    }
    // Framerate'den bağımsız olarak çalışır.Fizik ile kodları buraya yaz.
    void FixedUpdate()
    {
        //her 0.2 saniyede ground yerine deyiyor muyum kontrol edecek.
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, GroundCheckRadius, groundLayer);

        float h = Input.GetAxis("Horizontal");
        body2d.velocity = new Vector2(h * playerSpeed, body2d.velocity.y);
      
        
        
        if (MingoMobilInput.onright)
        {
            goRight();
        }
        if (MingoMobilInput.onleft)
        {
            goLeft();
        }
        Flip(h);


        if (isGrounded)
            canDamage = false;
    }
    void EndOfHealths()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //reklam
    }
    void goLeft()
    {

        body2d.velocity = new Vector2(-1f * playerSpeed, body2d.velocity.y);
        Flip(-1f);

    }
    void goRight()
    {
        body2d.velocity = new Vector2(1f * playerSpeed, body2d.velocity.y);
        Flip(1f);


    }


    //karakteri döndürme fonksiyonu
    void Flip(float h)
    {
        if (h > 0 && !facingRight || h < 0 && facingRight)
        {
            facingRight = !facingRight;
            Vector2 theScale = transform.localScale;
            theScale.x *= -1;

            transform.localScale = theScale;
        }
    }

    public void Jump()
    {
        // body2d.AddForce(new Vector2(0, jumpPower)); // give jumppower 750, try it later!
        body2d.velocity = new Vector2(body2d.velocity.x, jumpPower);
        auSource.PlayOneShot(au_Jump);
        //auSource.pitch = Random.Range(0.8f, 1.1f);
        auSource.volume = 0.05f;

    }

    public void DoubleJump()
    {
        body2d.velocity = new Vector2(body2d.velocity.x, doublejumpPower);
        canDamage = true;
        auSource.PlayOneShot(au_Djump);
        // auSource.pitch = Random.Range(0.8f, 1.1f);
        auSource.volume = 0.05f;

        //  body2d.AddForce(new Vector2(0, doublejumpPower),ForceMode2D.Impulse);  dikey yönünde ani bir güç ekler
    }

    //animatoru yenileme fonk
    void UpdateAnimations()
    {
        playerAnimController.SetFloat("VelocityX", Mathf.Abs(body2d.velocity.x));
        playerAnimController.SetBool("isGrounded", isGrounded);
        playerAnimController.SetFloat("VelocityY", body2d.velocity.y);
        playerAnimController.SetBool("isDead", isDead);
        if (isHurt)
        {
            playerAnimController.SetTrigger("isHurt");

        }
        if (isFire)
        {
            playerAnimController.SetTrigger("Fire");
            isFire = false;
        }
    }
    //can azaltma fonksiyonu
    void ReduceHealth()
    {
        if (isHurt && !isDead)
        {


            //currentPlayerHealth -= giveDamage.damage;
            //Buraya karakterin canı azalınca yanıp sönen efekt koy
            isHurt = false;


            //havadayken degersek
            if (facingRight && !isGrounded)
                hurtEffect();

            //body2d.AddForce(new Vector2(-knockBackForce, 500), ForceMode2D.Force);
            else if (!facingRight && !isGrounded)
                hurtEffect();

            // body2d.AddForce(new Vector2(knockBackForce, 500), ForceMode2D.Force);
            //yerdeyken degersek
            if (facingRight && isGrounded)
                hurtEffect();

            // body2d.AddForce(new Vector2(-knockBackForce, 0), ForceMode2D.Force);
            else if (!facingRight && isGrounded)
                hurtEffect();
            // body2d.AddForce(new Vector2(knockBackForce, 0), ForceMode2D.Force);


            if (!isDead)
            {
                auSource.PlayOneShot(au_Hurt);
                auSource.volume = 0.5f;
            }
        }

    }
    //oyuncuyu öldürme
    void KillPlayer()
    {
        // auSource.PlayOneShot(au_Kill);
       // totalHealth = totalHealth - 1;
        isHurt = false;
        body2d.AddForce(new Vector2(0, deadForce), ForceMode2D.Impulse);
        body2d.drag += Time.deltaTime * 20;
        deadForce -= Time.deltaTime * 20;
        //KARAKTERE YANIP SÖNME EFEKTİNİ EKLE//
        body2d.constraints = RigidbodyConstraints2D.FreezePositionX;
        box2D.enabled = false;
        circle2D.enabled = false;


    }
    //recoveri düzenle
    public void RecoverPlayer()
    {
        if (checkPoint != null)
        {
            transform.position = checkPoint.transform.position;
        }
        else
            transform.position = startposition.transform.position;

        deadForce = 5;
        body2d.gravityScale = 5.0f;
        body2d.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        currentPlayerHealth = maxPlayerHealth;
        box2D.enabled = true;
        circle2D.enabled = true;
        body2d.constraints = RigidbodyConstraints2D.None;
        body2d.freezeRotation = true;
        body2d.simulated = true;
        body2d.drag = 0;
        auSource.PlayOneShot(au_Recover);
        auSource.volume = 0.1f;
       

    }

    public void ShootProjectile()
    {
        auSource.PlayOneShot(au_Fire);
        auSource.volume = 0.01f;
        GameObject b = Instantiate(bullet) as GameObject;
        b.transform.position = firePoint.transform.position;
        b.transform.rotation = firePoint.transform.rotation;
        if (transform.localScale.x < 0)
        {
            b.GetComponent<Projectile>().bulletSpeed *= -1;
            b.GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            b.GetComponent<Projectile>().bulletSpeed *= 1;
            b.GetComponent<SpriteRenderer>().flipX = false;

        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Coin")
        {
            auSource.PlayOneShot(au_PickUpCoin);

            other.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            Transform coinEffect;
            currentPoints += point;
            coinEffect = other.gameObject.transform.Find("CoinEffect");
            coinEffect.gameObject.SetActive(true);

            Destroy(other.gameObject, 1);
        }
        if(other.tag == "Enemy")
        {
            this.DoubleJump();
        }
           
        if (other.tag == "Enemy" && isDead)
        {
            Jump();
            auSource.PlayOneShot(au_Kill);
            auSource.volume = 1;

            // auSource.pitch = Random.Range(0.8f, 1.1f);
        }

        if (other.tag == "CheckPoint")
        {
            checkPoint = other.gameObject;
            //Destroy(other.gameObject,1);
            auSource.PlayOneShot(au_Checkpoint);
            auSource.volume = 0.05f;
            CheckPointFixing(other.gameObject);
        }

        if (other.tag == "Chest")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

    }
     void CheckPointFixing(GameObject Chcpt)
    {
        //collideri kapat
        //sryi alpa yap
        CircleCollider2D cc = Chcpt.GetComponent<CircleCollider2D>();
        cc.enabled = false;
        SpriteRenderer sr = Chcpt.GetComponent<SpriteRenderer>();
        sr.color = new Color(1f, 1f, 1f,.5f);

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        for (int i = 1; i < 1000; i++)
        {
            string name1 = "dynamicPlatform1" + " (" + i + ")";
            string name2 = "dynamicPlatform2" + " (" + i + ")";

            if (collision.gameObject.name.Equals("dynamicPlatform1"))
            {
                this.transform.parent = collision.transform;
            }
            if (collision.gameObject.name.Equals("dynamicPlatform2"))
            {
                this.transform.parent = collision.transform;
            }
            if (collision.gameObject.name.Equals(name1))
            {
                this.transform.parent = collision.transform;
            }
            if (collision.gameObject.name.Equals(name2))
            {
                this.transform.parent = collision.transform;
            }

        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        for (int i = 1; i < 1000; i++)
        {
            string name1 = "dynamicPlatform1" + " (" + i + ")";
            string name2 = "dynamicPlatform2" + " (" + i + ")";

            if (collision.gameObject.name.Equals("dynamicPlatform1"))
            {
                this.transform.parent = null;
            }
            if (collision.gameObject.name.Equals("dynamicPlatform2"))
            {
                this.transform.parent = null;
            }
            if (collision.gameObject.name.Equals(name1))
            {
                this.transform.parent = null;
            }
            if (collision.gameObject.name.Equals(name2))
            {
                this.transform.parent = null;
            }

        }
    }

    #region coin_bugfixing
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Coin")
        {
            currentPoints += 0;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Coin")
        {
            currentPoints += 0;
        }
    }

    #endregion

    #region HurtEffect
    void hurtEffect()
    {

        InvokeRepeating("firebird", 0f, 0.08f);
        Invoke("CancelHurtEffect", 1);

    }

    void firebird()
    {
        sr.enabled = !sr.enabled;
        isHurt = false;

    }
    void CancelHurtEffect()
    {
        CancelInvoke("firebird");
        sr.enabled = true;
    } 
    #endregion
}
