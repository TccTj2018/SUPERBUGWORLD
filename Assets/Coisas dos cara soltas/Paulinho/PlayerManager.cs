using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

	// Use this for initialization
	#region Singleton
	public static PlayerManager instance;
	void Awake ()
	{
		instance = this;
	}
	#endregion

	public GameObject player;
}
