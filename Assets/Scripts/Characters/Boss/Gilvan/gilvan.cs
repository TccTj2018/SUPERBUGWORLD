using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class gilvan : MonoBehaviour {
    public GameObject gilvanObj;
    public Animator gilvanAnim;
    public GameObject pedra;
    public GameObject pedraSpawn;
    public Rigidbody player;
    public float massValor;
    public GameObject gilvanMao;
    public int numero;
    public float lookRadius = 10f;
    NavMeshAgent agent;
    public Transform target;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        StartCoroutine("random");
    }

    // Update is called once per frame
    void Update()
    {

        float playerDistance = Vector3.Distance(target.position, transform.position);
        if (playerDistance <= lookRadius)
        {
            agent.SetDestination(target.position);
            gilvanAnim.SetBool("running", true);

            if (playerDistance <= agent.stoppingDistance)
            {
                gilvanAnim.SetBool("running", false);
            }

        }
        if (playerDistance > lookRadius)
        {
            gilvanAnim.SetBool("running", false);


        }
        if (numero == 1)
        {
            RockThrow();
            numero = 0;


        }
        else if (numero == 2)
        {
            RockDown();
            numero = 0;

        }
        else if (numero == 3)
        {
            GravityAttack();
            numero = 0;
        }


    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
    IEnumerator random()
    {
        numero = Random.Range(0, 3);
        yield return new WaitForSeconds(3.0f);
        StartCoroutine("random");
    }

    void RockDown() {
        Debug.Log("InvocaPedra");
        gilvanAnim.SetTrigger("Bater o pé");
        Instantiate(pedra, pedraSpawn.transform);
    }

    IEnumerator GravityAttack()
    {
        Debug.Log("gravidade");
        gilvanAnim.SetTrigger("Bater o pé");
        player.SetDensity(player.mass + massValor);
	    yield return new WaitForSeconds(8);
        player.SetDensity(player.mass - massValor);
    }

    void RockThrow()
    {
        Debug.Log("gravidade");
        gilvanAnim.SetTrigger("Bater o pé");
        Instantiate(pedra, gilvanMao.transform);
    }
}
