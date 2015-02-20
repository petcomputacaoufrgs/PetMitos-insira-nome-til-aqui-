using UnityEngine;
using System.Collections;

public class BoitataSpinningBody : MonoBehaviour {

	public GameObject player;

	public float speed = 10f;

	Vector3 angle = new Vector3(0, 0, 1);
	bool isOnGround = false;


	//values for internal use
	private Quaternion _lookRotation;
	private Vector3 _direction;

	void FixedUpdate(){
		transform.Rotate(angle, speed * Time.deltaTime);
	}

	/*void OnTriggerEnter2D(Collider2D other){
		
		if(!isOnGround){
			isOnGround = true;

			Debug.Log("Sobre o corpo...");
		}
	
	}

	void OnTriggerExit2D(Collider2D other){
		
		if(isOnGround){
			isOnGround = false;

			Debug.Log("Fora do corpo...");
		}
		
	}*/

	//void OnTriggerStay2D(Collider2D other){

		//DistanceJoint2D joint = gameObject.GetComponent<DistanceJoint2D>();

		//if(joint == null){

			////find the vector pointing from our position to the target
			//_direction = (player.transform.position - transform.position).normalized;
			////_direction.z = 0;
			
			//create the rotation we need to be in to look at the target
			//_lookRotation = Quaternion.LookRotation(_direction);

			//_lookRotation.z = 0;
			
			////rotate us over time according to speed until we are in the required rotation
			//player.transform.rotation = Quaternion.Slerp(player.transform.rotation, _lookRotation, Time.deltaTime * speed);

			//joint = gameObject.AddComponent<DistanceJoint2D>();
			//joint.collideConnected = true;
			////joint.maxDistanceOnly = true;
			//joint.connectedBody = player.rigidbody2D;

			//float radious = gameObject.GetComponent<CircleCollider2D>().radius;

			//Debug.Log(radious);

			//joint.distance = radious * 2;

		//}
		
	//}

	// Use this for initialization
	/*void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	
		//float speed = player.rigidbody2D.s
		//transform.Rotate(0, 0, transform.rigidbody2D.velocity.x * speed);
		//nops, mas pode ser interessante para outra coisa
		transform.Rotate(angle, speed * Time.deltaTime);
		//player.transform.pos

		//transform.collider2D.a
		//transform.collider2D.rigidbody2D.ro
	}

	void OnTriggerEnter2D(Collider2D other){

		if(playerPosition == Vector3.zero){

			//playerPosition = player.transform.position;
			//player.rigidbody2D.AddForce(new Vector2(speed * Time.deltaTime, speed * Time.deltaTime));
			Debug.Log("Dentro..." + playerPosition);
			//player.rigidbody2D.velocity = transform.rigidbody2D.velocity;
			//transform.collider2D.GetComponent<WheelJoint2D>().connectedBody = player.rigidbody2D;
			DistanceJoint2D radiousDistance = transform.collider2D.GetComponent<DistanceJoint2D>();
			radiousDistance.connectedBody = player.rigidbody2D;
			radiousDistance.distance = transform.collider2D.GetComponent<CircleCollider2D>().radius;

				//GetComponent<Hi>().connectedBody = player.rigidbody2D;
		}
	}

	void OnTriggerStay2D(Collider2D other){

		if(playerPosition != Vector3.zero){

			player.transform.position = transform.position;
			/*
	// update direction each frame:
   var dir: Vector3 = target - transform.position;
   // calculate desired rotation:
   var rot: Quaternion = Quaternion.LookRotation(dir);
   // Slerp to it over time:
   transform.rotation = Quaternion.Slerp(transform.rotation, rot, turnSpeed * Time.deltaTime);
   // move in the current forward direction at specified speed:
   transform.Translate(Vector3(0, 0, speed * Time.deltaTime));
			
			 */
	/*	}
	}
	/*void OnTriggerStay2D(Collider2D other){

		if(playerPosition != Vector3.zero){
			Debug.Log(speed * Time.deltaTime);
			rigidbody2D.velocity = new Vector2(speed * Time.deltaTime, speed * Time.deltaTime);
			Debug.Log(player.rigidbody2D.velocity);
		}

		//rigidbody2D.velocity = new Vector2(move * maxSpeed, rigidbody2D.velocity.y);
		// Move the character
		//player.rigidbody2D.velocity = new Vector2(speed * Time.deltaTime, 
		  //                                        player.rigidbody2D.velocity.y);

			//+= speed * Time.deltaTime; //new Vector2(move * maxSpeed, rigidbody2D.velocity.y);
		//calcular
	}*/

	/*void OnTriggerExit2D(Collider2D other){
		
		if(playerPosition != Vector3.zero){
			
			playerPosition = Vector3.zero;
			Debug.Log("Fora..." + playerPosition);
			rigidbody2D.velocity = Vector2.zero;
			//player.rigidbody2D.velocity = transform.rigidbody2D.velocity;
		}
	}*/

}
