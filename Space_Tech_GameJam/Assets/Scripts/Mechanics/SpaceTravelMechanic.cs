using UnityEngine;
using System.Collections;

public class SpaceTravelMechanic : BaseMechanic {
	
	public SpaceTravelMechanic(int difficulty, float winAmt, float loseAmt) : base(winAmt, loseAmt)
	{
		Debug.Log ("Space Travel Mechanic Setup");
		input = new CryoInput();
		input.ConfigureForDifficulty(difficulty);
	}

}
