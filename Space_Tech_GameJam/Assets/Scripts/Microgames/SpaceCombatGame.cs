﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum CombatMode {
	Attack, Defend
}

public class SpaceCombatGame : BaseMicrogame {

	public CombatMode mode;
	public float attackTime;
	public int defensePresses;
	public float defenceDelay;

	public SpaceCombatGame(int difficulty) :base (difficulty) {
		Debug.Log ("Space Combat Game Root");

		mechanic = new SpaceCombatMechanic(difficultyLevel);
		gameName = "Space Combat";
	}

	protected override void SetupDifficulty(int difficulty){
		Debug.Log ("Setup Space Game Difficulty");

		difficultyLevel = difficulty;

		result = -1;

		switch (difficultyLevel)
		{
		case 1:
			attackTime = 3;
			defensePresses = 5;
			defenceDelay = 1.5f;
			break;
		case 2:
			attackTime = 2.5f;
			defensePresses = 6;
			defenceDelay = 1.25f;
			break;
		default:
			break;
		}
	}


}