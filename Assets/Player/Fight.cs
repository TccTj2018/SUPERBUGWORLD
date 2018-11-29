using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fight : MonoBehaviour {

    static Animator anim;
    public bool idle;
    public bool soco1 = false;
    public bool soco2 = false;
    public bool soco3 = false;
    public AudioSource socoAudio;
    public GameObject prefab;
    public GameObject prefab2;
    public Transform spawpoint;
    public Transform spawpoint2;
    public Transform pai;
    public Transform pai2;

    public Weapon weaponEquipped;
    private Attack attack;
    private float nextAttack;
    public int health;
    public int mana;
    private GameManager inventory;
    private MoveCharacter move;

    public Armor armor;
    public float fireRate;
    public ConsumableItem item;
    public int maxHealth ;
    public float F_speed;
    public int maxMana ;
    public int strength ;
    public int defense;
    public int bugCoins;
    public Rigidbody projectile;

    public MoveCharacter mc;

    void Start () {

        anim = GetComponent<Animator>();
        idle = true;
        attack = GetComponentInChildren<Attack>();
        // maxHealth = inventory.health;
        //maxMana = inventory.mana;
        //defense = inventory.strength;
        FindObjectOfType<GameManager>().Load();
       // FindObjectOfType<UIManager>().UpdateUI();
        inventory = GameManager.inventory;
        move = GetComponent<MoveCharacter>();
        //Debug.Log("start Fight" + inventory.playerPosX);
        SetPlayer();

    }

    void Update () {
        if (Input.GetButtonDown("Ataque") ) {
            //socoAudio.Play();
            anim.SetTrigger("soco1");
            soco2 = true;

            Rigidbody clone;
            clone = Instantiate(projectile, spawpoint.position, spawpoint.rotation);
            

            clone.velocity = transform.TransformDirection(Vector3.forward * 10);

            if (Input.GetButtonDown("Ataque") && soco1 == false && soco2 == true)
            {

                anim.SetTrigger("soco2");
                soco3 = true;
                if (Input.GetButtonDown("Fire6") && soco1 == false && soco2 == true && soco3 == true)
                {

                    anim.SetTrigger("soco3");
                    soco2 = true;
                }
            }
        }
        if (Input.GetButtonDown("Fire5") )
        {

            
           
            if(mc.isFliped == true)
            {
                Debug.Log("Verdadeiro");
                anim.SetTrigger("soco4");
                GameObject ObjetoInstanciado = Instantiate(prefab, spawpoint2.position, spawpoint2.rotation) as GameObject;
                mc.enabled = false;
                enabled = false;
                StartCoroutine("Reset");
                
            }
            else
            {
                Debug.Log("False");
                Debug.Log("Verdadeiro");
                anim.SetTrigger("soco4");
                GameObject ObjetoInstanciado = Instantiate(prefab, spawpoint.position, spawpoint.transform.rotation, pai) as GameObject;
                mc.enabled = false;
                enabled = false;
                StartCoroutine("Reset");
            }

        }
        if (Input.GetButtonDown("Fire1") && Time.time > nextAttack && weaponEquipped != null)
        {
            anim.SetTrigger("soco1");
            attack.PlayAnimation(weaponEquipped.animationAnim);
            nextAttack = Time.time + fireRate;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            UseItem(item);
            GameManager.inventory.RemoveItem(item);
        }
        

    }

    IEnumerator Reset()
    {
        yield return new WaitForSeconds(1);
        mc.enabled = true;
        enabled = true;
    }

    public void AddWeapon(Weapon weapon)
    {
        weaponEquipped = weapon;
        attack.SetWeapon(weaponEquipped.damage);
        Debug.Log(weaponEquipped.damage);

    }


    public void AddArmor(Armor item)
    {
        armor = item;
        defense = armor.defense;
        Debug.Log(defense);
    }
    //Para o script de vida.
    public void UseItem(ConsumableItem item)
    {
        inventory.health += item.healthGain;
        if (inventory.health >= maxHealth)
        {
            health = maxHealth;
        }
        inventory.mana += item.manaGain;
        if (inventory.mana >= maxMana)
            inventory.mana = maxMana;
    }

    public int GetHealth()
    {

        return maxHealth;
    }
    public int GetMana()
    {
        return maxMana;
    }
    public void SetPlayer()
    {
        Vector3 playerPosition = new Vector3(inventory.playerPosX, inventory.playerPosY, inventory.playerPosZ);

       // Debug.Log("SetPlayer" + inventory.playerPosX);
        move.transform.position = playerPosition;
       // Debug.Log(playerPosition);

        maxMana = inventory.mana;
        maxHealth = inventory.health;
        F_speed = move.speed;
        health = maxHealth;
        mana = maxMana;
        strength = inventory.strength;

        if(inventory.currentArmorId > 0)
        {
            AddArmor(GameManager.inventory.itemDataBase.GetArmor(inventory.currentArmorId));
        }

        if (inventory.currentWeaponId > 0)
        {
            AddWeapon(GameManager.inventory.itemDataBase.GetWeapon(inventory.currentWeaponId));
        }
    }


}
