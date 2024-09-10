using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class oyuncuOrigin : MonoBehaviour
{
    //ilk 2 level
    public GameObject patlama_efekti;
    
    public GameObject oyuncu_kursunu;
    public Image oyuncu_can_bari;
    public bool isOver = false;
    
    public GameObject game_over;
    float can = 200.0f;
    float simdiki_can = 200.0f;
    float hareket_hizi = -7.0f;
    float kursun_hizi = 500.0f;


    void Start()
    {
        bugFixer.IsOpened = true;



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


        if (simdiki_can <= 0)
        {
            yok_ol();
        }
    }

    public void yok_ol()
    {
        if (bugFixer.IsOpened)
        {
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
