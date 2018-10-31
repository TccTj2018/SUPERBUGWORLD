using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCharacter : MonoBehaviour {
    /// sempre quando se referir ao player principal chamar de p_Kleber;
    static Animator anim;
    public float speed = 10;
    public float rotationSpeed = 100.0f;
    bool p_facing;

    private float verticalvelocity;
    public float jumpforce = 8.0f;
    public float gravity = 20.0f;

    CharacterController p_Kleber;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        p_Kleber = GetComponent<CharacterController>();
        p_facing = true;



    }

    // Update is called once per frame
    void Update()
    {



        float translation;
        if (Input.GetKey(KeyCode.LeftShift))

        {

            if (speed <= 25f)
            {
                speed += 0.5f;
                translation = Input.GetAxis("Horizontal") * speed;

            }
            else
            {
                translation = Input.GetAxis("Horizontal") * speed;
            }
            anim.SetBool("running", true);

        }
        else
        {
            speed = 10;
            translation = Input.GetAxis("Horizontal") * speed;
            anim.SetBool("running", false);
        }

        Debug.Log(translation);
        //float move = Input.GetAxis("Horizontal") * rotationSpeed; 

        translation = translation * Time.deltaTime;
        // rotation = rotation * Time.deltaTime;


        transform.Translate(0, 0, translation);
        //transform.Rotate(0, 180, 0);

        if (Input.GetButtonDown("Jump"))
        {
            anim.SetTrigger("jump");

        }
        if (translation != 0)
        {
            anim.SetBool("run", true);

        }
        else
        {
            anim.SetBool("run", false);
        }


        if (p_Kleber.isGrounded)
        {
            verticalvelocity = -gravity * Time.deltaTime;
            
              if (Input.GetButton("Jump"))
           {
            anim.SetBool("jump", true);
                verticalvelocity = jumpforce;
  
            }
          

         }
        else
        {
            anim.SetBool("jump", false);
            verticalvelocity -= gravity * Time.deltaTime;
        }
        Vector3 moveVector = new Vector3(0, verticalvelocity, 0);
        p_Kleber.Move(moveVector * Time.deltaTime);
        //if (Input.GetKey(KeyCode.Space))
        // {
        //      anim.SetBool("jumpidle", true);
        //
        //}
        //else
        //{
        //     anim.SetBool("jumpidle", false);
        //}


    }

    private void FixedUpdate()
    {
        float move = Input.GetAxis("Horizontal");
        if (move > 0 && !p_facing) Flip();
        else if (move < 0 && p_facing) Flip();
    }
    void Flip() {
        p_facing = !p_facing;
        Vector3 theScale = transform.localScale;
        theScale.z *= -1;
        transform.localScale = theScale;

    }
}
