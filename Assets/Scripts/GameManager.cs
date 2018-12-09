using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

[Serializable]
class PlayerData
{
    public int health;
    public int mana;
    public int strength;

    public float playerPosX, playerPosY, playerPosZ;
    
    public int bugCoins;
    public int[] itemId;
    public int[] weaponId;
    public int[] armorId;
    public int upgradeCost;
    public int currentWeaponId;
    public int currentArmorId;


}

public class GameManager : MonoBehaviour {

    public static GameManager inventory;
    public List<Weapon> weapons;
    
    public List<ConsumableItem> itens;
    public List<Armor> armors;

    public int health ;
    public int mana ;
    public int strength ;

    public float playerPosX, playerPosY, playerPosZ;
    public float minCamX, maxCamX, minCamY, maxCamY;
    public int bugCoins;
    public int[] itemId;
    public int[] weaponId;
    public int[] armorId;
    public int upgradeCost;
    public int currentWeaponId;
    public int currentArmorId;
    private Fight player;

    public ItemDataBase itemDataBase;

    private string filePath;

    void Awake()
    {
        filePath = Application.persistentDataPath + "/playerInfo.data";
        //Debug.Log(filePath);

        player = FindObjectOfType<Fight>();

        if (inventory == null)
            inventory = this;

        else if (inventory != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

        Load();

       // Debug.Log(playerPosX);
    }

    public void AddWeapon(Weapon weapon)
    {
        weapons.Add(weapon);
    }
    public void AddItem(ConsumableItem item)
    {
        itens.Add(item);
    }
    public void RemoveItem(ConsumableItem item)
    {
        for (int i = 0; i < itens.Count; i++)
        {
            if (itens[i] == item)
            {
                itens.RemoveAt(i);
                break;
            }
        }
    }

    public void Save()
    {

        itemId = new int[inventory.itens.Count];

        weaponId = new int[inventory.weapons.Count];
        


        armorId = new int[inventory.armors.Count];

        for (int i = 0; i < itemId.Length; i++)
        {
            itemId[i] = inventory.itens[i].itemID;
        }

        for (int i = 0; i < weaponId.Length; i++)
        {
            weaponId[i] = inventory.weapons[i].itemID;
        }

        for (int i = 0; i < armorId.Length; i++)
        {
            armorId[i] = inventory.armors[i].itemID;
        }

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(filePath);

        PlayerData data = new PlayerData();

        data.health = inventory.health;
        data.mana = inventory.mana;
        //Debug.Log(player.maxHealth);

        data.playerPosX = player.transform.position.x;
        data.playerPosY = player.transform.position.y;
        data.playerPosZ = player.transform.position.z;
        data.bugCoins = player.bugCoins;
        data.strength = player.strength;
        data.upgradeCost = upgradeCost;

        if (player.weaponEquipped != null)
            data.currentWeaponId = player.weaponEquipped.itemID;
        if (player.armor != null)
            data.currentArmorId = player.armor.itemID;

        data.itemId = itemId;

        data.weaponId = weaponId;

        data.armorId = armorId;

        bf.Serialize(file, data);

        file.Close();

        

        FindObjectOfType<UIManager>().SetMessage("Jogo Salvo");
    }

    private void Start()
    {
        LoadInventory();
       // player.SetPlayer();
    }

    public int CountItens(ConsumableItem item)
    {
        int numberOfItens = 0;
        for (int i = 0; i < itens.Count; i++)
        {
            if (item == itens[i])
            {
                numberOfItens++;

            }
        }
        Debug.Log(numberOfItens);
        return numberOfItens;

    }

    public void LoadInventory()
    {
        for (int i = 0; i < inventory.weaponId.Length; i++)
        {
            AddWeapon(itemDataBase.GetWeapon(inventory.weaponId[i]));
        }

        for (int i = 0; i < inventory.itemId.Length; i++)
        {
            AddItem(itemDataBase.GetConsumableItem(inventory.itemId[i]));
        }

        for (int i = 0; i < inventory.armorId.Length; i++)
        {
            AddArmor(itemDataBase.GetArmor(inventory.armorId[i]));
        }
    }

    public void AddArmor(Armor armor)
    {
        armors.Add(armor);
    }

    public void Load()
    {
        if (File.Exists(filePath))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(filePath, FileMode.Open);
            PlayerData data = (PlayerData)bf.Deserialize(file);
            file.Close();

            health = data.health;
            mana = data.mana;
            strength = data.strength;
            playerPosX = data.playerPosX;
            playerPosY = data.playerPosY;
            playerPosZ = data.playerPosZ;
            bugCoins = data.bugCoins;
            currentArmorId = data.currentArmorId;
            currentWeaponId = data.currentWeaponId;
            itemId = data.itemId;
            upgradeCost = data.upgradeCost;


        }
    }
}
