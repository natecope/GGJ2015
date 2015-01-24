using UnityEngine;
using System.Collections;

public class Motion : MonoBehaviour {

	public float speed;
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
		if (rigidbody2D.velocity.y != 0.0f)
				if (canFly)
						adjustedSpeed *= flightSpeed;
				else 
						adjustedSpeed = 0.0f;
		rigidbody2D.AddForce (new Vector3 (movementHorizontal * speed, 0));
	}
}
