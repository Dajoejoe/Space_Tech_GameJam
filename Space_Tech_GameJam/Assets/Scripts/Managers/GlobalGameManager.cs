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
	static bool advance;
	static bool loaded;

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
		healthBar.SetActive(false);
	}

	public void Reset() {
		Debug.Log ("Reset");
		transform.parent = null;

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

		if (level != 0 || health <= 0 || loaded)
		{		
			healthBar.SetActive(true);
			return;
		}
		healthBar.SetActive(false);

		loaded = true;
		if (!replay)
			SetLevel();
		string scene = "Scene_" + nextGame.ToString();
		Application.LoadLevel(scene);
	}

	// Handle setting the levels
	void SetLevel () {
		Debug.Log ("level " + level);
		nextGame = gameTypes[level];
		level = (level + 1) % gameTypes.Count;
	}

	// Update is called once per frame
	void Update () {
		if (displayNeedsUpdate) {
			UpdateDisplay();
		}

		if (health <= 0) {
			if (Input.GetKeyDown(KeyCode.Space)) {
				Reset ();
				Application.LoadLevel("Scene_Main");
			}
			else if (Input.GetKeyDown(KeyCode.Escape)) {
				Application.Quit();
			}
		}
		else if (Application.loadedLevel == 0 && Input.GetKeyDown(KeyCode.Space)) {
			string scene = "Scene_" + nextGame.ToString();

			Application.LoadLevel(scene);
		}

		if (advance) {
			transform.parent = null;
			advance = false;
			if (health <= 0) {
				SetGameOver();
			}
			else {
				loaded = false;
				Application.LoadLevel("Scene_Main");
			}
		}
	}

	void AddGameTypes () {
		gameTypes = new List<Type>();
		gameTypes.Add(typeof(SpaceCombatGame));
		gameTypes.Add(typeof(SpaceTravelGame));
		gameTypes.Add(typeof(CryoGame));
	}

	public static void SetResult(bool won, int result) {
		displayNeedsUpdate = true;
		health += result;
		replay = !won;

		Debug.Log ("Replay: " + replay + " " + result + " " + health);
	}

	public static void Advance() {
		advance = true;
	}

	void UpdateDisplay() {
		displayNeedsUpdate = false;

		Transform bar = healthBar.transform.FindChild(health.ToString());
		if (bar)
			bar.gameObject.SetActive(false);
	}

	void SetGameOver() {
		gameOverScreen.SetActive(true);
		gameOverScreen.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = Resources.LoadAll<Sprite>("Sprites/UI/Text_NumbersSheet")[levelsCompleted];
	}
}
