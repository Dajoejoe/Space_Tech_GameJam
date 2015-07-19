using UnityEngine;
using System.Collections;

public class CryoContainer : MonoBehaviour {

	public CryoManager cryoManager;
	public bool drain;

	SpriteRenderer alert;
	
	float startingSize;
	float drainSpeed;
	float fillAmt;

	float amtToFill;
	float fillRate;

	int state;

	Transform _transform;

	// -1.25
	// Use this for initialization
	void Start () {
		_transform = transform.FindChild("Cryo_Goo");
		alert = transform.FindChild("Cryo_AlertEffect").GetComponent<SpriteRenderer>();

		startingSize = 1.25f;
		fillAmt = startingSize * 2f;
		fillRate = fillAmt * 2f;

		drainSpeed = Random.Range(startingSize / 15, startingSize / 6);

		Vector3 position = _transform.localPosition;
		position.y -= Random.Range(0,drainSpeed);
		_transform.localPosition = position;

		alert.enabled = false;

		drain = false;
		state = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (!drain)
			return;
		Vector3 position = _transform.localPosition;
		position.y -= drainSpeed * Time.deltaTime;
		position.y += Mathf.Min (amtToFill, fillRate) * Time.deltaTime;
		position.y = Mathf.Clamp(position.y, -startingSize, 0);

		amtToFill = Mathf.Clamp(amtToFill-(fillRate* Time.deltaTime),0,amtToFill);
		if (position.y <= -startingSize) {
			cryoManager.ContainerDrained(this);
		}
		_transform.localPosition = position;

		if (state != 2 && position.y > -startingSize * 0.25f) {
			alert.enabled = false;
			state = 2;
		}
		else if (state != 1 && position.y < -startingSize * 0.5f) {
			alert.enabled = true;
			state = 1;
		}

	}

	public void Fill() {
		amtToFill += fillAmt;
	}
}
