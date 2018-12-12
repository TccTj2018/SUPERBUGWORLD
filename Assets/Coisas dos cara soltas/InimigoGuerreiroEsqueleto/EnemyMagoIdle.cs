using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMagoIdle : MonoBehaviour {

    public float lookRadius = 10f;
    public Transform target;

    public Animator anim;

    public SystemAudio SA;

    NavMeshAgent agent;

    bool inAtack = false;


    void Start()
    {
        anim = GetComponent<Animator>();
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
        if (distance <= lookRadius)
        {

            if (inAtack == false)
            {
                inAtack = true;
                StartCoroutine("FunctionResetAtack");
                anim.SetBool("ataque", true);
                SA.SetAudio(3, gameObject.transform, true, false, 3);
            }

        }

        if (distance > lookRadius)
        {
            anim.SetBool("ataque", false);
        }
    }

    IEnumerator FunctionResetAtack ()
    {
        yield return new WaitForSeconds(0.9f);
        inAtack = false;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
