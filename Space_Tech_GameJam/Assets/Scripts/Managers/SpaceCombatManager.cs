using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class SpaceCombatManager : GameManager {

	public SpaceCombatGame microGame;
	public Image keyImage;
	private Text keyText;
	public Image spaceImage;

	int defendCount;
	float pauseTimer;
	int attacks;
	List<KeyCode> keys;
	List<KeyCode> lastKeys;
	KeyCode nextKey;
	int correctKeyPressed;

	// Use this for initialization
	protected override void Start () {
		base.Start();
		microGame = (SpaceCombatGame)baseGame;

		microGame.mechanic.winCondition.metDelegate += new ConditionMet(ConditionMet);
		microGame.mechanic.loseCondition.metDelegate += new ConditionMet(ConditionMet);
		microGame.mode = CombatMode.Defend;
		timer = 2;
		defendCount = 0;

		if (this.keyImage)
			keyText = (Text)keyImage.transform.GetChild(0).GetComponent<Text>();
		this.spaceImage.gameObject.SetActive(false);
		this.keyImage.gameObject.SetActive(false);

		this.keys = microGame.mechanic.GetInput.GetKeys;
		this.lastKeys = new List<KeyCode>();
	}
	
	// Update is called once per frame
	protected override void Update () {
		base.Update();
	}
	
	#region Overrides
	protected override void Intro ()
	{
		base.Intro ();
		timer -= Time.deltaTime;
		if (timer <= 0) {
			Debug.Log ("Start Play");
			gameState = GameState.Play;
			SelectKey();
		}
	}

	protected override void Play ()
	{
		base.Play ();

		if (pauseTimer > 0) {
			return;
		}

		timer -= Time.deltaTime;
		if (timer <= 0) {

			if (microGame.mode == CombatMode.Attack) {
				baseGame.mechanic.winCondition.AddAmt(attacks);
			}
			else if (microGame.mode == CombatMode.Defend) {
				if (correctKeyPressed == 1) {
					
				}
				else {
					baseGame.mechanic.loseCondition.AddAmt(1f);
				}
			}
		}
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

		if (microGame.mode == CombatMode.Attack) {
			if (key == KeyCode.Space) {
				attacks++;
			}
		}
		else if (microGame.mode == CombatMode.Defend && correctKeyPressed == 0) {
			if (key == nextKey) {
				Debug.Log ("Hit correct key!");
				correctKeyPressed = 1;
			}
			else {
				Debug.Log ("Hit wrong key");
				correctKeyPressed = -1;
			}
		}
	}

	protected override void UpdateDisplay ()
	{
		base.UpdateDisplay ();

		if (microGame.mode == CombatMode.Attack) {
			this.spaceImage.gameObject.SetActive(true);
			this.keyImage.gameObject.SetActive(false);
		}
		else {
			this.spaceImage.gameObject.SetActive(false);
			this.keyImage.gameObject.SetActive(true);
			this.keyText.text = nextKey.ToString();
		}
	}
	
	protected override void ConditionMet (Condition condition)
	{
		if (microGame.mechanic.isWinCondition(condition)) {
			Debug.Log ("Win Condition Met");
		}
		else if (microGame.mechanic.isLoseCondition(condition)) {
			Debug.Log ("Lose Condition Met");
		}
		else {
			throw new UnityException("Error with game condition: Condition met is neither the win or the lose condition");
		}
	}

	#endregion

	#region Class Specific
	void SwitchModes() {
		Debug.Log ("Switching Modes");
		if (microGame.mode == CombatMode.Attack) {
			microGame.mode = CombatMode.Defend;
			timer = microGame.defenceDelay;
			pauseTimer = 0.5f;
		}
		else {
			microGame.mode = CombatMode.Attack;
			timer = microGame.attackTime;
			attacks = 0;
		}
	}

	void SelectKey() {
		nextKey = keys[Random.Range(0,keys.Count)];
		lastKeys.Add(nextKey);

		correctKeyPressed = 0;
		timer = microGame.defenceDelay;
		UpdateDisplay();
	}
	#endregion
}
