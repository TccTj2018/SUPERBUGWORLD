using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {
	
	public float lookRadius = 10f;
	 public Transform target;
	NavMeshAgent agent;
	public Animator anim;
	public int numero = 0;
    public GameObject prefab;
    public GameObject prefab2;
    public Transform spawpoint;
    public Transform spawpoint2;
    public float speed;
    public float speed2;
    void Start () {
		anim = GetComponent<Animator> ();
	    agent = GetComponent<NavMeshAgent> ();
		StartCoroutine ("random");
        


    }
	
	// Update is called once per frame
	void Update () {

		float distance = Vector3.Distance (target.position, transform.position);
		if (distance <= lookRadius) {
			agent.SetDestination (target.position);
			anim.SetBool ("running", true);

			if (distance <= agent.stoppingDistance) 
			{
				anim.SetBool ("running", false);
			}

		}
		if (distance > lookRadius)
		{
			anim.SetBool ("running", false);


		}
		if (numero == 1) {
			anim.SetTrigger("ataque1");
			
           GameObject Temporary_Bullet_Handler2;

            Temporary_Bullet_Handler2 = Instantiate(prefab2, spawpoint2.transform.position, spawpoint2.transform.rotation) as GameObject;
            Temporary_Bullet_Handler2.transform.Rotate(Vector3.left * 90);
            Rigidbody Temporary_RigidBody2;
            Temporary_RigidBody2 = Temporary_Bullet_Handler2.GetComponent<Rigidbody>();
            Temporary_RigidBody2.AddForce(transform.forward * speed2);
            Destroy(Temporary_Bullet_Handler2, 10.0f);

            numero = 0;
        }
        if (numero == 2) {
			anim.SetTrigger("ataque2");
            GameObject Temporary_Bullet_Handler;
           
            Temporary_Bullet_Handler = Instantiate(prefab, spawpoint.transform.position, spawpoint.transform.rotation) as GameObject;
            Temporary_Bullet_Handler.transform.Rotate(Vector3.left * 90);
            Rigidbody Temporary_RigidBody;
            Temporary_RigidBody = Temporary_Bullet_Handler.GetComponent<Rigidbody>();
            Temporary_RigidBody.AddForce(transform.forward * speed);
            Destroy(Temporary_Bullet_Handler, 10.0f);

            numero = 0;
           
        }


	}
	void OnDrawGizmosSelected ()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere (transform.position, lookRadius);
	}
	IEnumerator random(){
		numero = Random.Range (0, 3);
		yield return new WaitForSeconds (3.0f);
		StartCoroutine ("random");
	}
    

}
