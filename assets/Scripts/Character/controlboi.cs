using UnityEngine;
using System.Collections;

public class controlboi:MonoBehaviour {

	public bool montado= false;
	public bool jump = false;
	[SerializeField] float maxSpeed = 20f;
	[SerializeField] float jumpForce = 500f;			// Amount of force added when the player jumps.	

	public Transform Groundcheck;
	public float GroundcheckRadius;
	private bool grounded;


	public bool faceright = false;		
	public float speed; 
	public bool mounttrigger = false;

	void Start () {

	
	}
	
	// Update is called once per frame
	void Update () {


		if(montado)
		{
			if (Input.GetButtonDown("Jump")) jump = true;
			speed = Input.GetAxis("Horizontal");
			Move(speed,false,jump);
			jump = false;

		}



	
	}


	
	public void Move(float move, bool crouch, bool jump)
	{
		


			if (!montado || mounttrigger ) {
				// Move the character
				rigidbody2D.velocity = new Vector2 (move * maxSpeed, rigidbody2D.velocity.y);
			
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
		if (jump) {
			// Add a vertical force to the player.

			rigidbody2D.AddForce(new Vector2(0f, jumpForce));
			
		}

	}

	void Flip ()
	{
		// Switch the way the player is labelled as facing.
		faceright = !faceright;
		
		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}





}
