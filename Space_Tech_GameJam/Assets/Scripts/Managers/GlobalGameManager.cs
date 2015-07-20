using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class GlobalGameManager : MonoBehaviour {

	List<Type> gameTypes;

	public GameObject healthBar;
	public GameObject gameOverScreen;
	public GameObject winScreen;


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
	static bool started;

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
		started = false;

		foreach (Transform bar in healthBar.transform) {
			bar.gameObject.SetActive(true);
		}

		gameOverScreen.SetActive(false);
		winScreen.SetActive(false);
	}

	// Auto load the next level
	void OnLevelWasLoaded(int level) {
		if (!started)
			return;

		if (level > 1  || health <= 0 || loaded)
		{		
			healthBar.SetActive(true);
			transform.parent = Camera.main.transform;
			transform.localPosition = new Vector3(0,0,10);
			return;
		}
		healthBar.SetActive(false);

		loaded = true;
	}

	// Handle setting the levels
	void SetLevel () {
		Debug.Log ("level " + level);		
		if (level == 0)
		{
			globalDifficulty ++;
		}
		if (globalDifficulty == 4)
		{
			SetWin();
			return;
		}
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
				SetLevel();
				StartGame();
			}
			else if (Input.GetKeyDown(KeyCode.Escape)) {
				Application.Quit();
			}
		}

		if (advance) {
			transform.parent = null;
			advance = false;

			if (health <= 0) {
				SetGameOver();
			}
			else {
				loaded = false;
				//Application.LoadLevel("Scene_Main");
				
				if (!replay)
					SetLevel();
				string scene = "Scene_" + nextGame.ToString();
				CallLevelLoad.SetLevelLoad(scene,.5f,true,false);
			}
		}
	}

	void AddGameTypes () {
		gameTypes = new List<Type>();
		gameTypes.Add(typeof(CryoGame));
		gameTypes.Add(typeof(SpaceCombatGame));
		gameTypes.Add(typeof(SpaceTravelGame));
	}

	public static void StartGame() {
		started = true;
		Advance();
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

	void SetWin() {
		winScreen.SetActive(true);

	}

}
