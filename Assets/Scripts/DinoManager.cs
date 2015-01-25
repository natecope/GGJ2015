﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DinoManager : MonoBehaviour {

	public Animator head1;
	public Animator head2;
	public Animator body;
	public Transform bodyTransform;
	public float movementSpeed;
	public float ripTimeSeconds;
	public float pullTimeStart;
	public bool pullTimeStarted;

	public bool fullSpeed;

	public bool movingRight;
	public bool movingLeft;
	public bool jumping;
	public bool doubleJumping;
	public bool movingRightFast;
	public bool movingLeftFast;
	public bool dead;




	// getting this to tell it if we're on ground or not
	public DinoBodyAudio dinoBodyAudio;

	// cache for directional changes. will come from body
	private Vector3 dinoScale;

	// Use this for initialization
	void Start () {
		head1.SetBool("movingLeft", false);
		head2.SetBool("movingLeft", false);
		head1.SetBool ("movingRight", false);
		head2.SetBool ("movingRight", false);
		body.SetBool ("dinoBodyMovingLeft", false);
		body.SetBool ("dinoBodyMovingRight", false);

		//cache dino scale in case it gets changed while 
		dinoScale = body.transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {

		if(!dead){

			if(Input.GetKey(KeyCode.A)){
				head1.SetBool("movingLeft", true);
			} else {
				head1.SetBool("movingLeft", false);
			}
		

			if(Input.GetKey(KeyCode.D)){
				head1.SetBool ("movingRight", true);
			} else {
				head1.SetBool ("movingRight", false);
			}

			if(Input.GetKey (KeyCode.W)){
				head1.SetBool ("jumping", true);
			} else {
				head1.SetBool ("jumping", false);
			}
			if(Input.GetKeyDown (KeyCode.W)){
				AudioManager.instance.PlayJumpTry(0);
			}
			// reversed input here due to flipped sprite!!
			if(Input.GetKey(KeyCode.RightArrow)){
				head2.SetBool ("movingLeft", true);
			} else {
				head2.SetBool ("movingLeft", false);
			}

			if(Input.GetKey(KeyCode.LeftArrow)){
				head2.SetBool ("movingRight", true);
			} else {
				head2.SetBool ("movingRight", false);
			}

			if(Input.GetKey (KeyCode.UpArrow)){
				head2.SetBool ("jumping", true);
			} else {
				head2.SetBool ("jumping", false);
			}
			if(Input.GetKeyDown (KeyCode.UpArrow)){
				AudioManager.instance.PlayJumpTry(1);
			}

			if(Input.GetKey (KeyCode.UpArrow) && Input.GetKey (KeyCode.W)){
				body.SetBool("dinoBodyJumping", true);
				if(jumping == false) AudioManager.instance.PlayJump();
				jumping = true;
			} else {
				body.SetBool("dinoBodyJumping", false);
				jumping = false;
			}

			if(Input.GetKey(KeyCode.A) && Input.GetKey (KeyCode.LeftArrow)){	//|| rigidbody2D.velocity.x < 0.0f){
				Debug.Log("both lefts pressed");
				body.SetBool ("dinoBodyMovingLeft", true);
				Vector3 newDinoScale = new Vector3(dinoScale.x, dinoScale.y, dinoScale.z);
				body.transform.localScale = newDinoScale;
				movingLeft =true; 
			} else {
				if(rigidbody2D.velocity.x < 0.0f && !movingLeft)
					body.SetBool ("dinoBodyMovingLeft", true);
				else
					body.SetBool ("dinoBodyMovingLeft", false);
				movingLeft = false;
			}
		
			if(Input.GetKey(KeyCode.D) && Input.GetKey (KeyCode.RightArrow)){
				Debug.Log("both rights pressed");
				body.SetBool ("dinoBodyMovingRight", true);
				Vector3 newDinoScale = new Vector3(-dinoScale.x, dinoScale.y, dinoScale.z);
				body.transform.localScale = newDinoScale;
				movingRight = true;
				
			} else {
				if(rigidbody2D.velocity.x > 0.0f && !movingLeft)
					body.SetBool ("dinoBodyMovingRight", true);
				else
					body.SetBool ("dinoBodyMovingRight", false);
				movingRight = false;

			}


			
			// check for opposing pull
			// reversed due to head of dino reversal
			if((head1.GetBool("movingLeft") && head2.GetBool ("movingLeft")) || (head1.GetBool("movingRight") && head2.GetBool ("movingRight"))){
				StartPullTime(); 
			} /*else {
				StopPullTime();
			}*/
		} else { // dead 



		}
	
	}

	void StartPullTime(){
		/*if(!pullTimeStarted){
			pullTimeStarted = true;
			pullTimeStart = Time.time;
		}*/
		ripTimeSeconds -= Time.deltaTime;
	}

	void StopPullTime(){
		if(pullTimeStarted){
			pullTimeStarted = false;
			ripTimeSeconds -= (Time.time - pullTimeStart);
			pullTimeStart = 0;
		}

	}

	public void DinoDead(){
		if(!dead){
			Debug.Log ("Dino dead fired");
			dead = true;
			body.SetBool("dinoDead", true);
			head1.SetBool("dead", true);
			head2.SetBool("dead", true);
			bodyTransform.position = new Vector3(bodyTransform.position.x, bodyTransform.position.y - 0.6f, bodyTransform.position.z);
			this.transform.rigidbody2D.isKinematic = true;
		}

	}
}
