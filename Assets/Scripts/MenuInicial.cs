using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicial : MonoBehaviour {

    public void StartButton()
    {
        SceneManager.LoadScene("Loading");
    }

    public void Option()
    {
        SceneManager.LoadScene("Opition");
    }

    public void ExitMenu()
    {
        SceneManager.LoadScene("MenuInicial");
    }
    public void ExitGame()
    {
        Application.Quit();
    }


}
