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

	protected override void SetupConditions (float winAmt, float loseAmt)
	{
		Debug.Log ("Space Game Conditions Setup");
		winCondition = new Condition(Condition.ConditionType.LiveLoss, winAmt);
		loseCondition = new Condition(Condition.ConditionType.LiveLoss,loseAmt);
	}

}
