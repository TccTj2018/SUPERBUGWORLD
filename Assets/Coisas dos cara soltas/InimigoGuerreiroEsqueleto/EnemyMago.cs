using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMago : MonoBehaviour {

    public SystemAudio systemAudio;

    public float lookRadius = 10f;
    public Transform target;
    NavMeshAgent agent;
    public Animator anim;
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
        yield return new WaitForSeconds(1.5f);
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
                systemAudio.SetAudio(3, gameObject.transform, true);

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
