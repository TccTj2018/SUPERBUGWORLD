using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrocaCena : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.tag == "Player")
        {

        }

        SceneManager.LoadScene(1);
    }
}
