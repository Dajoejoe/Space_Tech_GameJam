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
		Debug.Log ("Base Mechanic");
		SetupConditions(winAmt,loseAmt);
	}

	protected abstract void SetupConditions(float winAmt, float loseAmt);

	public bool isWinCondition(Condition condition) { return condition.Equals(winCondition); }
	public bool isLoseCondition(Condition condition) { return condition.Equals(loseCondition); }
}
