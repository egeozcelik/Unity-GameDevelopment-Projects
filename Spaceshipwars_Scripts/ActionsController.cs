using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class ActionsController : MonoBehaviour
{
    float ates_etme_araligi = 0.2f;
    float ates_etme_zamani = 0.0f;

    public GameObject oyuncu;
    float LhareketHizi = 4.0f;
    float RhareketHizi = -4.0f;
    public float kursun_hizi = 500.0f;
    public GameObject oyuncu_kursunu;
    bool kontrolsag;
    bool kontrolsol;
    bool kontrolates;

    public void Fire()
    {
        if (oyuncu)
        {

            if (Time.time >= ates_etme_zamani)
            {
                GameObject yeni_kursun = Instantiate(oyuncu_kursunu, oyuncu.transform.position, Quaternion.identity);

                yeni_kursun.GetComponent<Rigidbody2D>().AddForce(Vector2.up * kursun_hizi);

                Destroy(yeni_kursun, 2.0f);
                ates_etme_zamani = Time.time + ates_etme_araligi;
            }

        }
    }
    void Start()
    {

    }
    public void atesbasildi()
    {
        kontrolates = true;
    }
    public void atescekildi()
    {
        kontrolates = false;
    }
    public void sagabasildi()
    {
        kontrolsag = true;
    }
    public void sagacekildi()
    {
        kontrolsag = false;
    }
    public void solabasildi()
    {
        kontrolsol = true;
    }
    public void solacekildi()
    {
        kontrolsol = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (kontrolsag)
        {
            if (oyuncu)
            {

                oyuncu.transform.Translate(0, RhareketHizi * Time.deltaTime, 0);
            }
        }
        if (kontrolsol)
        {
            if (oyuncu)
            {

                oyuncu.transform.Translate(0, LhareketHizi * Time.deltaTime, 0);
            }
        }
        if (kontrolates && oyuncu)
        {
            if (Time.time >= ates_etme_zamani)
            {
                GameObject yeni_kursun = Instantiate(oyuncu_kursunu, oyuncu.transform.position, Quaternion.identity);
                yeni_kursun.GetComponent<Rigidbody2D>().AddForce(Vector2.up * kursun_hizi);

                Destroy(yeni_kursun, 2.0f);
                ates_etme_zamani = Time.time + ates_etme_araligi;

            }
        }
    }
    public void GoLeft()
    {
        if (oyuncu)
        {

            oyuncu.transform.Translate(0, LhareketHizi * Time.deltaTime, 0);
        }
    }
    public void GoRight()
    {
        if (oyuncu)
        {

            oyuncu.transform.Translate(0, RhareketHizi * Time.deltaTime, 0);
        }
    }
}
