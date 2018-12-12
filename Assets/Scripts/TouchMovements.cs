using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchMovements : MonoBehaviour {

    public MoveCharacter mc;

    public bool Left;

    private void OnMouseDrag()
    {
        Debug.Log("Acertou");
        if (Left == true)
        {
            mc.MoveLeft();
        }
        else
        {
            mc.MoveRight();
        }
    }
}
