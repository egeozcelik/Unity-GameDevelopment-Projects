using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HayriAnim : MonoBehaviour
{
    EnemyHealth enemyhealt;
    Animator animator;
    void Start()
    {
        enemyhealt = FindObjectOfType<EnemyHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyhealt.currentEnemyHealt <= 0)
        {

        }
    }
}
