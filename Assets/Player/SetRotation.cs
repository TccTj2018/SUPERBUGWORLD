using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetRotation : MonoBehaviour {

    public Transform player;

    void Update () {

        gameObject.transform.rotation = player.rotation;


    }
}
