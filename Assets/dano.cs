using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dano : MonoBehaviour {

    public PlayerHealth ph;
    
    private void OnTriggerEnter(Collider other)
    {
        ph.VidaDoPlayer -= 5;
        
    }
}
