using UnityEngine;
using System.Collections;

public class CryoGame : BaseMicrogame {
	
	public CryoGame(int difficulty) :base (difficulty) {
		Debug.Log ("Cryo Game Setup");

		int winAmt = 15 + (difficulty -1) * 5;
		mechanic = new CryoMechanic(difficultyLevel, winAmt, 1);
		gameName = "Cryo Management";
	}
	
	protected override void SetupDifficulty(int difficulty){

	}
}
