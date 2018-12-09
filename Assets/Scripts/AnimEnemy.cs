using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AnimEnemy : MonoBehaviour {
	/*
	private Animator Anim;
    NavMeshAgent mototauroMesh;
    private float tempo;
    private bool Teste = false;

	void Start () {

        Anim = GetComponent<Animator> ();

        mototauroMesh = GameObject.Find("Mototauro").GetComponent<NavMeshAgent>();
        mototauroMesh.enabled = false;
        StartCoroutine("WaitTime");
         Run();
    }

     void Update()
    {
        mototauroMesh.enabled = false;
    }

    public void Run() {

      mototauroMesh.isStopped = true;
        Debug.Log(mototauroMesh.name);
        StartCoroutine(WaitTime(5.0f));

    }
    

    IEnumerator WaitTime()
    {
        tempo = 5;
        Debug.Log("entrou");
        yield return new WaitForSeconds(tempo);

        if (Teste == false)
        {
            Teste = true;
            mototauroMesh.isStopped = false;
            Anim.SetInteger("Ataque", 0);
        }
        else
        {
            Teste = false;
            mototauroMesh.isStopped = true;
            Anim.SetInteger("Ataque", 1);
        }

        yield return new WaitForSeconds(tempo);
        StartCoroutine("WaitTime");
         
    }
    */
}
