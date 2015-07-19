using UnityEngine;
using System.Collections;

public class CryoGame : BaseMicrogame {
	
	public CryoGame(int difficulty) :base (difficulty) {
		Debug.Log ("Cryo Game Setup");
		result = -1;

		int winAmt = 12 + (difficulty -1) * 3;
		mechanic = new CryoMechanic(difficultyLevel, winAmt, 1);
		gameName = "Cryo Management";
	}
	
	protected override void SetupDifficulty(int difficulty){

	}
}
