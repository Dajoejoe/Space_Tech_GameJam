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
	static int level;

	void Awake () {

		if (exists) {
			Destroy(gameObject);
		}
		health = 5;
		exists = true;
		DontDestroyOnLoad(this);
		AddGameTypes();
		Init ();
	}

	// Use this for initialization
	void Start () {
		string scene = "Scene_" + nextGame.ToString();
		Application.LoadLevel(scene);
	}

	void OnLevelWasLoaded(int level) {
		Debug.Log ("loaded");
		if (level != 0)
			return;

		string scene = "Scene_" + nextGame.ToString();
		Application.LoadLevel(scene);
	}

	// Handle the initial values
	void Init () {
		nextGame = gameTypes[level];
		globalDifficulty = 1;
		level = (level + 1) % gameTypes.Count;
	}

	// Update is called once per frame
	void Update () {
	
	}

	void AddGameTypes () {
		gameTypes = new List<Type>();
		gameTypes.Add(typeof(SpaceTravelGame));
		gameTypes.Add(typeof(CryoGame));
		gameTypes.Add(typeof(SpaceCombatGame));
	}
}
