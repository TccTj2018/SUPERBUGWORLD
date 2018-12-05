using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyGuerreiro : MonoBehaviour {

    public float lookRadius = 10f;
    public Transform target;
    NavMeshAgent agent;
    public Animator anim;


    void Start()
    {
       // anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();




    }

    // Update is called once per frame
    void Update()
    {

        float distance = Vector3.Distance(target.position, transform.position);
        if (distance <= lookRadius)
        {
            agent.SetDestination(target.position);
            anim.SetBool("running", true);

            if (distance <= agent.stoppingDistance)
            {
                anim.SetBool("running", false);
            }

        }
        if (distance > lookRadius)
        {
            anim.SetBool("running", false);


        }



    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.transform.tag == "Player")
        {

            anim.SetBool("ataque", true);

        }
    }
    private void OnTriggerExit(Collider col)
    {
        if (col.transform.tag == "Player")
        {

            anim.SetBool("ataque", false);

        }
    }
}
