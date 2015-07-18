using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class GlobalGameManager : MonoBehaviour {

	List<Type> gameTypes;

	public static Type nextGame;
	public static Type previousGame;

	void Awake () {
		DontDestroyOnLoad(this);
		AddGameTypes();
		nextGame = gameTypes[0];
	}
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void AddGameTypes () {
		gameTypes = new List<Type>();
		gameTypes.Add(typeof(SpaceCombat));
	}
}
