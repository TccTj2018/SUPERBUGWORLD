using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicial : MonoBehaviour {

    public void ButtonInicial()
    {
        SceneManager.LoadScene("LevelHUD");
    }
    public void ButtonOption()
    {
        SceneManager.LoadScene("Option");
    }

    public void ButtonExit()
    {

        Application.Quit();
    }

}
