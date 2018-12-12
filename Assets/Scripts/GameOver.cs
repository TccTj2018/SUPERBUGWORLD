using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

    public GameManager gm;
   
 
    public void trocacena()
    {
        SceneManager.LoadScene("Fase 1");
        gm.health = 100;
    }
}