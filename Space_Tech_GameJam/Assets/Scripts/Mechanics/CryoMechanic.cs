using UnityEngine;
using System.Collections;

public class CryoMechanic : BaseMechanic {
	
	public CryoMechanic(int difficulty, float winAmt, float loseAmt) : base(winAmt, loseAmt)
	{
		Debug.Log ("Cryo Mechanic Root");
		input = new SpaceCombatInput();
		input.ConfigureForDifficulty(difficulty);
	}
	
	protected override void SetupConditions (float winAmt, float loseAmt)
	{
		Debug.Log ("Cryo Conditions Setup");
		winCondition = new Condition(Condition.ConditionType.Time, winAmt);
		loseCondition = new Condition(Condition.ConditionType.LiveLoss,loseAmt);
	}
}
