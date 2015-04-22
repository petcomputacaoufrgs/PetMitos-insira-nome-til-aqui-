using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class SavedData {

	public static SavedData current;

	// Struct for the data of the saved games
	[System.Serializable]
	public struct gameData {
		public int id;
		public string levelName;
		public DateTime time;
	};

	private int currentId;	// The ID for the current saved game
	private List<gameData> savedGames;	// The list of saved games

	public SavedData() {
		currentId = -1;
		savedGames = new List<gameData> ();
	}

	/**
	 * Return an id for the new game to be saved
	*/
	public int NewData () {
		return ++currentId;
	}

	/**
	 * Update the time of the saved game and it's level name.
	*/
	public void UpdateData () {
		gameData currentData;
		int id;
		id = Game.current.GetId ();

		currentData.id = id;
		currentData.levelName = Game.current.GetLevelName ();
		currentData.time = DateTime.Now;

		savedGames.Insert (id, currentData);
	}

	public List<gameData> GetData () {
		return new List<gameData> (savedGames);
	}
}