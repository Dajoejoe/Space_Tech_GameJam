using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpaceCombatMechanic : BaseMechanic {

	public SpaceCombatMechanic(int difficulty, float winAmt, float loseAmt) : base(winAmt, loseAmt)
	{
		Debug.Log ("Space Combat Mechanic Setup");
		input = new SpaceCombatInput();
		input.ConfigureForDifficulty(difficulty);
	}

}
