using UnityEngine;
using System.Collections;

public class CryoContainer : MonoBehaviour {

	public CryoManager cryoManager;
	public bool drain;

	float startingSize;
	float drainSpeed;
	float fillAmt;

	float amtToFill;
	float fillRate;

	int state;

	Transform _transform;
	// Use this for initialization
	void Start () {
		_transform = transform;
		startingSize = _transform.localScale.y;
		fillAmt = startingSize * 0.5f;
		fillRate = fillAmt * 0.5f;

		drainSpeed = Random.Range(startingSize / 15, startingSize / 6);

		Vector3 scale = _transform.localScale;
		scale.y -= Random.Range(0,drainSpeed);
		_transform.localScale = scale;

		drain = false;
		state = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (!drain)
			return;

		Vector3 scale = _transform.localScale;
		scale.y -= drainSpeed * Time.deltaTime;
		scale.y += Mathf.Min (amtToFill, fillRate) * Time.deltaTime;
		amtToFill = Mathf.Clamp(amtToFill-fillRate,0,amtToFill);
		if (scale.y <= 0) {
			cryoManager.ContainerDrained(this);
		}
		_transform.localScale = scale;

		if (state != 2 && scale.y < startingSize * 0.25f) {
			this.gameObject.GetComponent<SpriteRenderer>().color = new Color(.25f,.25f,.25f);
			state = 2;
		}
		else if (state != 1 && scale.y < startingSize * 0.5f) {
			this.gameObject.GetComponent<SpriteRenderer>().color = new Color(.5f,.5f,.5f);
			state = 1;
		}
		else if (state != 0 && scale.y > startingSize * 0.5f) {
			this.gameObject.GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f);
			state = 0;
		}
	}

	public void Fill() {
		amtToFill += fillAmt;
		if (_transform.localScale.y + amtToFill > startingSize) {
			cryoManager.ContainerDrained(this);
		}
	}
}
