using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;

public static class SaveLoad {

	/**
	 * Saves the game
	*/
	public static void Save () {
		if (SavedData.current == null)
			SaveLoad.LoadSavedData ();

		// First update the SavedData to the current time and date
		SavedData.current.UpdateData ();
		BinaryFormatter bf = new BinaryFormatter();
		FileStream dataFile = File.Create (Application.persistentDataPath + "/savedGames.fd"); // FD stands for Folclorica Data
		bf.Serialize (dataFile, SavedData.current);
		dataFile.Close ();

		// Then save the current game
		Debug.Log ("Saving " + Game.current.GetId () + ".fd");
		FileStream gameFile = File.Create (Application.persistentDataPath + "/" + Game.current.GetId () + ".fd");
		bf.Serialize (gameFile, Game.current);
		gameFile.Close ();
	}

	public static void Load (int id) {
		if (File.Exists (Application.persistentDataPath + "/" + id + ".fd")) {
			Debug.Log ("Loading " + id + ".fd");
			BinaryFormatter bf = new BinaryFormatter();
			FileStream gameFile = File.Open (Application.persistentDataPath + "/" + id + ".fd", FileMode.Open);
			Game.current = (Game)bf.Deserialize (gameFile);
			gameFile.Close();
		}
	}


	public static void LoadSavedData () {
		if (File.Exists (Application.persistentDataPath + "/savedGames.fd")) {
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open (Application.persistentDataPath + "/savedGames.fd", FileMode.Open);
			SavedData.current = (SavedData)bf.Deserialize (file);
			file.Close ();
		} else {
			SavedData.current = new SavedData();
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Create (Application.persistentDataPath + "/savedGames.fd"); // FD is for Folclorica Data
			bf.Serialize (file, SavedData.current);
			file.Close();
		}
	}

	/**
	 * DEBUG ONLY: WON'T BE IN THE FINAL VERSION
	 */
	public static void CleanSavedData () {
		LoadSavedData ();
		List<SavedData.gameData> data = SavedData.current.GetData ();
		foreach (SavedData.gameData game in data) {
			File.Delete (Application.persistentDataPath + "/" + game.id + ".fd");
			Debug.Log ("File removed: " + Application.persistentDataPath + "/" + game.id + ".fd");
		}
		File.Delete (Application.persistentDataPath + "/savedGames.fd");
		Debug.Log ("File removed: " + Application.persistentDataPath + "/savedGames.fd");
	}

}
