using UnityEngine;
using System.Collections;

[System.Serializable]
public class Game {

	public static Game current;

	private static GameObject[] objectsToSave;
	private static bool isNewGame = true;

	public static void addObjectToSave(GameObject objectToSave) {

	}

	public static bool isNewGame() {
		return isNewGame;
	}

}
