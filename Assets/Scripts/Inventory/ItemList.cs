using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemList : MonoBehaviour
{

    public Weapon weapon;
    
    public ConsumableItem consumableItem;
    public Text textItem;
    public Image imageItem;
    public Armor armor;


    public void SettingItem(ConsumableItem item)
    {

        consumableItem = item;
        imageItem.material = consumableItem.imageItem;
        textItem.text = consumableItem.itemName;
    }


    public void SetupWeapon(Weapon item)
    {
        weapon = item;
        imageItem.material = weapon.imageItens;
        textItem.text = weapon.weaponName;
    }

    public void SetupArmor(Armor item)
    {
        armor = item;
        imageItem.material = armor.imageArmor;
        textItem.text = armor.armorName;
    }
}
