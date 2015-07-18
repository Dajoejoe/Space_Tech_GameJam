﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpaceCombatInput : BaseInput {
	
	public override void ConfigureForDifficulty (int difficulty)
	{
		base.ConfigureForDifficulty (difficulty);
		Debug.Log ("Configure Space Game Input");

		List<KeyCode> keys = new List<KeyCode>();
		switch (difficulty)
		{
		case 1:
			keys.Add(KeyCode.T);
			keys.Add(KeyCode.F);
			keys.Add(KeyCode.H);
			break;
		case 2:
			keys.Add(KeyCode.T);
			keys.Add(KeyCode.F);
			keys.Add(KeyCode.H);
			keys.Add(KeyCode.C);
			keys.Add(KeyCode.N);
			break;
		default:
			keys.Add(KeyCode.T);
			keys.Add(KeyCode.F);
			keys.Add(KeyCode.H);
			break;
		}
		keys.Add(KeyCode.Space);
		this.acceptedKeys = keys;
	}
	
	protected override void HandleKeyDown(KeyCode key){ if (processDelegate != null) processDelegate(key);}
	protected override void HandleKeyUp(KeyCode key){}
	protected override void HandleKey(KeyCode key){}
}
