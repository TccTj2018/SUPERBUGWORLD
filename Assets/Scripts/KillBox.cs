using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillBox : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {

        Debug.Log(other.gameObject.tag);

        if (other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
