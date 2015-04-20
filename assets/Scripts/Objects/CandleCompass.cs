using UnityEngine;
using System.Collections;

public class CandleCompass : MonoBehaviour {

	private Transform player;
	private GameObject targetEye;
	private Vector3 playerPosition;

	private float distance = float.MaxValue;


	// Use this for initialization
	void Start () {
	
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		playerPosition = player.position;
	}

	//
	void OnTriggerEnter2D(Collider2D other){

		if(gameObject.GetComponent<Renderer>().enabled)
			return;

		Debug.Log("Jogador: " + playerPosition);

		GameObject[] eyesObj = GameObject.FindGameObjectsWithTag("TargetEye");

		Debug.Log("Olhos: " + eyesObj.Length);

		//Vector3 playerPosition = player.gameObject.tr
		float playerX = playerPosition.x;
		float playerY = playerPosition.y;

		foreach(GameObject eyeObj in eyesObj){
			
			

			
			float eyeX = eyeObj.transform.position.x;
			float eyeY = eyeObj.transform.position.y;
			
			float thisDistance = Mathf.Sqrt(Mathf.Pow(eyeX - playerX, 2) + Mathf.Pow(eyeY - playerY, 2));

			//Debug.Log("Distancias: " + thisDistance);
			if(thisDistance < distance){
				distance = thisDistance;
				targetEye = eyeObj;
			}
		}

		//Debug.Log("Menor distancia: " + distance);

		float targetX = targetEye.transform.position.x;
		float targetY = targetEye.transform.position.y;

		float angle = (playerY - targetY)/(playerX - targetX);
		angle = Mathf.Atan(angle) * 180/Mathf.PI;

		Debug.Log("Angulo: " + angle);
		Debug.Log("Olho: " + targetEye.name);

		gameObject.GetComponent<Renderer>().enabled = true;
		gameObject.transform.Rotate(0, 0, angle, Space.World);
	}
}
