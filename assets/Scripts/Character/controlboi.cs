using UnityEngine;
using System.Collections;

public class controlboi:MonoBehaviour {

	public bool montado= false;
	public bool jump = false;
	[SerializeField] float maxSpeed = 20f;
	[SerializeField] float jumpForce = 500f;			// Amount of force added when the player jumps.	

	public Transform Groundcheck;
	public float 	 GroundcheckRadius= 0.2f;
	public LayerMask whatisground;
	private bool grounded;



	public bool faceright = false;		
	public float speed; 
	public bool mounttrigger = false;

	void Start () {

	
	}

	void FixedUpdate (){

		grounded = Physics2D.OverlapCircle(Groundcheck.position, GroundcheckRadius, whatisground);

		if(montado)
		{
			if(Input.GetKey(KeyCode.UpArrow)){
				if(Input.GetKeyDown(KeyCode.UpArrow)){
					montado = false;
					transform.parent.GetComponent<PlatformerCharacter2D>().montaria = false;
					GetComponent<HingeJoint2D>().enabled = false;
					GetComponent<PolygonCollider2D>().enabled =false;
					transform.parent = GameObject.Find("MOBs").transform;
					StartCoroutine(MyCoroutine());
				}
			}


			if (Input.GetButtonDown("Jump")) jump = true;
			speed = Input.GetAxis("Horizontal");
			Move(speed,false,jump);
			jump = false;
			
		}

	}
	
	// Update is called once per frame
	void Update () {






	
	}


	
	public void Move(float move, bool crouch, bool jump)
	{
		

		rigidbody2D.velocity = new Vector2 (move * maxSpeed, rigidbody2D.velocity.y);
			if (mounttrigger ) {
				// Move the character
				
			
				// If the input is moving the player right and the player is facing left...
				if (move > 0 && !faceright)
					// ... flip the player.
					Flip ();
				// Otherwise if the input is moving the player left and the player is facing right...
				else if (move < 0 && faceright)
					// ... flip the player.
					Flip ();
				mounttrigger = false;
		}
		
		// If the player should jump...
		if (jump && grounded) {
			// Add a vertical force to the player.

			rigidbody2D.AddForce(new Vector2(0f, jumpForce));
			
		}

	}

	void Flip ()
	{
		// Switch the way the player is labelled as facing.
		faceright = !faceright;
		transform.parent.GetComponent<PlatformerCharacter2D> ().facingRight = faceright;
		
		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	IEnumerator MyCoroutine()
	{
		Physics2D.IgnoreLayerCollision (10, 11, true);
		yield return new WaitForSeconds(1F);
		Physics2D.IgnoreLayerCollision (10, 11, false);
	}





}
