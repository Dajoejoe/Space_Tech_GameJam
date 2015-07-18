using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpaceCombatMechanic : BaseMechanic {

	public SpaceCombatMechanic(int difficulty) : base()
	{
		Debug.Log ("Space Combat Mechanic Root");
		input = new SpaceCombatInput();
		input.ConfigureForDifficulty(difficulty);
	}

	protected override void SetupConditions ()
	{
		Debug.Log ("Space Game Conditions Setup");
		winCondition = new Condition(Condition.ConditionType.LiveLoss, 10);
		loseCondition = new Condition(Condition.ConditionType.LiveLoss,1);
	}

}
