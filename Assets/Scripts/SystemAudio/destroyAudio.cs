using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyAudio : MonoBehaviour {

    public float time;

	void Start () {
        StartCoroutine("Destroy");
	}
	
	IEnumerator Destroy()
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}
