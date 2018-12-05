using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCharacter : MonoBehaviour {
    /// sempre quando se referir ao player principal chamar de p_Kleber;
    static Animator anim;
    public float speed = 10;
    public float rotationSpeed = 100.0f;
    bool p_facing;
    public float distToGround = 0.5f;
    private float verticalvelocity;
    public float jumpforce = 8.0f;
    public Rigidbody rb;
    public bool isFliped;
    CharacterController p_Kleber;
    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        p_Kleber = GetComponent<CharacterController>();
        p_facing = true;
    }
    bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, distToGround);
    }

    // Update is called once per frame
    void Update()
    {

        //Debug.Log(IsGrounded());

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

        translation = translation * Time.deltaTime;



        transform.Translate(0, 0, translation);


        if (Input.GetButtonDown("Jump"))
            if (IsGrounded() == true)
            {
                anim.SetTrigger("jump");
                rb.AddForce(0, jumpforce * 40f, 0, ForceMode.Impulse);
            }





        if (translation != 0)
        {
            anim.SetBool("run", true);

        }
        else
        {
            anim.SetBool("run", false);
        }




    }


    private void FixedUpdate()
    {
        float move = Input.GetAxis("Horizontal");
        if (move > 0 && !p_facing) Flip();
        else if (move < 0 && p_facing) Flip();

    }
    void Flip()
    {
        p_facing = !p_facing;
        Vector3 theScale = transform.localScale;
        theScale.z *= -1;
        transform.localScale = theScale;

        if(isFliped == false)
        {
            isFliped = true;
        }
        else
        {
            isFliped = false;
        }

    }
    public void OnClick() {
        
        
            anim.SetTrigger("jump");
            rb.AddForce(0, jumpforce * 40f, 0, ForceMode.Impulse);
        
    }

}
