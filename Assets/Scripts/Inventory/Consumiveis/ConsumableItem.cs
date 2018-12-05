using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu]
public class ConsumableItem : ScriptableObject
{

    public int itemID;
    public string itemName;
    public string descrition;
    public Image imageItem;
    public int healthGain;
    public int manaGain;
    public string message;
}
