using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class GlobalGameManager : MonoBehaviour {

	List<Type> gameTypes;

	public GameObject healthBar;
	public GameObject gameOverScreen;

	public static Type nextGame;
	public static Type previousGame;

	public static int health;
	public static int levelsCompleted;
	public static int globalDifficulty;
	static int level;

	static bool exists;
	static bool displayNeedsUpdate;
	static bool replay;

	void Awake () {

		if (exists) {
			Destroy(gameObject);
			return;
		}

		exists = true;
		DontDestroyOnLoad(this);
		AddGameTypes();

		Reset ();
	}

	// Use this for initialization
	// This is temporary until we click to start
	void Start () {
		string scene = "Scene_" + nextGame.ToString();
		Application.LoadLevel(scene);
	}

	public void Reset() {
		Debug.Log ("Reset");
		globalDifficulty = 1;
		health = 3;
		levelsCompleted = 0;
		level = 0;

		foreach (Transform bar in healthBar.transform) {
			bar.gameObject.SetActive(true);
		}

		gameOverScreen.SetActive(false);

		SetLevel ();
	}

	// Auto load the next level
	void OnLevelWasLoaded(int level) {
		if (level != 0)
			return;

		if (!replay)
			SetLevel();
		string scene = "Scene_" + nextGame.ToString();
		Application.LoadLevel(scene);
	}

	// Handle setting the levels
	void SetLevel () {
		nextGame = gameTypes[level];
		level = (level + 1) % gameTypes.Count;
	}

	// Update is called once per frame
	void Update () {
		if (displayNeedsUpdate) {
			UpdateDisplay();
		}
	}

	void AddGameTypes () {
		gameTypes = new List<Type>();
		gameTypes.Add(typeof(CryoGame));
		gameTypes.Add(typeof(SpaceCombatGame));
		gameTypes.Add(typeof(SpaceTravelGame));
	}

	public static void SetResult(bool won, int result) {
		displayNeedsUpdate = true;
		health += result;
		replay = !won;
		Debug.Log ("Replay: " + replay + " " + result + " " + health);
	}

	void UpdateDisplay() {
		displayNeedsUpdate = false;

		if (health <= 0) {
			Debug.Log ("Set Game over");
			Reset ();
		}

		Transform bar = healthBar.transform.FindChild(health.ToString());
		if (bar)
			bar.gameObject.SetActive(false);
	}
}
