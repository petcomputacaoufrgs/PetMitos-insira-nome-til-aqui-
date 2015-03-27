using UnityEngine;
using System.Collections;
using System;

[System.Serializable]
public class SavedData {

	public static SavedData current;

	// Struct for the data of the saved games
	private struct gameData {
		public int id;
		public string levelName;
		public DateTime time;
	};

	private int currentId;	// The ID for the current saved game
	private ArrayList savedGames;	// The list of saved games

	public SavedData() {
		currentId = -1;
		savedGames = new ArrayList ();
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
}