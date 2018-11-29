using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatafomRotation : MonoBehaviour {

    public float rot;
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.Rotate(0, rot, 0);
	}

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("entrou colisao");
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.parent = gameObject.transform;
            Debug.Log("colidiu e entrou");
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("saiu colisao");
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.parent = null;
            Debug.Log("colidiu e saiu");
        }
    }

}
