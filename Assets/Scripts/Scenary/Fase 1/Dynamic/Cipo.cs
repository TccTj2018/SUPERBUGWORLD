using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cipo : MonoBehaviour {

    public GameObject player;
    public Animator anim;
    public float force;

    public Rigidbody rb;
    public MoveCharacter mc;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.gameObject;
            rb.useGravity = false;
            mc.enabled = false;
            other.transform.parent = gameObject.transform;
            // MUDAR ANIMAÇÃO !
            

        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && player != null)
        {
            player.transform.parent = null;
            rb.useGravity = true;
            mc.enabled = true;
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
