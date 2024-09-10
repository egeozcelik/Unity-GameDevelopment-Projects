using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class mainCircle : MonoBehaviour
{

    public GameObject _arrow;
    public GameObject burningArrow;
    public GameObject ArSp;
    public GameObject rotating;
    public GameObject soundEffect;
    private rotating rot;
    private ArrowSpawner _ArSp;
    public int _level;
    private int random;
    public Button hitButton;
    public int burningArrowRate;
    public SoundEffects sfx;
    
    void Start()
    {
        arrow.IsDead = false;
        Button btn = hitButton.GetComponent<Button>();
        btn.onClick.AddListener(throwArrow);
        _level = SceneManager.GetActiveScene().buildIndex;
        burningArrow = Resources.Load("Burning Arrow") as GameObject;
        ArSp = GameObject.FindGameObjectWithTag("ArrowSpawner");
        soundEffect = GameObject.FindGameObjectWithTag("SoundEffect");
        sfx = soundEffect.GetComponent<SoundEffects>();
        _ArSp = ArSp.GetComponent<ArrowSpawner>();
        rotating = GameObject.FindGameObjectWithTag("TurningCircle");
        rot = rotating.GetComponent<rotating>();

        _arrow = Resources.Load("Arrow") as GameObject;

        burningArrowRate = 2;
        if (_level > 20)
        {
            burningArrowRate = 3;
        }

        if (_level > 22)
        {
            burningArrowRate = 5;

        }
        if (_level > 25)
        {
            burningArrowRate = 5;

        }
        if (_level > 27)
        {
            burningArrowRate = 7;

        }
    }
    void Update()
    {
        

    }

    void throwArrow()
    {
        if (!tutorial.tutorialOpen && !(MainMenu.isPanelOpen))
        {
            if (rot.GetArrowCount() > 0 && !arrow.IsDead )
            {
                _ArSp.ExternalArrowDestroyer();
                rot.DecreaseArrowCount();
                CreateArrow();
            }

        }
    }
    void CreateArrow()
    {
        //ALEVLI OKLARIN OLDUGU LEVELLERI DUZENLE

        sfx.Shot();
        if (_level < 13)
        {
            Instantiate(_arrow, transform.position, transform.rotation);
        }
        else if (_level == 13 || _level == 14 || _level == 16)

        {
            Instantiate(burningArrow, transform.position, transform.rotation);

        }
        else
        {
            random = Random.Range(0, 8);
            if (random < burningArrowRate)
            {
                Instantiate(burningArrow, transform.position, transform.rotation);
            }
            else
            {
                Instantiate(_arrow, transform.position, transform.rotation);
            }
        }
    }



}
