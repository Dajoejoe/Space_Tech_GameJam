using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CryoInput : BaseInput {

	public override void ConfigureForDifficulty (int difficulty)
	{
		base.ConfigureForDifficulty (difficulty);
		Debug.Log ("Configure Cryo Game Input");
		
		List<KeyCode> keys = new List<KeyCode>();

		keys.Add(KeyCode.Q);
		keys.Add(KeyCode.W);
		keys.Add(KeyCode.E);
		keys.Add(KeyCode.R);
		keys.Add(KeyCode.A);
		keys.Add(KeyCode.S);
		keys.Add(KeyCode.D);
		keys.Add(KeyCode.F);
		keys.Add(KeyCode.Z);
		keys.Add(KeyCode.X);
		keys.Add(KeyCode.C);
		keys.Add(KeyCode.V);

		this.acceptedKeys = keys;
	}
	
	protected override void HandleKeyDown(KeyCode key){ if (processDelegate != null) processDelegate(key);}
	protected override void HandleKeyUp(KeyCode key){}
	protected override void HandleKey(KeyCode key){}
}
