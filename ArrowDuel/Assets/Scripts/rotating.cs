using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using UnityEngine.UI;

public class rotating : MonoBehaviour
{
    public int level;
    public int rnd;
    public float speed;
    public float Health;
    public float arrowDamage;
    public float rotationCoefficient;


    [Range(0, 19)]
    public int arrowCount;
    public Text score;
    public Text levelonpanel;
    public Text ScoreOnDeathPanel;

    public GameObject gm;
    public GameObject WonPanel;
    
    public Animator Anim;
    public Animator textAnim;
    
    //particular effects
    public GameObject DarkLowEffect;
    public GameObject DarkMediumEffect;
    public GameObject DarkHighEffect;
    public GameObject OrangeHighEffect;
    public GameObject RedHighEffect;
   
    
    bool isHigh = true;
    bool isMedium = true;
    bool isLow = true;

    //SFX
    public GameObject soundEffect;
    public SoundEffects sfx;


    //bug fixing
    public GameObject mainCircle;
    public mainCircle mc;

    void Start()
    {
        soundEffect = GameObject.FindGameObjectWithTag("SoundEffect");
        sfx = soundEffect.GetComponent<SoundEffects>();


        DarkHighEffect = Resources.Load("DarkHighEffect") as GameObject;
        DarkMediumEffect = Resources.Load("DarkMediumEffect") as GameObject;
        DarkLowEffect = Resources.Load("DarkLowEffect") as GameObject;
        RedHighEffect = Resources.Load("RedHighEffect") as GameObject;
        OrangeHighEffect = Resources.Load("OrangeHighEffect") as GameObject;

        mainCircle = GameObject.FindGameObjectWithTag("MainCircle");
        mc = mainCircle.GetComponent<mainCircle>();

        gm = GameObject.FindGameObjectWithTag("GameManager");
        level = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("LoadLevel", level);
        rotationCoefficient = 4.3f; //8.5f
        Health = 101f;
        arrowDamage = 1f;
        speed = 145f + level * rotationCoefficient;
        levelonpanel.text = level+"/30";
        ScoreOnDeathPanel.text = "level " + level;

        if (level > 10)
        {
            InvokeRepeating("InverseSpeed", 0, 3f);
        }
        score.text = "";
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Arrow")
        {
            if (arrowCount < 1)
            {
                StartCoroutine(nextLevel());

            }
            Anim.SetTrigger("hitCircle");
            textAnim.SetTrigger("textAnim");

        }
        if (col.tag == "BurningArrow")
        {
            if (arrowCount < 1)
            {
                StartCoroutine(nextLevel());

            }
            Anim.SetTrigger("hitCircle");
            textAnim.SetTrigger("textAnim");

            //yanma efekti
            InvokeRepeating("Burn", 0f, 2f);
        }
    }
    void Update()
    {

       

        if (Health < 0)
        {
            gm.GetComponent<GameManager>().GameOver();
            mc.enabled = false;
        }

        transform.Rotate(0, 0, speed * Time.deltaTime);
        score.text = arrowCount + "";

    } 
    void turn()
    {
        transform.Rotate(0, 0, speed * Time.deltaTime);

    }
    IEnumerator nextLevel()
    {
        sfx.victory();
        yield return new WaitForSeconds(.7f);
        if (!arrow.IsDead)
        {
           
            WonPanel.SetActive(true);
        }
    }
    void InverseSpeed()
    {
        rnd = Random.Range(0, 10);
        if (rnd < 2)
        {
            speed *= -1;
        }
    }
    void Burn()
    {
        Health -= arrowDamage;

        if (Health < 100 && isLow)
        {
            Instantiate(DarkLowEffect, new Vector3(0f, 2f, 0f), Quaternion.identity);
            DarkLowEffect.SetActive(true);
            isLow = false;
        }

        if (Health < 75 && isMedium)
        {
            DarkLowEffect.SetActive(false);
            Instantiate(DarkMediumEffect, new Vector3(0f, 2f, 0f), Quaternion.identity);
            DarkMediumEffect.SetActive(true);
            isMedium = false;
        }

        if (Health < 50 && isHigh)
        {
            DarkMediumEffect.SetActive(false);
            Instantiate(DarkHighEffect, new Vector3(0f, 2f, 0f), Quaternion.identity);
            Instantiate(RedHighEffect, new Vector3(0f, 2f, 0f), Quaternion.identity);
            Instantiate(OrangeHighEffect, new Vector3(0f, 2f, 0f), Quaternion.identity);
            isHigh = false;
        }
    }
    public void DecreaseArrowCount()
    {
        arrowCount--;
    }
    public int GetArrowCount()
    {
        return arrowCount;
    }
}



