using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public delegate void ProcessKey(KeyCode key);

public class BaseInput {

	protected List<KeyCode> acceptedKeys;
	protected ProcessKey processDelegate;

	public List<KeyCode> GetKeys { get {return this.acceptedKeys;}}
	public ProcessKey ProcessDelegate { get {return processDelegate;} set { processDelegate = value;}}

	public void Update () {
		foreach (KeyCode key in acceptedKeys) {
			if (Input.GetKeyDown(key)) {
				HandleKeyDown(key);
			}
			else if (Input.GetKeyUp(key)) {
				HandleKeyUp(key);
			}
			else if (Input.GetKey(key)) {
				HandleKey(key);
			}
		}
	}

	public virtual void ConfigureForDifficulty(int difficulty){}

	protected virtual void HandleKeyDown(KeyCode key){ if (processDelegate != null) processDelegate(key);}
	protected virtual void HandleKeyUp(KeyCode key){if (processDelegate != null) processDelegate(key);}
	protected virtual void HandleKey(KeyCode key){if (processDelegate != null) processDelegate(key);}
}
