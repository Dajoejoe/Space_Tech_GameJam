using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public GameObject objectToSpawn;
	public int count;

	void Awake() {
		CircleCollider2D colider = GetComponent<CircleCollider2D>();
		Bounds bounds = colider.bounds;
		Debug.Log (bounds.min.x + " " + bounds.max.x);
		for (int i=0; i < count; i++) {
			GameObject newObject = (GameObject)GameObject.Instantiate(objectToSpawn);
			float x = Random.Range(bounds.min.x, bounds.max.x);
			float y = Random.Range(bounds.min.y, bounds.max.y);
			newObject.transform.localPosition = new Vector3(x,y,0);
			newObject.transform.localRotation = Quaternion.Euler(new Vector3(0,0,Random.Range(0,360)));
		}
		Destroy (gameObject);
	}

}
