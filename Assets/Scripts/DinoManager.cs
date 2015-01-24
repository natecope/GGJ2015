using UnityEngine;
using System.Collections;

public class DinoManager : MonoBehaviour {

	public Animator head1;
	public Animator head2;
	public Animator body;
	public float movementSpeed;
	public bool fullSpeed;
	public bool jumping;

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

		if(Input.GetKey(KeyCode.A) && Input.GetKey (KeyCode.LeftArrow)){
			Debug.Log("both lefts pressed");
			body.SetBool ("dinoBodyMovingLeft", true);
			Vector3 newDinoScale = new Vector3(dinoScale.x, dinoScale.y, dinoScale.z);
			body.transform.localScale = newDinoScale;

		} else {
			body.SetBool ("dinoBodyMovingLeft", false);
		}
	
		if(Input.GetKey(KeyCode.D) && Input.GetKey (KeyCode.RightArrow)){
			Debug.Log("both rights pressed");
			body.SetBool ("dinoBodyMovingRight", true);
			Vector3 newDinoScale = new Vector3(-dinoScale.x, dinoScale.y, dinoScale.z);
			body.transform.localScale = newDinoScale;


		} else {
			body.SetBool ("dinoBodyMovingRight", false);
		}
	}
}
