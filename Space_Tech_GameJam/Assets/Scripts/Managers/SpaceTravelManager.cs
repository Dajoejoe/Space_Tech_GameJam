﻿using UnityEngine;
using System.Collections;

public class SpaceTravelManager : GameManager {

	SpaceTravelGame microGame;

	public ShipPlayer player;
	public GameObject[] difficulties;

	protected override void Start () {
		base.Start();
		microGame = (SpaceTravelGame)baseGame;
		microGame.mechanic.winCondition.metDelegate += new ConditionMet(ConditionMet);
		microGame.mechanic.loseCondition.metDelegate += new ConditionMet(ConditionMet);

		if (player == null) {
			player = GameObject.FindGameObjectWithTag("Player").GetComponent<ShipPlayer>();
		}
		player.gameManager = this;

		difficulties[GlobalGameManager.globalDifficulty-1].SetActive(true);

	}
	
	// Update is called once per frame
	protected override void Update () {
		base.Update();
	}
	
	#region Overrides
	protected override void Intro ()
	{
		base.Intro ();
		timer -= Time.deltaTime;
		if (timer <= 0) {
			Debug.Log ("Start Play");
			gameState = GameState.Play;
		}
	}
	
	protected override void Play ()
	{
		base.Play ();

		
		timer -= Time.deltaTime;
		if (timer <= 0) {			
		}

	}
	
	protected override void Win ()
	{
		base.Win ();
		timer -= Time.deltaTime;
		if (timer <= 0) {
			GlobalGameManager.Advance();
		}
	}
	
	protected override void Lose ()
	{
		base.Lose ();
		timer -= Time.deltaTime;
		if (timer <= 0) {
			GlobalGameManager.Advance();
		}
	}
	
	public override void ProcessInput (KeyCode key)
	{
		base.ProcessInput (key);
		
		if (gameState != GameState.Play) {
			return;
		}
		player.ProcessInput(key);

	}
	
	protected override void UpdateDisplay ()
	{
		base.UpdateDisplay ();

	}
	
	protected override void ConditionMet (Condition condition)
	{
		if (gameState != GameState.Play)
			return;

		if (microGame.mechanic.isWinCondition(condition)) {
			Debug.Log ("Win Condition Met");
			gameState = GameState.Win;
			GlobalGameManager.SetResult(true,0);
			timer = 2;
			uiScreens[0].SetActive(true);
		}
		else if (microGame.mechanic.isLoseCondition(condition)) {
			Debug.Log ("Lose Condition Met");
			gameState = GameState.Lose;
			GlobalGameManager.SetResult(false,baseGame.result);
			timer = 2;
			uiScreens[1].SetActive(false);
		}
		else {
			throw new UnityException("Error with game condition: Condition met is neither the win or the lose condition");
		}
	}
	
	#endregion

	#region Class Specific

	public void ReachedEnd() {
		microGame.mechanic.winCondition.AddAmt(1);
		Debug.Log ("end");
	}

	public void Crashed() {
		microGame.mechanic.loseCondition.AddAmt(1);
	}
	#endregion
}
