using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurpleMon : MonoBehaviour
{
    // Start is called before the first frame update
    Mingo player;
    public int damage;

    void Start()
    {
      
        player = FindObjectOfType<Mingo>();
        temp();
    }
    public void temp()
    {
        float rnd = Random.Range(0.5f, 3f);
        Invoke("InitializeLoop", rnd);
    }
   public void InitializeLoop()
    {
        StartCoroutine(StartLoopPM());

    }
    // Update is called once per frame
    void Update()
    {
        
    }
   public  IEnumerator StartLoopPM()
    {
        

            while (true)
            {


                InvokeRepeating("GoUp", 0, 0.01f);
                yield return new WaitForSeconds(0.5f);
                CancelInvoke("GoUp");

                yield return new WaitForSeconds(1.5f);

                //gerikapananMonster

                InvokeRepeating("GoDown", 0, 0.01f);
                yield return new WaitForSeconds(0.501f);
                CancelInvoke("GoDown");
                //kapanıpacilanMonster
                yield return new WaitForSeconds(4f);
            }
        



    }
    private void GoUp()
    {
        // transform.Rotate(new Vector3(0,180,0));
        transform.Translate(0, 0.08f, 0);
    }

    private void GoDown()
    {
        
        //transform.Rotate(new Vector3(0,180,0));

        transform.Translate(0, -0.08f, 0);

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            player.isHurt = true;
            player.currentPlayerHealth -= damage;
        }
    }
    void OnTriggerStay2D(Collider2D other)
    {

        if (other.tag == "Player")
        {
            //ToDo: Oyuncuya zarar ver.
            player.isHurt = false;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            //ToDo: Oyuncuya zarar ver.
            player.isHurt = false;
        }
    }
}
