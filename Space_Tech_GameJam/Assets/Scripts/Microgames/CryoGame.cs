using UnityEngine;
using System.Collections;

public class CryoGame : BaseMicrogame {
	
	public CryoGame(int difficulty) :base (difficulty) {
		Debug.Log ("Cryo Game Root");
		
		int winAmt = 10 + (difficulty -1) * 5;
		mechanic = new SpaceCombatMechanic(difficultyLevel, winAmt, 1);
		gameName = "Cryo Management";
	}
	
	protected override void SetupDifficulty(int difficulty){

	}
}
