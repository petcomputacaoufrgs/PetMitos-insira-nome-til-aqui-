using UnityEngine;
using System.Collections;

public class Saver : MonoBehaviour {

	public GameObject player;

	private SaveAssistant playerSaver;

	void Awake () {
		playerSaver = new SaveAssistant (player, "player");
		playerSaver.LoadPosition (player);
		if (Game.current == null)
			Game.NewGame (Application.loadedLevelName, 3);
	}

	public void Save () {
		Debug.Log ("Saving");
		playerSaver.SetToSavePosition (player);
		SaveLoad.Save ();
	}
}
