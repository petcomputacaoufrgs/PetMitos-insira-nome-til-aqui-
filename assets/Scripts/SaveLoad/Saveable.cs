using UnityEngine;
using System.Collections;

public class Saveable : MonoBehaviour {

	private bool referenced = false;

	void Start () {
		if (!referenced) {
			// If the level just began, add the saveable object to the list of saveable objects
			if (Game.current.LevelBegin ()) {
				Game.current.AddSaveable (gameObject);
				referenced = true;
			} else {	// Otherwise destroy the object to be replaced with the saved object
				Destroy(gameObject);
			}
		}
	}

}
