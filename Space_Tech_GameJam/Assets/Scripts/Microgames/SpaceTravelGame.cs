using UnityEngine;
using System.Collections;

public class SpaceTravelGame : BaseMicrogame {
	
	public SpaceTravelGame(int difficulty) :base (difficulty) {
		Debug.Log ("Space Travel Game Setup");
		result = -1;
		
		mechanic = new SpaceTravelMechanic(difficultyLevel, 1, 1);
		gameName = "Space Travel";
	}
	
	protected override void SetupDifficulty(int difficulty){
		
	}
}
