﻿using UnityEngine;
using System.Collections;

public class BlueEnemyBehavior : MonoBehaviour {

	public bool startLeft = true;
	public float moveSpeed = 100;
	private int moveLeft;
	private Vector3 cachedScale;

	void Awake () {
		if(startLeft)
			moveLeft = -1;
		else
			moveLeft = 1;

	}
	// Use this for initialization
	void Start () {
		//cache scale in case it gets changed while 
		cachedScale = transform.localScale;
	}

	void OnBecameVisible () {
		rigidbody2D.velocity = new Vector2(moveLeft*moveSpeed,rigidbody2D.velocity.y);
	}

	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D other) {
		if(other.gameObject.tag=="MotionControlBlock"){
			moveLeft = -moveLeft;
			Vector3 newScale = new Vector3(-cachedScale.x, cachedScale.y, cachedScale.z);
			transform.localScale = newScale;
		}
		else if(other.gameObject.tag == "Player")
			Debug.Log("OUCH!");

	}

	void FixedUpdate () {
		rigidbody2D.velocity = new Vector2(moveLeft*moveSpeed,rigidbody2D.velocity.y);
	}
}