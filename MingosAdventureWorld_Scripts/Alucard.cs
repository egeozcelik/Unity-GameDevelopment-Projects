using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alucard : MonoBehaviour
{
    public Animator animator;

    void Start()
    {
        float rnd = Random.Range(0.5f, 5f);
        Invoke("InitializeLoop", rnd);
    }
    void InitializeLoop()
    {
        StartCoroutine(StartLoopPM());

    }
    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator StartLoopPM()
    {
        while (true)
        {


            InvokeRepeating("GoUp", 0, 0.01f);
            yield return new WaitForSeconds(0.5f);
            animator.SetBool("IsUp", true);
            CancelInvoke("GoUp");


            yield return new WaitForSeconds(2.5f);

            InvokeRepeating("GoDown", 0, 0.01f);
            yield return new WaitForSeconds(0.5f);
            animator.SetBool("IsUp", false);

            CancelInvoke("GoDown");

            yield return new WaitForSeconds(5f);

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
   

}
