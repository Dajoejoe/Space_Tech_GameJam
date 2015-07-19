using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpaceCombatInput : BaseInput {
	
	public override void ConfigureForDifficulty (int difficulty)
	{
		base.ConfigureForDifficulty (difficulty);
		Debug.Log ("Space Game Input Setup");

		List<KeyCode> keys = new List<KeyCode>();
		switch (difficulty)
		{
		case 1:
			keys.Add(KeyCode.A);
			keys.Add(KeyCode.W);
			keys.Add(KeyCode.D);
			break;
		case 2:
			keys.Add(KeyCode.A);
			keys.Add(KeyCode.W);
			keys.Add(KeyCode.D);
			keys.Add(KeyCode.S);
			break;
		default:
			keys.Add(KeyCode.A);
			keys.Add(KeyCode.W);
			keys.Add(KeyCode.D);
			keys.Add(KeyCode.S);
			break;
		}
		keys.Add(KeyCode.Space);
		this.acceptedKeys = keys;
	}
	
	protected override void HandleKeyDown(KeyCode key){ if (processDelegate != null) processDelegate(key);}
	protected override void HandleKeyUp(KeyCode key){}
	protected override void HandleKey(KeyCode key){}
}
