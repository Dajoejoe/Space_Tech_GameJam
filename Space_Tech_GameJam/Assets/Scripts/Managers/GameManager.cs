using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	protected enum GameState {
		Intro, Play, Win, Lose
	}

	public BaseMicrogame baseGame;
	protected GameState gameState;
	protected float timer;

	// Use this for initialization
	protected virtual void Start () {
		gameState = GameState.Intro;
	}
	
	// Update is called once per frame
	protected virtual void Update () {
		baseGame.mechanic.GetInput.Update();

		if (gameState == GameState.Intro) {
			Intro();
		}
		else if (gameState == GameState.Play) {
			Play ();
		}
		else if (gameState == GameState.Win) {
			Win ();
		}
		else if (gameState == GameState.Lose) {
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
