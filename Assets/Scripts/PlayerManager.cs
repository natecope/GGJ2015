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
	Duck
}

public class PlayerManager : MonoBehaviour {

	public static int hitPoints;
	public static PlayerAction currentState;
	public bool canFly = false;
	public float flightSpeed = 0.25f;
	public float MovementSpeed = 0.8f;
	Vector3 oldPos;
	Vector3 newPos;
	// Use this for initialization
	void Start () {
		hitPoints = 3;
	}
	
	// Update is called once per frame
	void Update () {
	}

	void FixedUpdate() {
		float movementHorizontal = Input.GetAxis ("Horizontal");
		float adjustedSpeed = MovementSpeed;
		if (rigidbody2D.velocity.y != 0.0f)
			if (canFly)
				adjustedSpeed *= flightSpeed;
		else 
			adjustedSpeed = 0.0f;
		rigidbody2D.AddForce (new Vector3 (movementHorizontal * adjustedSpeed, 0));

	}
	void getInput()
	{

	}
}
