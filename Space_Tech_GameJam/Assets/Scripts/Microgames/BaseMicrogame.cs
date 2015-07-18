using UnityEngine;
using System.Collections;

public abstract class BaseMicrogame  {

	public float time;
	public string gameName;
	public  BaseMechanic mechanic;
	public int result;

	protected MicrogameObject gameObject;
	protected int difficultyLevel;

	public BaseMicrogame(int difficulty) {
		SetupDifficulty(difficulty);
	}

	public virtual void ConfigureGameObject(MicrogameObject sceneObject, GameManager gameManager){ 
		this.gameObject = sceneObject;
		this.mechanic.GetInput.ProcessDelegate += new ProcessKey(gameManager.ProcessInput);
	}

	protected abstract void SetupDifficulty(int difficulty);
}
