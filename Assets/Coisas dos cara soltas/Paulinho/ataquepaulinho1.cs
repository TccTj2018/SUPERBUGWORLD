using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ataquepaulinho1 : MonoBehaviour {

    // Use this for initialization
    private void OnTriggerEnter(Collider col)
    {
        if (col.transform.tag == "Player") {
            //GameManager.inventory.health -= 10;
            Destroy(gameObject);
        }
    }
}
	
	// Update is called once per frame

		
	

