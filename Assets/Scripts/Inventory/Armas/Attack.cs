using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{

    //private Animator anim;
    private int damagePlayer;
    private GameObject attackPlayer;
    private ParticleSystem particlePower;
    public Rigidbody objectRb;

    public float speed = 1;
    public float destroyTime = 1.5f;

    void Start()
    {
        // anim = GetComponent<Animator>();
        Destroy(gameObject, destroyTime);
        attackPlayer = GetComponent<GameObject>();
        damagePlayer = GameManager.inventory.strength;
        particlePower = GetComponentInChildren<ParticleSystem>();
        particlePower.Stop();
        objectRb = GetComponent<Rigidbody>();
    }

    //public void PlayAnimation(AnimationClip clip)
    // {
    // anim.Play(clip.name);
    //}
    void Update()
    {

        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }
    public void PlayAnimation(Rigidbody clip)
    {
        Debug.Log(clip);
        // clip = GetComponent<Rigidbody>();

        try
        {
            attackPlayer.SetActive(false); 
            objectRb = clip;
            particlePower.Play();
        }
        catch (System.Exception ex)
        {
            Debug.Log(ex.Message.ToString());
            Debug.Log(attackPlayer);
            // clip = GetComponent<Rigidbody>();
        }
    }

    public void SetWeapon(int damageValue)
    {
        damagePlayer = damageValue;
       // Debug.Log(damageValue);
    }

    public int GetDamage()
    {
        return damagePlayer;
    }

    private void OnTriggerEnter(Collider other)
    {
        Enemy otherEnemy = other.GetComponent<Enemy>();
       // Boss otherBoss = other.GetComponent<Boss>();
        
        if (otherEnemy != null)
        {
            otherEnemy.TookDamage(damagePlayer);
        }


        Destroy(gameObject);
    }

}
