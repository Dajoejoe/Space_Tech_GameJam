using UnityEngine;
using System.Collections;

public class ShipPlayer : MonoBehaviour {

	public SpaceTravelManager gameManager;
	CameraMove camera;

	public float acceleration;
	public float deceleration;
	float speed;
	Vector3 direction;
	Vector3 velocity;

	float minY = -2.9f;
	float maxY = 2.1f;
	Transform _transform;
	
	public GameObject shield;
	public GameObject shieldUI;
	bool shieldUp;
	float shieldTime;
	int shieldEnergy;

	// Use this for initialization
	void Start () {
		_transform = transform;
//		acceleration = 0.1f;
//		deceleration = 0.1f;
//		maxSpeed = 1;
		direction = Vector3.zero;
		velocity = Vector3.zero; 
		shieldEnergy = 3;
		camera = transform.parent.GetComponent<CameraMove>();
		camera.move = true;
		ChangeShield(false);
	}
	
	// Update is called once per frame
	void Update () {		

		if (shieldUp) {
			shieldTime -= Time.deltaTime;
			if (shieldTime <= 0)
				ChangeShield(false);
		}

		//GetInput();
		UpdateMovement();
	}

	public void UpdateMovement() {
		if (direction == Vector3.zero)
			velocity *= deceleration;
		else 
		{
			velocity += direction * acceleration;
		}

		Vector3 pos = _transform.localPosition;
		pos += velocity;
		if (pos.y < minY) {
			pos.y = minY;
			velocity = Vector3.zero;
		}
		if (pos.y > maxY) {
			pos.y = maxY;
			velocity = Vector3.zero;
		}
		_transform.localPosition = pos;
		direction = Vector3.zero;
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

		if (key == KeyCode.Space && shieldEnergy > 0 && !shieldUp) {
			ChangeShield(true);
			shieldTime = 1;
			shieldEnergy --;
			shieldUI.transform.FindChild(shieldEnergy.ToString()).gameObject.SetActive(false);
		}
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

	void ChangeShield(bool on) {
		shield.SetActive(on);
		shieldUp = on;
	}

	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.tag == "End") {
			gameManager.ReachedEnd();
			camera.move = false;
		}
		else if (collider.tag == "LargeAsteroid") {
			velocity = Vector3.zero;
			camera.move = false;
			gameManager.Crashed();
		}
		else if (collider.tag == "SmallAsteroid") {
			if (shieldUp) {
				Destroy(collider.gameObject);
			}
			else {
				velocity = Vector3.zero;
				camera.move = false;
				gameManager.Crashed();
			}
		}
		else if (collider.tag == "Blackhole") {
			Debug.Log ("balckhole");
		}
	}

	void OnTriggerStay2D(Collider2D collider) {
		if (collider.tag == "Blackhole") {
			float dif = collider.transform.position.y - transform.position.y;
			float str = collider.bounds.extents.magnitude - dif;

			velocity += Mathf.Sign(dif) * Vector3.up   * str * Time.deltaTime;
		}
	}
}
