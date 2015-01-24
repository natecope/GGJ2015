using UnityEngine;
using System.Collections;

public class BlueEnemyBehavior : MonoBehaviour {

	public bool startLeft = true;
	public float moveSpeed = 100;
	private int moveLeft;

	void Awake () {
		if(startLeft)
			moveLeft = -1;
		else
			moveLeft = 1;

	}
	// Use this for initialization
	void Start () {
	
	}

	void OnBecameVisible () {
		rigidbody2D.velocity = new Vector2(moveLeft*moveSpeed,rigidbody2D.velocity.y);
	}

	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D other) {
		if(other.gameObject.tag=="MotionControlBlock")
			moveLeft = -moveLeft;
		else if(other.gameObject.tag == "Player")
			Debug.Log("OUCH!");

	}

	void FixedUpdate () {
		rigidbody2D.velocity = new Vector2(moveLeft*moveSpeed,rigidbody2D.velocity.y);
	}
}
