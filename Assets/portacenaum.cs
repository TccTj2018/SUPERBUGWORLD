using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portacenaum : MonoBehaviour {

    public Animator _animator;

    private bool _colidindo;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter (Collider _col)
    {
        if (_col.gameObject.CompareTag("Player"))
            _animator.SetBool("open", true);
        
            

        }
    }

