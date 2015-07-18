using UnityEngine;
using System.Collections;

public class BaseMicrogame  {

	float time;
	BaseMechanic mechanic;
	int result;
	int difficultyLevel;

	public BaseMicrogame() {
		SetupDifficulty();
	}

	protected virtual void SetupDifficulty(){}
}
