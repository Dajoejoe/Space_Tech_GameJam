using UnityEngine;
using System.Collections;
using System;

public class MicrogameObject : MonoBehaviour {

	public string gameType;

	public BaseMicrogame microGame;
	public GameManager gameManager;

	float timer;

	// Use this for initialization
	void Awake () {
		this.microGame = (BaseMicrogame)Activator.CreateInstance(GlobalGameManager.nextGame,GlobalGameManager.globalDifficulty);
		if (this.gameManager == null)
			this.gameManager = gameObject.GetComponent<GameManager>();
		this.gameManager.baseGame = this.microGame;
		this.microGame.ConfigureGameObject(this, gameManager);
		this.gameType = this.microGame.gameName;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
