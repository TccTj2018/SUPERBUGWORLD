using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColAudio : MonoBehaviour {

    SystemAudio sa;

    public int numAudio;
    public bool colTrigger;

    public bool addForceUp = false;
    float force;

    private void Start()
    {
        sa = GameObject.Find("EventSystemAudio").GetComponent<SystemAudio>();
    }

    private void OnTriggerEnter(Collider other)
    {
     if(other.CompareTag("Player") && colTrigger == true)
        {
            sa.SetAudio(numAudio, gameObject.transform);

            StopCoroutine("ResetJump");

            if (addForceUp == true)
            {
                StartCoroutine("ResetJump");

                Rigidbody rb = other.GetComponent<Rigidbody>();
                rb.AddForce(other.transform.up * force, ForceMode.Impulse);
            }
        }    
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && colTrigger == false)
        {
            sa.SetAudio(numAudio, gameObject.transform);

            StopCoroutine("ResetJump");

            if (addForceUp == true)
            {
                StartCoroutine("ResetJump");

                force = force + 150;

                Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
                rb.AddForce(collision.gameObject.transform.up * force, ForceMode.Impulse);
            }
        }
    }

    IEnumerator ResetJump()
    {
        if (force <= 750)
        {
            yield return new WaitForSeconds(5);
            force = 0;
        }
    }
}
