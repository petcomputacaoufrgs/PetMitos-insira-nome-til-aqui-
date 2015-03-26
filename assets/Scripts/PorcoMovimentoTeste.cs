using UnityEngine;
using System.Collections;

public class PorcoMovimentoTeste : MonoBehaviour {

	public float range;
	public float timeToSleep;

	private float startingPosition;
	private bool directionLeft;
	private float timer;

	// Use this for initialization
	void Start () {
		startingPosition = gameObject.transform.position.x;
		directionLeft = true;
		timer = timeToSleep;
	}
	
	// Update is called once per frame
	void Update () {
		if (timer > 0) {
			gameObject.transform.Translate((directionLeft ? Vector3.left : Vector3.right) * Time.deltaTime*3);
			if (gameObject.transform.position.x < startingPosition - range && directionLeft)
				directionLeft = false;
			
			if (gameObject.transform.position.x > startingPosition + range && !directionLeft)
				directionLeft = true;
			
			timer -= 0.1F;
		}
	}
}
