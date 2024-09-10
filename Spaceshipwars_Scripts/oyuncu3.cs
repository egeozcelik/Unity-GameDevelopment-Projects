using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class oyuncu3 : MonoBehaviour
{
    // level 10 & 15
    public AudioSource death33;
    public GameObject patlama_efekti;
    public GameObject oyuncu_kursunu;
    public GameObject meteor;
    public bool isOver = false;
    public Image oyuncu_can_bari;
    public GameObject game_over;
    public GameObject victory;
    float can = 300.0f;
    public float simdiki_can = 300.0f;
    float hareket_hizi = -7.0f;
    float kursun_hizi = 500.0f;



    void Start()
    {
        bugFixer.IsOpened = true;

        float randomTime = UnityEngine.Random.Range(0.5f, 1.5f);
        InvokeRepeating("MeteorFirlat", 3.0f, randomTime);

    }
    void MeteorFirlat()
    {
        if (bugFixer.IsOpened)
        {

            if (!isOver)
            {

                float randomSize = UnityEngine.Random.Range(-2.8f, 2.8f);
                GameObject instantiatedObject = Instantiate(meteor, new Vector3(randomSize, 6.0f, 2), Quaternion.identity);
            }
        }
    }
    void Update()
    {


        float tus_tespiti = Input.GetAxis("Horizontal");
        transform.Translate(0, tus_tespiti * Time.deltaTime * hareket_hizi, 0);


        if (Input.GetKeyDown(KeyCode.Space))
        {
            ates_et();
        }



    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "dusman_kursunu")
        {
            Destroy(collision.gameObject);
            can_azalt(60.0f);
        }
        if (collision.gameObject.tag == "meteor")
        {
            Destroy(collision.gameObject);
            yok_ol();
        }
    }

    private void can_azalt(float deger)
    {
        simdiki_can -= deger;
        oyuncu_can_bari.fillAmount = simdiki_can / can;


        if (simdiki_can <= 0)
        {
            yok_ol();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "meteor")
        {
            Destroy(collision.gameObject);
            yok_ol();
        }
    }
    public void yok_ol()
    {
        if (bugFixer.IsOpened)
        {
            death33.Play();
            isOver = true;
            Destroy(gameObject);

            GameObject yeni_patlama = Instantiate(patlama_efekti, transform.position, Quaternion.identity);
            Destroy(yeni_patlama, 1.0f);

            Invoke("durdur", 1.0f);

            game_over.SetActive(true);
            bugFixer.IsOpened = false;

            Time.timeScale = 1.0f;
        }

    }

    void durdur()
    {

        Time.timeScale = 0.0f;

    }


    private void ates_et()
    {
        GameObject yeni_kursun = Instantiate(oyuncu_kursunu, transform.position, Quaternion.identity);
        yeni_kursun.GetComponent<Rigidbody2D>().AddForce(Vector2.up * kursun_hizi);



        Destroy(yeni_kursun, 2.0f);




    }
}
