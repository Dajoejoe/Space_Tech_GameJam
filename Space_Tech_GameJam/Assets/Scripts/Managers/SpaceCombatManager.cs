using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class SpaceCombatManager : GameManager {

	public SpaceCombatGame microGame;
	public Image keyImage;
	private Image countImage;
	public Image spaceImage;
	public GameObject goo;
	public GameObject enemyGoo;
	public GameObject shield;
	public GameObject healthBar;

	int health;
	int defendCount;
	float pauseTimer;
	int attacks;
	KeyCode currentKey;
	int correctKeyPressed;

	List<Sprite> iconCache;
	List<Sprite> numberCache;

	// Use this for initialization
	protected override void Start () {
		base.Start();
		microGame = (SpaceCombatGame)baseGame;
		microGame.mechanic.winCondition.metDelegate += new ConditionMet(ConditionMet);
		microGame.mechanic.loseCondition.metDelegate += new ConditionMet(ConditionMet);
		microGame.mode = CombatMode.Defend;
		timer = 2;
		defendCount = 0;
		health = 15;

		this.spaceImage.gameObject.SetActive(false);
		this.keyImage.gameObject.SetActive(false);

		this.countImage = this.spaceImage.transform.GetChild(0).GetComponent<Image>();
		this.keys = microGame.mechanic.GetInput.GetKeys;
		this.lastKeys = new List<KeyCode>();
		this.iconCache = new List<Sprite>();
		this.numberCache = new List<Sprite>();

		string path = "";
		foreach (KeyCode key in this.keys) {
			path = "Sprites/UI/Icon_"+key.ToString();
			Sprite newSprite = Resources.Load<Sprite>(path);
			this.iconCache.Add(newSprite);
		}

		path = "Sprites/UI/Text_NumbersSheet";
		Sprite[] newSprites = Resources.LoadAll<Sprite>(path);
		foreach (Sprite s in newSprites) {
			this.numberCache.Add(s);
		}
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
			pauseTimer -= Time.deltaTime;
			if (pauseTimer <= 0)
			{			
				UpdateDisplay();
			}
			return;
		}

		timer -= Time.deltaTime;
		if (timer <= 0) {

			if (microGame.mode == CombatMode.Attack) {
				baseGame.mechanic.winCondition.AddAmt(attacks);
				SwitchModes();
			}
			else if (microGame.mode == CombatMode.Defend) {
				GameObject goo = (GameObject)GameObject.Instantiate(enemyGoo);
				if (correctKeyPressed == 1) {
					goo.GetComponent<Animator>().SetTrigger("Fire");
					shield.GetComponent<Animator>().SetTrigger("Trigger");
					defendCount ++;
					if (defendCount == microGame.defensePresses) {
						SwitchModes();
					}
					else {
						SelectKey();
					}
				}
				else {
					goo.GetComponent<Animator>().SetTrigger("Hit");
					baseGame.mechanic.loseCondition.AddAmt(1f);
				}
			}
		}
	}

	protected override void Win ()
	{
		base.Win ();
		timer -= Time.deltaTime;
		if (timer <= 0) {
			Application.LoadLevel("Scene_Main");
		}
	}

	protected override void Lose ()
	{
		base.Lose ();
		timer -= Time.deltaTime;
		if (timer <= 0) {
			Application.LoadLevel("Scene_Main");
		}
	}

	public override void ProcessInput (KeyCode key)
	{
		base.ProcessInput (key);

		if (gameState != GameState.Play || pauseTimer > 0) {
			return;
		}

		if (microGame.mode == CombatMode.Attack) {
			if (key == KeyCode.Space) {
				attacks++;
				health--;
				GameObject.Instantiate(goo);
				healthBar.transform.FindChild(health.ToString()).gameObject.SetActive(false);;
				UpdateDisplay();
				if (attacks == 10) {
					baseGame.mechanic.winCondition.AddAmt(attacks);
					SwitchModes();
				}
			}
		}
		else if (microGame.mode == CombatMode.Defend && correctKeyPressed == 0) {
			if (key == currentKey) {
				Debug.Log ("Hit correct key!");
				correctKeyPressed = 1;
			}
			else {
				Debug.Log ("Hit wrong key");
				correctKeyPressed = -1;
			}
			this.keyImage.gameObject.SetActive(false);
		}
	}

	protected override void UpdateDisplay ()
	{
		base.UpdateDisplay ();

		if (microGame.mode == CombatMode.Attack) {
			this.spaceImage.gameObject.SetActive(true);
			this.keyImage.gameObject.SetActive(false);
			this.countImage.sprite = numberCache[attacks];
		}
		else {
			this.spaceImage.gameObject.SetActive(false);
			this.keyImage.gameObject.SetActive(true);
		}
	}
	
	protected override void ConditionMet (Condition condition)
	{
		if (microGame.mechanic.isWinCondition(condition)) {
			Debug.Log ("Win Condition Met");
			gameState = GameState.Win;
			timer = 2;
		}
		else if (microGame.mechanic.isLoseCondition(condition)) {
			Debug.Log ("Lose Condition Met");
			gameState = GameState.Lose;
			GlobalGameManager.health += baseGame.result;
			timer = 2;
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
			defendCount = 0;
			lastKeys = new List<KeyCode>();
			SelectKey();
			this.keyImage.gameObject.SetActive(false);
		}
		else {
			microGame.mode = CombatMode.Attack;
			timer = microGame.attackTime;
			attacks = 0;
		}
		pauseTimer = 0.5f;

	}

	void SelectKey() {
		int index = Random.Range(0,keys.Count-1);
		currentKey = keys[index];
		lastKeys.Add(currentKey);

		this.keyImage.sprite = this.iconCache[index];

		correctKeyPressed = 0;
		timer = microGame.defenceDelay;
		UpdateDisplay();
	}
	#endregion
}
