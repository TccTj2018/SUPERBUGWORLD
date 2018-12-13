using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(BoxCollider))]
public class EnemyMoto : MonoBehaviour {

    private GameObject Player;
    private NavMeshAgent nav;
    private Animator Anim;
    public float health = 100f;
    public float damageEnemy = 30;
    public float _Life = 100; 
    private GameObject Mototauro;
    public SystemAudio sa;


    void Start() {
        Player = GameObject.FindWithTag("Player");
        nav = GetComponent<NavMeshAgent>();
        StartCoroutine("Rotina");
        StartCoroutine("NewRotina");
        Anim = GetComponent<Animator>();
        Anim.SetInteger("Ataque", 1);
    }

    void Update()
    {
        nav.destination = Player.transform.position;
        if (Vector3.Distance(transform.position, Player.transform.position) < 1.5f)
        {
            Rotina();
            if (_Life <= 0)
            {
                _Life = 0;
            }
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            sa.SetAudio(49, gameObject.transform, false, false);
        }

    }

        IEnumerator Rotina() {
            yield return new WaitForSeconds(15.0f);
            nav.isStopped = false;
            StartCoroutine("NewRotina");
            Anim.SetInteger("Ataque", 1);
        }

        IEnumerator NewRotina() {
            yield return new WaitForSeconds(10.0f);
            nav.isStopped = true;
            StartCoroutine("Rotina");
            Anim.SetInteger("Ataque", 0);
        }

        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                int audio = Random.Range(1, 4);

                if (audio == 1)
                {
                    sa.SetAudio(49, gameObject.transform, false, false);
                }
                if (audio == 2)
                {
                    sa.SetAudio(55, gameObject.transform, false, false);
                }
                if (audio == 3)
                {
                    sa.SetAudio(58, gameObject.transform, false, false);
                }
                if (audio == 4)
                {
                    sa.SetAudio(59, gameObject.transform, false, false);
                }
                //FindObjectOfType<PlayerHealth>().DamagePlayer(damageEnemy);
            }

        }


        void RemoveHealth(float amount)
        {
            health -= amount;
            if (health < 0)
            {
                Anim.SetBool("Mototauro", true);
                Anim.SetInteger("Ataque", 3);
                sa.SetAudio(56, gameObject.transform, false, false);
                Destroy(gameObject);

            }
        }
    
}