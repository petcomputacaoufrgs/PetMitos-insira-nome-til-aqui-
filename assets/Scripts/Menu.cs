using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Menu : MonoBehaviour {

	public void NewGame () {
		Game.NewGame ("Save Example", 3);
		Game.current.LoadScene ();
	}

	public void ContinueGame () {
		SaveLoad.LoadSavedData ();
		List<SavedData.gameData> data = SavedData.current.GetData ();
		int id = -1;
		string levelName = "";
		foreach (SavedData.gameData game in data) {
			id = game.id;
			levelName = game.levelName;
		}
		if (id != -1) {
			Debug.Log ("Loading level " + levelName);
			SaveLoad.Load (id);
		}
		Game.current.LoadScene ();
	}

	public void CleanGames () {
		SaveLoad.CleanSavedData ();
	}
}
