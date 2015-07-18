using UnityEngine;
using System.Collections;
using System;

public class MicrogameObject : MonoBehaviour {

	public BaseMicrogame microGame;

	// Use this for initialization
	void Start () {
		Debug.Log (GlobalGameManager.nextGame);
		this.microGame = (BaseMicrogame)Activator.CreateInstance(GlobalGameManager.nextGame);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
