using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDrop : MonoBehaviour
{

    public Weapon weapon;
    public GameObject ObjectDestroy;

    private MeshRenderer sprite;

    void Start()
    {

        sprite = GetComponent<MeshRenderer>();
        sprite.material = weapon.imageItens;

    }

    //Método para coletar a arma,
    private void OnTriggerEnter(Collider other)
    {

        Fight player = other.GetComponent<Fight>();
        if (other.transform.tag == "Player")
        {

            player.AddWeapon(weapon);
            FindObjectOfType<UIManager>().SetMessage(weapon.messageTela);
            FindObjectOfType<UIManager>().UpdateUI();
            GameManager.inventory.AddWeapon(weapon);
            ObjectDestroy.SetActive(false);
        }
        Debug.Log(other);
    }
}
