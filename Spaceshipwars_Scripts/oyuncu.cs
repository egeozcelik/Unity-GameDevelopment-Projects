using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class oyuncu : MonoBehaviour
{
    //other levels
    public AudioSource death;
    public GameObject patlama_efekti;
    public GameObject meteor;
    public GameObject oyuncu_kursunu;
    public Image oyuncu_can_bari;
    public bool isOver = false;

    public GameObject game_over;

    float can = 150.0f;
    float simdiki_can = 150.0f;
    float hareket_hizi = -7.0f;
    float kursun_hizi = 500.0f;



    void Start()
    {
        bugFixer.IsOpened = true;

        float randomTime = UnityEngine.Random.Range(2.0f, 3.0f);
        InvokeRepeating("MeteorFirlat", 3.0f, randomTime);


    }

    void MeteorFirlat()
    {
        if (bugFixer.IsOpened)
        {

            if (!isOver)
            {

                float randomSize = UnityEngine.Random.Range(-2.5f, 2.5f);
                GameObject instantiatedObject = Instantiate(meteor, new Vector3(randomSize, 6.0f, 2), Quaternion.identity);
            }
        }
    }
    // Update is called once per frame
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
            can_azalt(20.0f);
        }
        if (collision.gameObject.tag == "meteor")
        {
            Destroy(collision.gameObject);
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

    private void can_azalt(float deger)
    {
        simdiki_can -= deger;
        oyuncu_can_bari.fillAmount = simdiki_can / can;
        Debug.Log("oyuncu cani:" + simdiki_can.ToString());

        if (simdiki_can <= 0)
        {
            yok_ol();
        }
    }

    public void yok_ol()
    {
        if (bugFixer.IsOpened)
        {

            death.Play();
            isOver = true;
            Destroy(gameObject);

            GameObject yeni_patlama = Instantiate(patlama_efekti, transform.position, Quaternion.identity);
            Destroy(yeni_patlama, 1.0f);

            Invoke("durdur", 1.0f);


            game_over.SetActive(true);
            bugFixer.IsOpened = false;

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


        //yok_ol();

    }
}
