using UnityEngine;
using System.Collections;

public class SplashSceen : MonoBehaviour {

	float timer;

	// Use this for initialization
	void Start () {
		timer = 5;
	}
	
	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;
		if (timer <= 0) {
			CallLevelLoad.SetLevelLoad(1,.5f,true);
			timer = 10;
		}
	}
}
