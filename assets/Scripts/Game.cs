using UnityEngine;
using System.Collections;

[System.Serializable]
public class Game {
	
	public static Game current;

	private int id;
	private int lifes;
	private int points;
	private string levelName;
	private bool levelBegin;

	private ArrayList saveables;

	public Game (int gameId, int lifes) {
		this.id = gameId;
		this.lifes = lifes;
		this.points = 0;
		this.levelName = Application.loadedLevelName;
		this.levelBegin = true;

		this.saveables = new ArrayList();
	}

	public bool LevelBegin () {
		return levelBegin;
	}

	public void AddSaveable (GameObject saveable) {
		saveables.Add (saveable);
	}

	public int GetId () {
		return id;
	}

	public string GetLevelName () {
		return levelName;
	}

	public void LoadScene () {
		Application.LoadLevel (this.levelName);
		foreach (GameObject loadingObject in saveables) {
			loadingObject.SetActive (true);
		}
	}

}
