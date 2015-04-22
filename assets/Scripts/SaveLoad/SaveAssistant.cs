using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SaveAssistant {

	private string savename;

	public SaveAssistant (GameObject objectToSave, string label) {
		savename = GetSavename (objectToSave, label);
	}

	/**
	 * Return an unique savename based on label and position
	 */
	static string GetSavename (GameObject objectToSave, string label) {
		return label + "." + Application.loadedLevelName
					 + "." + objectToSave.transform.position.x
					 + "." + objectToSave.transform.position.y
					 + "." + objectToSave.transform.position.z;
	}
	

	public T LoadValue<T> (string label, T defaultValue) {
		// If the object hasn't been saved, then return the default value
		if (Game.current.ObjectSaved(savename) == false)
			return defaultValue;

		Hashtable values = Game.current.GetSavedValues (savename);
		if (values.Contains (label) == false)
			return defaultValue;

		return (T)values[label];
	}

	public void SetToSave<T> (string label, T value) {
		Hashtable values = Game.current.GetSavedValues (savename);
		values[label] = value;
		Game.current.SetSavedValues (savename, values);
	}

	public void LoadPosition (GameObject target) {
		if (Game.current.ObjectSaved(savename) == false)
			return;

		float x, y, z;
		Hashtable values = Game.current.GetSavedValues (savename);
		if (values.Contains ("transform.position.x")) {
			x = (float)values["transform.position.x"];
		} else {
			x = target.transform.position.x;
		}
		if (values.Contains ("transform.position.y")) {
			y = (float)values["transform.position.y"];
		} else {
			y = target.transform.position.y;
		}
		if (values.Contains ("transform.position.z")) {
			z = (float)values["transform.position.z"];
		} else {
			z = target.transform.position.z;
		}
		target.transform.position = new Vector3(x,y,z);
	}

	public void SetToSavePosition (GameObject target) {
		Hashtable values = Game.current.GetSavedValues (savename);
		values["transform.position.x"] = target.transform.position.x;
		values["transform.position.y"] = target.transform.position.y;
		values["transform.position.z"] = target.transform.position.z;
		Game.current.SetSavedValues (savename, values);
	}
}
