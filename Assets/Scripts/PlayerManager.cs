using UnityEngine;
using System.Collections;
//player states handling the different animations
public enum PlayerAction{
	Standing,
	Walking,
	Running,
	Confused,
	EffectiveJump,
	Jump,
	CounterJump,
	Duck,
	Dead
}

public class PlayerManager : MonoBehaviour {
	
	public int hitPoints;
	public PlayerAction currentState;
	public bool canFly = false;
	public bool onGround;
	public float flightSpeed = 0.25f;
	public float MovementSpeed = 16000.0f;

	public bool isLookingRight;
	public DinoManager dinoMan;
	public float jumpForce;
	public float maxVelo;
	//debugging vars 
	public float yVelo;
	public float xVelo;
	public float inputH;
	public float inputV;

	// Use this for initialization
	void Start () {
		hitPoints = 3;
		isLookingRight=true;
		dinoMan = gameObject.GetComponent<DinoManager>();

	}

	void OnCollisionEnter2D (Collision2D other) {
		if (other.gameObject.tag == "Deathbox")
			hitPoints--;
		if(other.gameObject.tag == "Enemy")
		{

			hitPoints--;
			Debug.Log("ouch!@!@");
		}	
		// this insures that the player isn't stopped by the NPC control blocks
		if (other.gameObject.tag == "MotionControlBlock")
			Physics2D.IgnoreCollision(this.collider2D, other.collider);
			

		//Debug.Log (other.gameObject.tag);
	}

	void OnCollisionStay2D (Collision2D other){
		// checks for ground, changes dino body audio ground off 
		if (other.gameObject.tag == "Ground"){
			onGround = true;
		}
	}


	void OnCollisionExit2D (Collision2D other){
		if(other.gameObject.tag == "Ground"){
			onGround = false;
		}
	}

	// Update is called once per frame
	void Update () {
		if(hitPoints <=0){
			//Application.LoadLevel(0);
			//gameObject.SetActive(false);
			currentState = PlayerAction.Dead;
			//this.gameObject.SetActive(false);
			dinoMan.DinoDead();
		}
	}

	//Physics updating
	void FixedUpdate() {
		float movementHorizontal = 0.0f;
		float movementVertical = Input.GetAxis ("Vertical");
		float adjustedSpeed = MovementSpeed;

		if(dinoMan.movingLeft)  
			movementHorizontal = -1.0f;
		if(dinoMan.movingRight)
				movementHorizontal =1.0f;

		if(Mathf.Abs(rigidbody2D.velocity.x) <= 0.1) rigidbody2D.velocity = new Vector2(0, rigidbody2D.velocity.y);

		if(!dinoMan.movingLeft && !dinoMan.movingRight)
			movementHorizontal = 0.0f;
		//begin debug code
		yVelo = rigidbody2D.velocity.y; 
		xVelo = rigidbody2D.velocity.x; 
		inputH = movementHorizontal;
		inputV = movementVertical;
		//end debug code
		if (movementHorizontal < 0 || movementHorizontal > 0 ) {
			currentState = PlayerAction.Walking;		
		} else {
			if(rigidbody2D.velocity.y != 0.0f )
				currentState = PlayerAction.Jump;
			else{
				currentState = PlayerAction.Standing;
				if(rigidbody2D.velocity.x > 0.0f)
					rigidbody2D.AddForce (new Vector2(-0.8f  * adjustedSpeed * Time.deltaTime, 0));
				else if(rigidbody2D.velocity.x < 0.0f)
					rigidbody2D.AddForce (new Vector2(0.8f  * adjustedSpeed * Time.deltaTime, 0));

			}
		}
		//if(rigidbody2D.velocity.y == 0.0f){
			if (rigidbody2D.velocity.y != 0.0f)
				if (canFly)
					adjustedSpeed *= flightSpeed;
			else 
				adjustedSpeed = 0.0f;
			if(Mathf.Abs(rigidbody2D.velocity.x) < maxVelo)
			{
				if (dinoMan.movingRight) {
					isLookingRight = true;
					rigidbody2D.AddForce (new Vector2 (1 * (adjustedSpeed/2) * Time.deltaTime, 0));
				}else if(dinoMan.movingLeft ){
					isLookingRight = false;
					rigidbody2D.AddForce (new Vector2 (-1 * (adjustedSpeed / 2) * Time.deltaTime, 0));
				}

				if (dinoMan.movingRight) {
					isLookingRight = true;
					rigidbody2D.AddForce (new Vector2 (1 * adjustedSpeed * Time.deltaTime, 0));
				}else if(dinoMan.movingLeft ){
					isLookingRight = false;
					rigidbody2D.AddForce (new Vector2 (-1 * adjustedSpeed * Time.deltaTime, 0));
				}

			}else if(Mathf.Abs(rigidbody2D.velocity.x) > maxVelo)
			{
				if(isLookingRight)
					rigidbody2D.velocity = new Vector2(1 * maxVelo,0);
				else
					rigidbody2D.velocity = new Vector2(-1 * maxVelo,0);
				
			}
	//	}
		
		
		//jumping
		if(dinoMan.jumping)
		{
			if(currentState != PlayerAction.Jump && rigidbody2D.velocity.y ==0.0f){
		currentState = PlayerAction.Jump;
				rigidbody2D.AddForce(new Vector2(0, jumpForce));
			}
		}else if(movementVertical <0){
			currentState = PlayerAction.Duck;
		}
	}
	void getInput()
	{
		
	}
}