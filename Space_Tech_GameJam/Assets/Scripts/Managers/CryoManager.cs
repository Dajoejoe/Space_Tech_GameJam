using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CryoManager : GameManager {

	public CryoGame microGame;
	public GameObject containerParent;

	List<CryoContainer> containers;

	protected override void Start () {
		base.Start();
		microGame = (CryoGame)baseGame;
		microGame.mechanic.winCondition.metDelegate += new ConditionMet(ConditionMet);
		microGame.mechanic.loseCondition.metDelegate += new ConditionMet(ConditionMet);
		timer = 2;

		this.keys = microGame.mechanic.GetInput.GetKeys;
		this.lastKeys = new List<KeyCode>();

		containers = new List<CryoContainer>();
		foreach  (Transform child in containerParent.GetComponentsInChildren<Transform>()) {
			if (child.GetComponent<CryoContainer>())
			{
				CryoContainer cont = child.GetComponent<CryoContainer>();
				containers.Add(cont);
				cont.cryoManager = this;
			}
		}
		Debug.Log (containers.Count);
		
//		string path = "";
//		foreach (KeyCode key in this.keys) {
//			path = "Sprites/UI/Icon_"+key.ToString();
//			Sprite newSprite = Resources.Load<Sprite>(path);
//			this.iconCache.Add(newSprite);
//		}
//		
//		path = "Sprites/UI/Text_NumbersSheet";
//		Sprite[] newSprites = Resources.LoadAll<Sprite>(path);
//		foreach (Sprite s in newSprites) {
//			this.numberCache.Add(s);
//			Debug.Log (s.name);
//		}
	}
	
	#region Overrides
	protected override void Intro ()
	{
		base.Intro ();
		timer -= Time.deltaTime;
		if (timer <= 0) {
			Debug.Log ("Start Play");
			timer = 5;
			gameState = GameState.Play;

			ChangeContainers(true);
		}
	}
	
	protected override void Play ()
	{
		base.Play ();

		microGame.mechanic.winCondition.AddAmt(Time.deltaTime);
		timer -= Time.deltaTime;
	}
	
	protected override void Win ()
	{
		base.Win ();
	}
	
	protected override void Lose ()
	{
		base.Lose ();
	}
	
	public override void ProcessInput (KeyCode key)
	{
		base.ProcessInput (key);
		
		if (gameState != GameState.Play) {
			return;
		}

		GetContainerForKey(key.ToString()).Fill();
	}
	
	protected override void UpdateDisplay ()
	{
		base.UpdateDisplay ();

	}
	
	protected override void ConditionMet (Condition condition)
	{
		if (microGame.mechanic.isWinCondition(condition)) {
			Debug.Log ("Win Condition Met");
			gameState = GameState.Win;
		}
		else if (microGame.mechanic.isLoseCondition(condition)) {
			Debug.Log ("Lose Condition Met");
			gameState = GameState.Lose;
			GlobalGameManager.health += baseGame.result;
		}
		else {
			throw new UnityException("Error with game condition: Condition met is neither the win or the lose condition");
		}

		ChangeContainers(false);
	}
	
	#endregion
	#region Class Specific

	CryoContainer GetContainerForKey(string key) {
		return containerParent.transform.FindChild(key).GetComponentInChildren<CryoContainer>();;
	}

	public void ContainerDrained(CryoContainer container) {
		microGame.mechanic.loseCondition.AddAmt(1);
		container.GetComponent<SpriteRenderer>().color = Color.black;
		ChangeContainers(false);
	}

	void ChangeContainers(bool drain) {
		foreach(CryoContainer cryo in containers) {
			cryo.drain = drain;
		}
	}

	#endregion
}
