using UnityEngine;
using System.Collections;

public class Saveable : MonoBehaviour {

	private bool referenced = false;

	// Use this for initialization
	void Start () {
		if (!Game.isNewGame)
			Destroy(gameObject);

		if (!referenced) {
			//GameController.
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
