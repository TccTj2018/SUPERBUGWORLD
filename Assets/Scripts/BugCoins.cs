using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugCoins : MonoBehaviour {

    public int bugCoins;
    public static BugCoins instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (this != instance)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        Fight player = other.GetComponent<Fight>();
        if (player != null)
        {

            player.bugCoins += bugCoins;
            FindObjectOfType<UIManager>().UpdateUI();
            gameObject.SetActive(false);
        }
    }

}

