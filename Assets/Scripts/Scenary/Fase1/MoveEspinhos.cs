using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEspinhos : MonoBehaviour {


    public enum dir { Horizontal, Vertical }
    public dir movement = dir.Horizontal;

    public float dist = 10f;
    public float movementSpeed = 3.0f;
    private float startPos;


    private void OnCollisionEnter(Collision collision)
    {
            Debug.Log("Qualquer um colidiu");
            if (collision.gameObject.tag == "Player")
            {
                Debug.Log("PLAYER colidiu");
                // puxar script e chamar variavel para subtrair
                PlayerHealth script = collision.gameObject.GetComponent<PlayerHealth>();
                script.VidaDoPlayer = -15;
                Debug.Log(script.VidaDoPlayer);
            }
    }

    void Start()
    {
        if (movement == dir.Horizontal)
            startPos = transform.position.x;
        else
            startPos = transform.position.y;
    }

    void Update()
    {
        if (movement == dir.Horizontal)
            transform.position = new Vector3(startPos + Mathf.PingPong(Time.time * movementSpeed, dist), transform.position.y, transform.position.z);
        else
            transform.position = new Vector3(transform.position.x, startPos + Mathf.PingPong(Time.time * movementSpeed, dist), transform.position.z);
    }
}