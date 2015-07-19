using UnityEngine;
using System.Collections;

public class CryoMechanic : BaseMechanic {
	
	public CryoMechanic(int difficulty, float winAmt, float loseAmt) : base(winAmt, loseAmt)
	{
		Debug.Log ("Cryo Mechanic Setup");
		input = new CryoInput();
		input.ConfigureForDifficulty(difficulty);
	}

}
