using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public Image _progressbar;
    float total = 0.0f;
    void Start()
    {
        InvokeRepeating("progress", 0.1f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void progress()
    {
        float rnd = Random.Range(0.1f, 0.2f);
        total += rnd;
        _progressbar.fillAmount = total;
        if(!(total<1.0f)  )
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
