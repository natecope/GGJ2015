using UnityEngine;
using System.Collections;
//player states handling the different animations
public enum PlayerActions{
	Standing,
	Walking,
	Running,
	Confused,
	EffectiveJump,
	Jump,
	CounterJump,
	Duck
}

public class _JPlayerManager : MonoBehaviour {

	public static int hitPoints;
	public static PlayerActions currentState;
	public bool canFly = false;
	public float flightSpeed = 0.25f;
	public float MovementSpeed = 0.8f;
	public float jumpForce = 10.0f;
	Vector3 oldPos;
	Vector3 newPos;
	// Use this for initialization
	void Start () {
		hitPoints = 3;
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnCollisionEnter2D (Collision2D other) {
		if (other.gameObject.tag == "Deathbox")
						Debug.Log ("DOOM!");
		// this insures that the player isn't stopped by the NPC control blocks
		if (other.gameObject.tag == "MotionControlBlock")
			Physics2D.IgnoreCollision(this.collider2D, other.collider);
		}

	void FixedUpdate() {

		// Code for sideways motion
		float movementHorizontal = Input.GetAxis ("Horizontal");
		float adjustedSpeed = MovementSpeed;
		if (rigidbody2D.velocity.y != 0.0f)
			if (canFly)
				adjustedSpeed *= flightSpeed;
			else 
				adjustedSpeed = 0.0f;
		rigidbody2D.AddForce (new Vector2 (movementHorizontal * adjustedSpeed, 0));
		// end sideways motion ~~

		// Code for vertical motion
		if (Input.GetKeyDown (KeyCode.Space)) {
						rigidbody2D.AddForce (new Vector2 (0, jumpForce));
				}


	}
	void getInput()
	{

	}
}
