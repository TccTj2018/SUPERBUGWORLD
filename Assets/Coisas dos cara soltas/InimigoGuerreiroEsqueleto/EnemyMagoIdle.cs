using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMagoIdle : MonoBehaviour {

    public float lookRadius = 10f;
    public Transform target;
    
    public Animator anim;


    void Start()
    {
        anim = GetComponent<Animator>();
       




    }

    // Update is called once per frame
    void Update()
    {

        float distance = Vector3.Distance(target.position, transform.position);
        if (distance <= lookRadius)
        {
            
            anim.SetBool("ataque", true);

            

        }
        if (distance > lookRadius)
        {
            anim.SetBool("ataque", false);


        }



    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
