using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeUI : MonoBehaviour {

    public Text upgradeCostText;
    public Text[] attributesText;
    public GameObject upgradePanel;

    private bool upgradeActive = false;
    private Fight player;
    private int cursorIndex;
    private GameManager inventory;

    void Start()
    {
        player = FindObjectOfType<Fight>();
        inventory = FindObjectOfType<GameManager>();

    }
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.U))
        {
            upgradeActive = !upgradeActive;
            cursorIndex = 0;
            UpdateText();

            if (upgradeActive)
            {
                upgradePanel.SetActive(true);
            }
            else
            {
                upgradePanel.SetActive(false);
            }
        }
        if (upgradeActive)
        {
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                UpdateText();
                cursorIndex++;
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                UpdateText();
                cursorIndex--;
            }

            if (cursorIndex == 0)
            {
                attributesText[0].text = "Vida: " + player.maxHealth + ">" + Mathf.RoundToInt(inventory.health + (inventory.health * 0.1f));
                attributesText[0].color = Color.green;
            }
            else if (cursorIndex == 1)
            {
                attributesText[1].text = "Mana: " + player.maxMana + ">" + Mathf.RoundToInt(inventory.mana + (inventory.mana * 0.1f));
                attributesText[1].color = Color.green;
            }
            else if (cursorIndex == 2)
            {
                attributesText[2].text = "Forca: " + player.strength + ">" + Mathf.RoundToInt(inventory.strength + (inventory.strength * 0.1f));
                attributesText[2].color = Color.green;
            }

            if (Input.GetKeyDown(KeyCode.M) && inventory.bugCoins >= GameManager.inventory.upgradeCost)
            {
                inventory.bugCoins -= GameManager.inventory.upgradeCost;
                GameManager.inventory.upgradeCost += (GameManager.inventory.upgradeCost / 2);
                if (cursorIndex == 0)
                {
                    inventory.health += (int)(inventory.health * 0.1f);
                   // Debug.Log(player.maxHealth);
                }
                else if (cursorIndex == 1)
                {
                    inventory.mana += (int)(inventory.mana * 0.1f);
                }
                else if (cursorIndex == 2)
                {
                    inventory.strength += (int)(inventory.strength * 0.1f);
                }

                UpdateText();
                FindObjectOfType<UIManager>().UpdateUI();
            }
        }

    }
    public void UpdateText()
    {

        upgradeCostText.text = "Custo de BugCoins:  " + GameManager.inventory.upgradeCost + "BugCoins:  " + inventory.bugCoins;
        attributesText[0].text = "Vida: " + inventory.health;
        attributesText[1].text = "Mana: " + inventory.mana;
        attributesText[2].text = "Forca: " + inventory.strength;
        for (int i = 0; i < attributesText.Length; i++)
        {
            attributesText[i].color = Color.white;
        }
    }
}
