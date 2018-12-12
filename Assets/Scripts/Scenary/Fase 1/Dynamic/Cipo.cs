using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cipo : MonoBehaviour {

    public GameObject player;

    public float force;

    public MoveCharacter mc;
    public Rigidbody rb;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.gameObject;
            mc.enabled = false;
            rb.useGravity = false;
            other.transform.parent = gameObject.transform;
            // MUDAR ANIMAÇÃO !
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && player != null)
        {
            player.transform.parent = null;
            mc.enabled = true;
            rb.useGravity = true;
            rb.velocity = new Vector3(0, 0, 0);
            player.transform.eulerAngles = new Vector3(0, 90, 0);
            StartCoroutine("WaitResetCol");
            player = null;
        }
    }

    IEnumerator WaitResetCol()
    {
        Collider col = gameObject.GetComponent<Collider>();
        col.enabled = false;
        yield return new WaitForSeconds(1f);
        col.enabled = true;
    }
}
