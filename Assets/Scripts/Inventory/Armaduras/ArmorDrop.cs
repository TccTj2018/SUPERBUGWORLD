using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorDrop : MonoBehaviour {

    private MeshRenderer sprite;

    public Armor item;

    void Start()
    {

        sprite = GetComponent<MeshRenderer>();
        sprite.material = item.imageArmor;

    }
    //
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.inventory.AddArmor(item);
            FindObjectOfType<UIManager>().SetMessage(item.message);
            FindObjectOfType<UIManager>().UpdateUI();
            Destroy(gameObject);
        }
        Debug.Log((other.CompareTag("Player")));
    }
}
