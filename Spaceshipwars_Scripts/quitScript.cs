using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class quitScript : MonoBehaviour
{
    // Start is called before the first frame update
    private Button quitbutton;
    void Start()
    {
        quitbutton = GetComponent<Button>();
        quitbutton.onClick.AddListener(QuitGame);
    }
    private void QuitGame()
    {
        Application.Quit();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
