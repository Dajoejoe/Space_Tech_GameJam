using UnityEngine;
using System.Collections;

public class SpaceTravelGame : BaseMicrogame {
	
	public SpaceTravelGame(int difficulty) :base (difficulty) {
		Debug.Log ("Space Travel Game Setup");
		
		mechanic = new SpaceCombatMechanic(difficultyLevel, 1, 1);
		gameName = "Space Travel";
	}
	
	protected override void SetupDifficulty(int difficulty){
		
	}
}
