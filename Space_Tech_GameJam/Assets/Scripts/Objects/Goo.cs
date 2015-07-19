using UnityEngine;
using System.Collections;

public class Goo : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void DestroyGameObject() {
		Destroy (gameObject);
	}

	public void ChangeLayer (int layer) {
		GetComponent<SpriteRenderer>().sortingOrder = layer;
	}
}
