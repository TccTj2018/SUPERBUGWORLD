using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour {

    public GameObject player;
    public MoveCharacter scriptPlayer;
    Rigidbody rb;
    public float force;

    public bool inCol;
    public bool inBut;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            inCol = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            inCol = false;
        }
    }

    private void Update()
    {
      if (inCol == true && Input.GetKeyDown(KeyCode.LeftControl))
        {
            inBut = true;

            player.transform.parent = transform;
            scriptPlayer.enabled = false;
        }

        if (inCol == true && Input.GetKeyUp(KeyCode.LeftControl))
        {
            inBut = false;

            player.transform.parent = null;
            scriptPlayer.enabled = true;
        }

        if (inBut == true && Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-force, 0, 0);
        }

        if (inBut == true && Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(force, 0, 0);
        }
    }

}
