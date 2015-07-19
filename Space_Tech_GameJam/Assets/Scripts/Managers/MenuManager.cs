using UnityEngine;
using System.Collections;

public class MenuManager : MonoBehaviour {

	public GameObject aboutText;
	// Use this for initialization
	void Start () {
		aboutText.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetKeyDown(KeyCode.S)) {
			GlobalGameManager.StartGame();
		}
		else if (Input.GetKeyDown(KeyCode.A)) {
			aboutText.SetActive(true);
			aboutText.GetComponent<Animator>().SetTrigger("Press A");
		}
	}


}
