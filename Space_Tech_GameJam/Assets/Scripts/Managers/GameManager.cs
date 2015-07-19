using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

	protected enum GameState {
		Intro, Play, Win, Lose
	}

	public BaseMicrogame baseGame;

	public GameObject[] uiScreens;

	protected GameState gameState;
	protected float timer;
	protected List<KeyCode> keys;
	protected List<KeyCode> lastKeys;

	// Use this for initialization
	protected virtual void Start () {
		gameState = GameState.Intro;

		foreach (GameObject go in uiScreens) {
			go.SetActive(false);
		}

	}
	
	// Update is called once per frame
	protected virtual void Update () {
		baseGame.mechanic.GetInput.Update();

		if (gameState == GameState.Intro) {
			if (!uiScreens[0].activeSelf)
				uiScreens[0].SetActive(true);
			Intro();
		}
		else if (gameState == GameState.Play) {
			if (uiScreens[0].activeSelf)
				uiScreens[0].SetActive(false);
			Play ();
		}
		else if (gameState == GameState.Win) {
			if (!uiScreens[1].activeSelf)
				uiScreens[1].SetActive(true);
			Win ();
		}
		else if (gameState == GameState.Lose) {
			if (!uiScreens[2].activeSelf)
				uiScreens[2].SetActive(true);
			Lose();
		}
	}

	protected virtual void Intro(){}
	protected virtual void Play(){}
	protected virtual void Win(){}
	protected virtual void Lose(){}
	protected virtual void UpdateDisplay(){}
	protected virtual void ConditionMet(Condition condition){}

	public virtual void ProcessInput(KeyCode key) {}

}
