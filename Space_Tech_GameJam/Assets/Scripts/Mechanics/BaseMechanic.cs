using UnityEngine;
using System.Collections;

public abstract class BaseMechanic  {

	protected BaseInput input;

	public Condition winCondition;
	public Condition loseCondition;

	public BaseInput GetInput{get{ return input;}}

	protected float winAmt;
	protected float loseAmt;
	protected float speedModifier = 1;

	public BaseMechanic(float winAmt, float loseAmt) {
		SetupConditions(winAmt,loseAmt);
	}
	
	protected virtual void SetupConditions (float winAmt, float loseAmt)
	{
		Debug.Log ("Conditions Setup");
		winCondition = new Condition(Condition.ConditionType.Time, winAmt);
		loseCondition = new Condition(Condition.ConditionType.LiveLoss,loseAmt);
	}

	public bool isWinCondition(Condition condition) { return condition.Equals(winCondition); }
	public bool isLoseCondition(Condition condition) { return condition.Equals(loseCondition); }
}
