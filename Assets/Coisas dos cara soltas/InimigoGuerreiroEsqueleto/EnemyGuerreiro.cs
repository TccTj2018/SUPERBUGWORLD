using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyGuerreiro : MonoBehaviour {

    public float lookRadius = 10f;
    public Transform target;
    NavMeshAgent agent;
    public Animator anim;
    bool inAtack = false;
    

    public SystemAudio systemAudio;


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
    IEnumerator FunctionResetAtack()
    {
        yield return new WaitForSeconds(3.2f);
        inAtack = false;
    }
    private void OnTriggerStay(Collider col)
    {
        if (col.transform.tag == "Player")
        {

            if (inAtack == false)
            {
                inAtack = true;
                StartCoroutine("FunctionResetAtack");
                anim.SetBool("ataque", true);
                systemAudio.SetAudio(1, gameObject.transform, true);

            }

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
