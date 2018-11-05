using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cipo : MonoBehaviour {

    public GameObject player;

    public float force;

    Rigidbody rb;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.gameObject;
            other.gameObject.GetComponent<MoveCharacter>().enabled = false;
            other.transform.parent = gameObject.transform;
            // MUDAR ANIMAÇÃO !
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && player != null)
        {
            player.transform.parent = null;
            player.GetComponent<Rigidbody>().AddForce(player.transform.up * force, ForceMode.Impulse);
            player.GetComponent<MoveCharacter>().enabled = true;
            player.transform.eulerAngles = new Vector3(0, 90, 0);
            StartCoroutine("WaitResetCol");
            player = null;
        }
    }

    IEnumerator WaitResetCol()
    {
        Collider col = gameObject.GetComponent<Collider>();
        col.enabled = false;
        yield return new WaitForSeconds(0.4f);
        col.enabled = true;
    }
}
