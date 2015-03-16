using UnityEngine;

public class PlatformerCharacter2D : MonoBehaviour 
{
	public bool facingRight = true;							// For determining which way the player is currently facing.

	[SerializeField] float maxSpeed = 10f;				// The fastest the player can travel in the x axis.
	[SerializeField] float jumpForce = 400f;			// Amount of force added when the player jumps.	

	[Range(0, 1)]
	[SerializeField] float crouchSpeed = .36f;			// Amount of maxSpeed applied to crouching movement. 1 = 100%
	
	[SerializeField] bool airControl = false;			// Whether or not a player can steer while jumping;
	[SerializeField] LayerMask whatIsGround;			// A mask determining what is ground to the character
	[SerializeField] LayerMask whatIsRope;			// A mask determining what is ground to the character
	
	Transform groundCheck;								// A position marking where to check if the player is grounded.
	float groundedRadius = .2f;							// Radius of the overlap circle to determine if grounded
	bool grounded = false;								// Whether or not the player is grounded.
	bool onRope = false;			
	public bool montaria = false;// Whether or not the player is grounded.



	Transform ceilingCheck;								// A position marking where to check for ceilings
	float ceilingRadius = .01f;							// Radius of the overlap circle to determine if the player can stand up
	Animator anim;										// Reference to the player's animator component.


    void Awake()
	{
		// Setting up references.
		groundCheck = transform.Find("GroundCheck");
		ceilingCheck = transform.Find("CeilingCheck");
		anim = GetComponent<Animator>();

	}


	void FixedUpdate()
	{

		onRope = Physics2D.OverlapCircle(groundCheck.position, groundedRadius, whatIsRope) ||
			Physics2D.OverlapCircle(ceilingCheck.position, ceilingRadius, whatIsRope);
		if(onRope){
			System.Console.WriteLine("Bateu na corda");
		}
		// The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundedRadius, whatIsGround);
		anim.SetBool("Ground", grounded);

		anim.SetBool ("montado", montaria);

		// Set the vertical animation
		anim.SetFloat("vSpeed", rigidbody2D.velocity.y);
	}


	public void Move(float move, bool crouch, bool jump)
	{


		// If crouching, check to see if the character can stand up
		if(!crouch && anim.GetBool("Crouch"))
		{
			// If the character has a ceiling preventing them from standing up, keep them crouching
			if( Physics2D.OverlapCircle(ceilingCheck.position, ceilingRadius, whatIsGround))
				crouch = true;
		}

		// Set whether or not the character is crouching in the animator
		anim.SetBool("Crouch", crouch);

		//only control the player if grounded or airControl is turned on
		if(grounded || airControl)
		{
			// Reduce the speed if crouching by the crouchSpeed multiplier
			move = (crouch ? move * crouchSpeed : move);

			// The Speed animator parameter is set to the absolute value of the horizontal input.
			anim.SetFloat("Speed", Mathf.Abs(move));

			// Move the character
			rigidbody2D.velocity = new Vector2(move * maxSpeed, rigidbody2D.velocity.y);
			
			// If the input is moving the player right and the player is facing left...
			callFlip(move);
		}

        // If the player should jump...
        if (grounded && jump) {
            // Add a vertical force to the player.
            anim.SetBool("Ground", false);
            rigidbody2D.AddForce(new Vector2(0f, jumpForce));

        }
		if(montaria == true){
			if (Input.GetKey(KeyCode.UpArrow))		//desmontar apertando up & jump
			{
				if (Input.GetKeyDown(KeyCode.Space))
				{
					montaria = false;


				}
			}
		}
	}

	public void callFlip(float move){
		if(move > 0 && !facingRight)
			// ... flip the player.
			Flip();
		// Otherwise if the input is moving the player left and the player is facing right...
		else if(move < 0 && facingRight)
			// ... flip the player.
			Flip();
	}

	
	public void Flip ()
	{
		// Switch the way the player is labelled as facing.
		facingRight = !facingRight;
		
		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	void OnCollisionEnter2D(Collision2D collision){
	    if (collision.gameObject.tag=="mount") {

			if(facingRight != collision.gameObject.GetComponent<controlboi>().faceright){
				Flip();
			}



			collision.gameObject.GetComponent<HingeJoint2D>().enabled = true;

			collision.gameObject.transform.SetParent(gameObject.transform, true);

			collision.gameObject.GetComponent<controlboi>().montado = true;





			montaria = true;


		





		}

		
	}
	void	OnCollisionStay2D(Collision2D coll) {
		if(coll.gameObject.tag == "BOX"){
			if (Input.GetKey (KeyCode.LeftControl)) {
				coll.gameObject.rigidbody2D.mass = 8;
			} 
				else {
				coll.gameObject.rigidbody2D.mass = 1000;
			}
		}

	}

}

