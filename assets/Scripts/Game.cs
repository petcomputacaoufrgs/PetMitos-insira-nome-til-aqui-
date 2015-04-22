using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Game {
	
	public static Game current = null;

	private int id;
	private int lifes;
	private int points;
	private string levelName;

	private Dictionary<string, Hashtable> saveables;

	public Game (int gameId, string firstLevelName, int lifes) {
		this.id = gameId;
		this.lifes = lifes;
		this.points = 0;
		this.levelName = firstLevelName;

		this.saveables = new Dictionary<string, Hashtable>();
	}

	/**
	 * Creates a new game object and it's file
	 */
	public static void NewGame (string firstLevelName, int lifeAmount) {
		SaveLoad.LoadSavedData ();
		Game.current = new Game (SavedData.current.NewData (), firstLevelName, lifeAmount);
		SaveLoad.Save ();
	}

	public int GetId () {
		return id;
	}

	public string GetLevelName () {
		return levelName;
	}

	public void LoadScene () {
		Application.LoadLevel (this.levelName);
	}

	/**
	 * Returns the list of saved components of the given object
	 */
	public Hashtable GetSavedValues (string savename) {
		if (saveables.ContainsKey (savename)) {
			return this.saveables[savename];
		} else {
			return new Hashtable(6, 0.8F);
		}
	}

	public void SetSavedValues (string savename, Hashtable values) {
		saveables[savename] = values;
	}

	/**
	 * Return true if the object was saved, otherwise false
	 */
	public bool ObjectSaved (string savename) {
		if (this.saveables.ContainsKey (savename))
			return true;
		else
			return false;
	}
}
