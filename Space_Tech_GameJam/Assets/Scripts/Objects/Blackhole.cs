using UnityEngine;
using System.Collections;

public class Blackhole : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2d(Collider2D collider) {
		Debug.Log("in range");
	}
	void OnTriggerStay2d(Collider2D collider) {
		Debug.Log("stay in range");
	}
	void OnTriggerExit2d(Collider2D collider) {
		Debug.Log("exit range");
	}
}
