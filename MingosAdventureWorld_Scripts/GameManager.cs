using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    Mingo player;

    //ui
    public Slider HealthBar;
    public Text points;
    
    void Start()
    {
      //  Screen.SetResolution(Screen.currentResolution.width / 2, Screen.currentResolution.height / 2, true);
        player = FindObjectOfType<Mingo>();
        HealthBar.maxValue = player.maxPlayerHealth;
    }

    // Update is called once per frame
    void Update()
    {


        

        points.text ="       "+player.currentPoints.ToString();

       


        UpdateUI();
    }
    private void FixedUpdate()
    {

        if (player.isDead)
        {
            Mingo.totalHealth -= 1;
            //gameover paneli aç
            Invoke("Recover", 1f);
        }
    }
    public void RestartGame()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
       

    }
    public void Recover()
    {
        player.RecoverPlayer();
    }
    void UpdateUI()
    {
        HealthBar.value = player.currentPlayerHealth;
        if (player.currentPlayerHealth <= 0)
        {
            HealthBar.minValue = 0;
        }
    }
}
