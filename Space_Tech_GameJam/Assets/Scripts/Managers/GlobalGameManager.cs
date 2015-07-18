using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class GlobalGameManager : MonoBehaviour {

	List<Type> gameTypes;

	public static Type nextGame;
	public static Type previousGame;

	public static int health;
	public static int globalDifficulty;

	static bool exists;

	void Awake () {

		if (exists) {
			Destroy(gameObject);
		}
		exists = true;
		DontDestroyOnLoad(this);
		AddGameTypes();
		Init ();
	}

	// Use this for initialization
	void Start () {
	}

	// Handle the initial values
	void Init () {
		nextGame = gameTypes[0];
		globalDifficulty = 1;
	}

	// Update is called once per frame
	void Update () {
	
	}

	void AddGameTypes () {
		gameTypes = new List<Type>();
		gameTypes.Add(typeof(CryoGame));
		gameTypes.Add(typeof(SpaceCombatGame));
	}
}
