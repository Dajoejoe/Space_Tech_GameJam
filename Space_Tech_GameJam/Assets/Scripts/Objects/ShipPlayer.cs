using UnityEngine;
using System.Collections;

public class ShipPlayer : MonoBehaviour {
	
	public float acceleration;
	public float deceleration;
	public float maxSpeed;
	float speed;
	Vector3 direction;
	Vector3 velocity;

	Rect bounds;
	Transform _transform;
	// Use this for initialization
	void Start () {
		_transform = transform;
//		acceleration = 0.1f;
//		deceleration = 0.1f;
//		maxSpeed = 1;
		direction = Vector3.zero;
		velocity = Vector3.zero; 
	}
	
	// Update is called once per frame
	void Update () {		
		direction = Vector3.zero;

		GetInput();
		UpdateMovement();
	}

	public void UpdateMovement() {
		if (direction == Vector3.zero)
			velocity *= deceleration;
		else 
		{
			velocity += direction * acceleration;
		}

		_transform.localPosition += velocity;
	}

	public void ProcessInput(KeyCode key) {
		Vector3 newDirection = Vector3.zero;

		if (key == KeyCode.W) {
			newDirection += Vector3.up;
		}
		if (key == KeyCode.S) {
			newDirection += Vector3.down;
		}

		newDirection.Normalize();
		direction = newDirection;

	}

	void GetInput() {
		if (Input.GetKey(KeyCode.A)) {
			ProcessInput(KeyCode.A);
		}
		if (Input.GetKey(KeyCode.S)) {
			ProcessInput(KeyCode.S);
		}
		if (Input.GetKey(KeyCode.D)) {
			ProcessInput(KeyCode.D);
		}
		if (Input.GetKey(KeyCode.W)) {
			ProcessInput(KeyCode.W);
		}
	}
}
