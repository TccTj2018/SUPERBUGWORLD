using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy : MonoBehaviour {

    public float time;
	void Start () {
        StartCoroutine("DestroyTime");
	}
	
	IEnumerator DestroyTime ()
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}
