using UnityEngine;
using System.Collections;

public class Motion : MonoBehaviour {

	public float speed = 10;
	public bool canFly = false;
	public float flightSpeed = 0.25f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

	void FixedUpdate() {
		float movementHorizontal = Input.GetAxis ("Horizontal");
		float adjustedSpeed = speed;
		if (rigidbody2D.velocity.y != 0)
				if (canFly)
						adjustedSpeed *= flightSpeed;
				else 
						adjustedSpeed = 0.0f;
		rigidbody2D.AddForce (new Vector3 (movementHorizontal * adjustedSpeed, 0));
	}
}
