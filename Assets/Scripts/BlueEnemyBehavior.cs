﻿using UnityEngine;
using System.Collections;

public class BlueEnemyBehavior : MonoBehaviour {

	public bool startLeft = true;
	public float moveSpeed = 100;
	public bool isFlying;
	private int moveLeft;
	private Vector3 cachedScale;
	public ShrewBehavior shrewBehavior;
	void Awake () {
		if(startLeft)
			moveLeft = -1;
		else
			moveLeft = 1;

	}
	// Use this for initialization
	void Start () {
		shrewBehavior = GetComponent<ShrewBehavior>();
	}

	void OnBecameVisible () {
		rigidbody2D.velocity = new Vector2(moveLeft*moveSpeed,rigidbody2D.velocity.y);
	}

	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D other) {
		if(other.gameObject.tag=="MotionControlBlock"){
			//cache scale in case it gets changed while 
			cachedScale = transform.localScale;
			moveLeft = -moveLeft;
			Vector3 newScale = new Vector3(-moveLeft, cachedScale.y, cachedScale.z);
			transform.localScale = newScale;
		}
		else if(other.gameObject.tag == "Player"){
			Debug.Log("OUCH!");

		}                                          	
	}
	void FixedUpdate () {
		//Debug.Log(transform.localRotation.z);	
		if(shrewBehavior.isDangerous && isFlying && (rigidbody2D.velocity.y==0)){
			rigidbody2D.velocity = new Vector2(moveLeft*moveSpeed,rigidbody2D.velocity.y);
			rigidbody2D.AddForce(new Vector2(0,130.0f));
		}
		else
			rigidbody2D.velocity = new Vector2(moveLeft*moveSpeed,rigidbody2D.velocity.y);

	}
}
