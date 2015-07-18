using UnityEngine;
using System.Collections;

public class BaseMechanic  {

	BaseInput input;
	Condition winCondition;
	Condition loseCondition;

	float speedModifier = 1;

	public BaseMechanic() {
		winCondition.metDelegate += new ConditionMet(ConditionMet);
		loseCondition.metDelegate = new ConditionMet(ConditionMet);
	}


	protected void ConditionMet(Condition condition) {
		if (condition == this.winCondition) {
			Debug.Log ("Win condition Met");
		}
		else if (condition == this.loseCondition) {
			Debug.Log ("Lost condition Met");
		}

	}

}
