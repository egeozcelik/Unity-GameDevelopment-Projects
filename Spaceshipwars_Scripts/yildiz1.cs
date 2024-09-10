using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yildiz1 : MonoBehaviour
{
    SpriteRenderer gorunurluk;
    void Start()
    {
        gorunurluk = GetComponent<SpriteRenderer>();
        float rastgele = Random.Range(0.05f, 0.07f);
        transform.localScale = new Vector3(rastgele, rastgele, 1.0f);
        if (rastgele > 0.06)
        {
            gorunurluk.enabled = false;
        }
        InvokeRepeating("gorunurluk_degistir", 0.0f, 3.0f);
    }
    void gorunurluk_degistir()
    {
        gorunurluk.enabled = !gorunurluk.enabled;
    }


}
