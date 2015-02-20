using UnityEngine;
using System.Collections;

public class DeadTreeTrigger : MonoBehaviour {

	public GameObject detachPiece;

	bool isAttached = true;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		//this.rigidbody2D.isKinematic = false;

		//.Console.WriteLine("Funciona");

		//Debug.Log("Funciona");
	}

	/*void OnTriggerEnter(Collider other) {
		//this.rigidbody2D.isKinematic = false;

		//detachPiece.AddComponent<Rigidbody2D>();


		//System.Console.WriteLine("Ativou");
	}*/

	void OnTriggerEnter2D(Collider2D other){
		//Debug.Log("Funciona");

		//this.GetComponentInParent(GameObject).add

		if(isAttached){
			isAttached = false;
			//Rigidbody2D rigid = new Rigidbody2D();
			//rigid.fixedAngle = true;

			Rigidbody2D rigid = detachPiece.AddComponent<Rigidbody2D>();
			rigid.fixedAngle = true;

			Debug.Log("Ativou");
		}

	}




}
