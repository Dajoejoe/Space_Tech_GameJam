using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour {

	public bool move;
	public float speed;

	// Use this for initialization
	void Start () {
		transform.position = new Vector3(0, (GlobalGameManager.globalDifficulty -1) * -10);
		speed = 3 + (GlobalGameManager.globalDifficulty - 1) * 1.5f;
	}
	
	// Update is called once per frame
	void Update () {
		if (move)
			transform.position += Vector3.right * speed *Time.deltaTime;
	}
}
