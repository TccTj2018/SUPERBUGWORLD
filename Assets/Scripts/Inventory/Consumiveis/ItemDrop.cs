using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemDrop : MonoBehaviour
{

    public ConsumableItem item;

    private Image sprite;


    void Start()
    {

        sprite = GetComponent<Image>();
        sprite = item.imageItem;

    }
    //
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.inventory.AddItem(item);
            FindObjectOfType<UIManager>().SetMessage(item.message);
            FindObjectOfType<UIManager>().UpdateUI();
            Destroy(gameObject);
        }
       // Debug.Log((other.CompareTag("Player")));
    }
}
