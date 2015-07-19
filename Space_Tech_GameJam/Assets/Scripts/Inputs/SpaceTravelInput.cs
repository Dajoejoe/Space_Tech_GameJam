using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpaceTravelInput : BaseInput {

	public override void ConfigureForDifficulty (int difficulty)
	{
		base.ConfigureForDifficulty (difficulty);
		Debug.Log ("Cryo Game Input Setup");
		
		List<KeyCode> keys = new List<KeyCode>();
		
		keys.Add(KeyCode.W);
		keys.Add(KeyCode.A);
		keys.Add(KeyCode.S);
		keys.Add(KeyCode.D);
		keys.Add(KeyCode.Space);
		
		this.acceptedKeys = keys;
	}
	
	protected override void HandleKeyDown(KeyCode key){ if (processDelegate != null) processDelegate(key);}
	protected override void HandleKeyUp(KeyCode key){}
	protected override void HandleKey(KeyCode key){ if (processDelegate != null) processDelegate(key);}
}
