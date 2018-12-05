using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArmorDrop : MonoBehaviour {

    private Image sprite;

    public Armor item;

    void Start()
    {

        sprite = GetComponent<Image>();
        sprite = item.imageArmor;

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
