using UnityEngine;
using System.Collections;

public class SpaceTravelGame : BaseMicrogame {
	
	public SpaceTravelGame(int difficulty) :base (difficulty) {
		Debug.Log ("Space Travel Game Setup");
		
		int winAmt = 30 + (difficulty -1) * 5;
		mechanic = new SpaceCombatMechanic(difficultyLevel, winAmt, 1);
		gameName = "Space Travel";
	}
	
	protected override void SetupDifficulty(int difficulty){
		
	}
}
