using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class düsman4th : MonoBehaviour
{
    public Transform oyuncu;
    public GameObject patlama_efekti;
    public GameObject VıCTORY_efekti;

    public GameObject dusman_kursunu;
    public Image dusman_can_bari;
    public GameObject next_level;

    float can = 300.0f;
    float simdiki_can = 300.0f;
    float hareket_hizi = -2.3f;
    float kursun_hizi = 570.0f;

    float ates_etme_araligi = 0.2f;
    float ates_etme_zamani = 0.0f;

    // Update is called once per frame
    void Update()
    {
        if (oyuncu)
        {

            if (transform.position.x < oyuncu.position.x)
            {
                transform.Translate(hareket_hizi * Time.deltaTime, 0, 0);

            }
            if (transform.position.x > oyuncu.position.x)
            {
                transform.Translate(-hareket_hizi * Time.deltaTime, 0, 0);

            }


            if (oyuncu.position.x - transform.position.x <= 0.2f)
            {
                if (Time.time >= ates_etme_zamani)
                {
                    ates_et();
                    ates_etme_zamani = Time.time + ates_etme_araligi;
                }
            }
        }


    }
    private void OnCollisionEnter2D(Collision2D meteor)
    {
        if (meteor.gameObject.tag == "meteor")
        {
            meteor.collider.enabled = false;
        }
    }
    private void ates_et()
    {
        GameObject yeni_kursun = Instantiate(dusman_kursunu, transform.position, Quaternion.identity);
        yeni_kursun.GetComponent<Rigidbody2D>().AddForce(Vector2.down * kursun_hizi);

        Destroy(yeni_kursun, 2.0f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "oyuncu_kursunu")
        {
            Destroy(collision.gameObject);
            can_azalt(10.0f);
        }
    }


    private void can_azalt(float deger)
    {
        simdiki_can -= deger;
        dusman_can_bari.fillAmount = simdiki_can / can;


        if (simdiki_can <= 0)
        {
            yok_ol();
        }
    }

    private void yok_ol()
    {
        if (bugFixer.IsOpened)
        {
            Destroy(gameObject);
            GameObject yeni_patlama = Instantiate(patlama_efekti, transform.position, Quaternion.identity);
            Destroy(yeni_patlama, 1.0f);

            Invoke("durdur", 1.0f);
            next_level.SetActive(true);
            Time.timeScale = 1.0f;
            VıCTORY_efekti.SetActive(true);
            bugFixer.IsOpened = false;

        }

    }
    void durdur()
    {
        Time.timeScale = 0.0f;
    }
}
