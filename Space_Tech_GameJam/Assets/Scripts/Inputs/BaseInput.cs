using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BaseInput : MonoBehaviour {

	List<KeyCode> accepteKeys;

	void Update () {
		foreach (KeyCode key in accepteKeys) {
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

	protected virtual void HandleKeyDown(KeyCode key){}
	protected virtual void HandleKeyUp(KeyCode key){}
	protected virtual void HandleKey(KeyCode key){}
}
