using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fight : MonoBehaviour {

    static Animator anim;
    bool idle;
    bool soco1 = false;
    bool soco2 = false;
    bool soco3 = false;
     public AudioSource socoAudio;
    public GameObject prefab;
    public GameObject prefab2;
    public Transform spawpoint;
    public Transform pai;
    void Start () {
        anim = GetComponent<Animator>();
        idle = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1") && soco1 == false ) {
            socoAudio.Play();
            anim.SetTrigger("soco1");
            soco2 = true;
            GameObject ObjetoInstanciado = Instantiate(prefab2, spawpoint.position, spawpoint.rotation, pai) as GameObject;
            if (Input.GetButtonDown("Fire1") && soco1 == false && soco2 == true)
            {

                anim.SetTrigger("soco2");
                soco3 = true;
                if (Input.GetButtonDown("Fire1") && soco1 == false && soco2 == true && soco3 == true)
                {

                    anim.SetTrigger("soco3");
                    soco2 = true;
                }
            }
        }
        if (Input.GetButtonDown("Fire2") )
        {

            anim.SetTrigger("soco4");
            GameObject ObjetoInstanciado = Instantiate(prefab, spawpoint.position, spawpoint.rotation,pai) as GameObject;
           
        }
    }

    
}
