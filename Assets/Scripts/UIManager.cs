using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public GameObject pausePanel;
    public Transform cursor;
    public GameObject[] menuOption;
    public GameObject optionPanel;
    public GameObject itemList;
    public GameObject itensPrefabs;
    public RectTransform content;
    public List<ItemList> itens;
    public Text descritionText;
    public Scrollbar scrollVertical;
    public Text healthText, manaText, strengthText, attackText, defenseText;
    public Text messageText;
    public Slider sliderHealth;
    public Slider sliderMana;
    public Slider sliderStrength;

    //Nova variavel,
    private bool isMessageActive = false;
    //Nova variavel
    private float textTimer;

    private bool pauseMenu = false;
    private int cursorIndex = 0;
    //Tenho que referenciar essa variavel de GameManager no metodo de start,
    private GameManager inventory;
    private bool itensListActive = false;
    private Fight player;

    public Text healthUI, manaUI, coinsUI, potionUI;

   
    


    void Start()
    {
        inventory = GameManager.inventory;
        player = FindObjectOfType<Fight>();

    }

    void Update()
    {

        UpdateUI();
        

        if (isMessageActive == true)
        {
            Color color = messageText.color;
            color.a += 1f * Time.deltaTime;
            messageText.color = color;
            if (color.a >= 1)
            {
                isMessageActive = false;
                textTimer = 0;
            }

        }
        else if (!isMessageActive)
        {
            textTimer += Time.deltaTime;
            if (textTimer >= 1f)
            {
                Color color = messageText.color;
                color.a -= 1f * Time.deltaTime;
                messageText.color = color;
            }
            if (textTimer <= 0)
            {
                messageText.text = "";
            }
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            pauseMenu = !pauseMenu;
            itensListActive = false;
            descritionText.text = "";
            itemList.SetActive(false);
            UpdateAtributes();

            if (pauseMenu == true)
                pausePanel.SetActive(true);
            else if(pauseMenu == false)
                pausePanel.SetActive(false);
        }
        if (pauseMenu == true)
        {
            Vector3 cursorPosition = new Vector3();
            if (!itensListActive == true)
            {
                cursorPosition = menuOption[cursorIndex].transform.position;
                cursor.position = new Vector3(cursorPosition.x - 100, cursorPosition.y, cursorPosition.z);
            }
            else if (itensListActive && itens.Count > 0)
            {
                cursorPosition = itens[cursorIndex].transform.position;
                cursor.position = new Vector3(cursorPosition.x - 75, cursorPosition.y, cursorPosition.z);
            }
            optionPanel.SetActive(true);

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (itensListActive && cursorIndex >= menuOption.Length - 1)
                {
                    cursorIndex = menuOption.Length - 1;
                }
                else if (!itensListActive && cursorIndex >= itens.Count - 1)
                {
                    if (itens.Count == 0)
                    {
                        cursorIndex = 0;
                    }
                    else
                    {
                        cursorIndex = itens.Count - 1;
                    }
                }
                else
                    cursorIndex++;

                if (itensListActive && itens.Count > 0)
                {
                    scrollVertical.value -= (1f / (itens.Count - 1));
                    UpdateDescrition();
                }
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (cursorIndex == 0)
                {
                    cursorIndex = 0;
                }
                else
                    cursorIndex--;

                if (itensListActive && itens.Count > 0)
                {
                    scrollVertical.value += (1f / (itens.Count - 1));
                    UpdateDescrition();
                }
            }
            if (Input.GetButtonDown("Submit") && !itensListActive)
            {
                optionPanel.SetActive(false);
                itemList.SetActive(true);
                UpdateItensList(cursorIndex);
                RefreshItensList();
                cursorIndex = 0;
                if (itens.Count > 0)
                {
                    UpdateDescrition();
                }
                itensListActive = true;
            }
            else if (Input.GetButtonDown("Submit") && !itensListActive)
            {
                if (itens.Count > 0)
                {
                    UseItem();
                }
            }
        }

    }
    void UseItem()
    {
        if (itens[cursorIndex].weapon != null)
        {
            player.AddWeapon(itens[cursorIndex].weapon);
        }
        else if (itens[cursorIndex].consumableItem != null)
        {
            player.UseItem(itens[cursorIndex].consumableItem);
            inventory.RemoveItem(itens[cursorIndex].consumableItem);
            cursorIndex = 0;
            RefreshItensList();
            UpdateItensList(2);
            scrollVertical.value = 1;
        }
        else if (itens[cursorIndex].armor != null)
        {
            player.AddArmor(itens[cursorIndex].armor);
        }
        UpdateAtributes();
        UpdateDescrition();
    }

    void UpdateDescrition()
    {
        if (itens[cursorIndex].weapon != null)
            descritionText.text = itens[cursorIndex].weapon.descrition;
        else if (itens[cursorIndex].consumableItem != null)
            descritionText.text = itens[cursorIndex].consumableItem.descrition;
        else if (itens[cursorIndex].armor != null)
            descritionText.text = itens[cursorIndex].armor.descrition;

    }
    void UpdateItensList(int option)
    {
        if (option == 0)
        {
            for (int i = 0; i < inventory.weapons.Count; i++)
            {
                GameObject tempItem = Instantiate(itensPrefabs, content.transform);
                tempItem.GetComponent<ItemList>().SetupWeapon(inventory.weapons[i]);
                itens.Add(tempItem.GetComponent<ItemList>());
            }
        }
        else if (option == 1)
        {
            for (int i = 0; i < inventory.armors.Count; i++)
            {
                GameObject tempItem = Instantiate(itensPrefabs, content.transform);
                tempItem.GetComponent<ItemList>().SetupArmor(inventory.armors[i]);
                itens.Add(tempItem.GetComponent<ItemList>());
            }
        }
        else if (option == 2)
        {
            for (int i = 0; i < inventory.itens.Count; i++)
            {
                GameObject tempItem = Instantiate(itensPrefabs, content.transform);
                tempItem.GetComponent<ItemList>().SettingItem(inventory.itens[i]);
                itens.Add(tempItem.GetComponent<ItemList>());
            }
        }

    }

    void RefreshItensList()
    {
        for (int i = 0; i < itens.Count; i++)
        {
            Destroy(itens[i].gameObject);
        }
        itens.Clear();
    }

    void UpdateAtributes()
    {
        healthText.text = "Vida: " + player.GetHealth() + "/" + inventory.health;
        manaText.text = "Vitalidade: " + player.GetMana() + "/" + inventory.mana;
        strengthText.text = "Força: " + inventory.strength;
        attackText.text = "Ataque: " + (inventory.strength + player.GetComponentInChildren<Attack>().GetDamage());
        defenseText.text = "Defesa: " + player.defense;
    }

    public void UpdateUI()
    {

        healthUI.text = player.GetHealth() + " / " + inventory.health;
        manaUI.text = player.GetMana() + " / " + inventory.mana;
        coinsUI.text = "BugCoins: " + inventory.bugCoins;
        potionUI.text = "x" + inventory.CountItens(player.item);
        sliderHealth.value = player.GetHealth() + inventory.health;
        sliderMana.value = player.GetMana() + inventory.mana;
        sliderStrength.value = inventory.CountItens(player.item);

    }

    public void SetMessage(string message)
    {
        messageText.text = message;
        Color color = messageText.color;
        messageText.color = color;
        isMessageActive = true;
    }
}
