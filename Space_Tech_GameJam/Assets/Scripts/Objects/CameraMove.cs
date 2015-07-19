using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour {

	public bool move;
	public int speed;

	// Use this for initialization
	void Start () {

		GameObject global = GameObject.FindGameObjectWithTag("GlobalManager");
		global.transform.parent = transform;
		global.transform.localPosition = new Vector3(0,0,10);
	}
	
	// Update is called once per frame
	void Update () {
		if (move)
			transform.position += Vector3.right * speed *Time.deltaTime;
	}
}
