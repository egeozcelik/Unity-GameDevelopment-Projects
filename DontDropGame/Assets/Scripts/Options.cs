using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Options : MonoBehaviour
{
    public TextMeshProUGUI point;
    public TextMeshProUGUI point_onDP;
    void Start()
    {
        //  if (SceneManager.GetActiveScene().buildIndex == 0)
        //  {
        //      Debug.Log("xd");
        //      point = null;
        //      point_onDP = null;
        //  }
        // point_onDP.SetText("");
    }

    // Update is called once per frame
    void Update()
    {
        TextPoint();


    }

    void TextPoint()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {

            if (Ball.isDead)
            {
                point.SetText(" ");
                point_onDP.SetText(Ball.point);

            }
            else
            {
                point.SetText(Ball.pts + "." + Ball._pts);

            }
        }else
        {
            point = null;
            point_onDP = null;
        }
    }
    public void onOpeningButton()
    {
        SceneManager.LoadScene(1);
    }
    public void onTryAgainButton()
    {
        SceneManager.LoadScene(1);
    }

    public void onMainMenuButton()
    {
        Debug.Log("xdeeee");
        SceneManager.LoadScene(0);
    }

}
