using UnityEngine;
using System.Collections;

public abstract class BaseMechanic  {

	protected BaseInput input;

	public Condition winCondition;
	public Condition loseCondition;

	public BaseInput GetInput{get{ return input;}}

	float speedModifier = 1;

	public BaseMechanic() {
		Debug.Log ("Base Mechanic");
		SetupConditions();
	}

	protected abstract void SetupConditions();

	public bool isWinCondition(Condition condition) { return condition.Equals(winCondition); }
	public bool isLoseCondition(Condition condition) { return condition.Equals(loseCondition); }
}
