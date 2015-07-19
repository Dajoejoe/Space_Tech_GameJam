using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour {

	public bool move;
	public int speed;

	// Use this for initialization
	void Start () {
		GameObject.FindGameObjectWithTag("GlobalManager").transform.parent = transform;
	}
	
	// Update is called once per frame
	void Update () {
		if (move)
			transform.position += Vector3.right * speed *Time.deltaTime;
	}
}
