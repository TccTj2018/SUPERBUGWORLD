using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class gilvan : MonoBehaviour {
    public GameObject gilvanObj;
    public GameObject pedra;
    public GameObject pedraSpawn;
    public Rigidbody player;
    public float massValor;
    public GameObject gilvanMao;
    public int numero;
    public float lookRadius = 10f;
    NavMeshAgent agent;
    public Transform target;
    public MoveCharacterGilvan pm;
    Rigidbody rbp;
    public float health;
    public SystemAudio systemAudio;
    private Animator gilvanAnim;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        StartCoroutine("random");
        gilvanAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health < 0f)
        {
            systemAudio.SetAudio(34, gameObject.transform, false, false, 3);
            gilvanAnim.SetTrigger("morrendo");
        }


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
            Debug.Log("Rodck");
            RockThrow();
            systemAudio.SetAudio(31, transform, false, false);
            numero = 0;

        }
        else if (numero == 2)
        {
            systemAudio.SetAudio(30, transform, false, false);
            RockDown();
            numero = 0;

        }
        else if (numero == 3)
        {
            systemAudio.SetAudio(28, transform, false, false);
            pm.GravityAtack();
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
        Debug.Log("CU");
        numero = Random.Range(1, 4);
        yield return new WaitForSeconds(3.0f);
        StartCoroutine("random");
        Debug.Log(numero);
    }

    void RockDown() {
        numero = 0;
        gilvanAnim.SetTrigger("Bater o pé");

        GameObject pedraSpawn = GameObject.Find("pedraSpawn");
        GameObject TempPedra = Instantiate(pedra, pedraSpawn.transform.position, pedraSpawn.transform.rotation) as GameObject;

        Timer(0.2f);
        GameObject pedraSpawn2 = GameObject.Find("pedraSpawn2");
        GameObject TempPedra2 = Instantiate(pedra, pedraSpawn2.transform.position, pedraSpawn2.transform.rotation) as GameObject;

        Timer(0.3f);
        GameObject pedraSpawn3 = GameObject.Find("pedraSpawn3");
        GameObject TempPedra3 = Instantiate(pedra, pedraSpawn3.transform.position, pedraSpawn3.transform.rotation) as GameObject;


        Rigidbody rbp = TempPedra.GetComponent<Rigidbody>();
        rbp.useGravity = true;

    }

   IEnumerator Timer(float tempo)
    {
        yield return new WaitForSeconds(tempo);
    }

    void RockThrow()
    {
        numero = 0;
        Debug.Log("InvocaPedra");
        GameObject TempPedra = Instantiate(pedra, gilvanMao.transform.position, gilvanMao.transform.rotation) as GameObject;
        rbp = TempPedra.GetComponent<Rigidbody>();
        Debug.Log("lançou");
        gilvanAnim.SetTrigger("lancar");
        gilvanMao.transform.LookAt(player.transform.position);

        rbp.AddForce(gilvanMao.transform.forward * 20, ForceMode.Impulse);
        rbp.useGravity = true;
      

    }
}
