using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Health : MonoBehaviour {

    public float health = 100f;
    public Animator animboss;

    public void Start()
    {
        animboss = GetComponent<Animator>();
    }
    public void RemoveHealth(float amount)
    {

        health -= amount;
       ///if (health <//= 0)
       // {
        //    animboss.SetBool("ChrisDeath", true);
            //Destroy(gameObject);

       // }
    }
    public void Update()
    {
        if (health <= 0)
        {
            animboss.SetBool("ChrisDeath", true);
            //Destroy(gameObject);

        }
    }
}