using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public int lifes;

	void Awake () {
		if (Game.current == null) {
			if (SavedData.current == null)
				SaveLoad.LoadSavedData ();

			Game.current = new Game(SavedData.current.NewData (), lifes);
			SaveLoad.Save ();
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

}
