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
		FileStream file = File.Create (Application.persistentDataPath + "/savedGames.fd"); // FD stands for Folclorica Data
		bf.Serialize (file, SavedData.current);
		file.Close ();

		// Then save the current game
		file = File.Create (Application.persistentDataPath + "/" + Game.current.GetId () + ".fd");
		bf.Serialize (file, Game.current);
	}

	public static void Load (int id) {
		if (File.Exists (Application.persistentDataPath + "/" + id + ".fd")) {
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open (Application.persistentDataPath + "/savedGames.fd", FileMode.Open);
			Game.current = (Game)bf.Deserialize(file);
			file.Close();
			Game.current.LoadScene ();
		}
	}

	public static void LoadSavedData () {
		if (File.Exists (Application.persistentDataPath + "/savedGames.fd")) {
			BinaryFormatter bf = new BinaryFormatter ();
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

	public static void CleanSavedData () {
		File.Delete (Application.persistentDataPath + "/savedGames.fd");
	}

}
