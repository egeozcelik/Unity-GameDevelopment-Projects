using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class subChanger5v3 : MonoBehaviour
{
    public TextMeshProUGUI tmp;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Invoke("sub1", 0f);
            
            Invoke("ClearSubtitle", 5f);
        }
    }
    void sub1()
    {
        if (SubtitleHandler.Language)
        {
            tmp.SetText("Watch Out For Rock Fragments!");
        }
        else
            tmp.SetText("Kaya Parçalarına Dikkat Et!");
    }
    void ClearSubtitle()
    {
        if (SubtitleHandler.Language)
        {
            tmp.SetText("");
        }
        else
            tmp.SetText("");
    }
}
