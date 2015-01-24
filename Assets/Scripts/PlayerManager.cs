using UnityEngine;
using System.Collections;
//player states handling the different animations
public enum PlayerState{
	Standing,
	Walking,
	Running,
	Confused,
	EffectiveJump,
	Jump,
	CounterJump,
	Duck
}

public class PlayerManager : MonoBehaviour {

	public int hitPoints;
	public PlayerState currentState;
	public bool canFly = false;
	public bool isFacingRight=true;
	public float flightSpeed = 0.25f;
	public float MovementSpeed = 10000.0f;
	Vector3 oldPos;
	Vector3 newPos;
	private SpriteRenderer charSprite;
	// Use this for initialization
	void Start () {
		hitPoints = 3;
		charSprite = gameObject.GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!isFacingRight)
			charSprite.color = new Color (120, 210, 0, 255);
		else
			charSprite.color = new Color (246, 128, 56, 255);
	}

	void FixedUpdate() {
		float movementHorizontal = Input.GetAxis ("Horizontal");
		if (movementHorizontal > 0 || movementHorizontal < 0) {
						currentState = PlayerState.Walking;
				}

		float adjustedSpeed = MovementSpeed;
		if (rigidbody2D.velocity.y != 0.0f)
			if (canFly)
				adjustedSpeed *= flightSpeed;
		else 
			adjustedSpeed = 0.0f;
		if (movementHorizontal > 0){
			isFacingRight = true;
			rigidbody2D.AddForce (new Vector3 (1 * adjustedSpeed * Time.deltaTime, 0));
		} else if (movementHorizontal < 0) {
			isFacingRight =false;	
			rigidbody2D.AddForce (new Vector3 (-1 * adjustedSpeed * Time.deltaTime, 0));
				
		}
	}
	void getInput()
	{

	}
}
