using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDataBase : MonoBehaviour
{

    public List<Weapon> weapons;
    public List<ConsumableItem> consumableItens;
    public List<Armor> armors;

    public Weapon GetWeapon(int itemId)
    {
        foreach (var item in weapons)
        {
            if (item.itemID == itemId)
                return item;
        }
        return null;
    }

    public ConsumableItem GetConsumableItem(int itemId)
    {
        foreach (var item in consumableItens)
        {
            if (item.itemID == itemId)
                return item;
        }
        return null;
    }

    public Armor GetArmor(int itemId)
    {
        foreach (var item in armors)
        {
            if (item.itemID == itemId)
                return item;
        }
        return null;
    }
}
