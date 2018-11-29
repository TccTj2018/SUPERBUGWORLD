using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Animationboss : MonoBehaviour
{

    public float lookRadius = 10f;
    public Transform target;
    NavMeshAgent agent;
    public Animator animboss;
    public int numero = 0;
    public GameObject prefab;
    public Transform spawpoint;
    public Transform pai;
    void Start()
    {
        animboss = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        StartCoroutine("random");



    }

    // Update is called once per frame
    void Update()
    {

        float distance = Vector3.Distance(target.position, transform.position);
        if (distance <= lookRadius)
        {
            agent.SetDestination(target.position);
            animboss.SetBool("Walking", true);
            animboss.SetBool("AttackDados", true);
            animboss.SetBool("AttackChuva", false);

            if (distance <= agent.stoppingDistance)
            {
                
                animboss.SetBool("Walking",false);
                animboss.SetBool("AttackDados", true);

            }


            
        }
        if (distance > lookRadius)
        {
            animboss.SetBool("AttackChuva", true);
            animboss.SetBool("Idle", false);
            animboss.SetBool("AttackDados", false);
            animboss.SetBool("Walking", false);


        }
        if (numero == 1)
        {
            animboss.SetTrigger("ataque1");
            numero = 0;

        }
        if (numero == 2)
        {
            animboss.SetTrigger("ataque2");
            numero = 0;
            Instantiate(prefab, spawpoint.position, Quaternion.identity);
        }


    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
    IEnumerator random()
    {
        numero = UnityEngine.Random.Range(0, 3);
        yield return new WaitForSeconds(3.0f);
        StartCoroutine("random");
    }
}