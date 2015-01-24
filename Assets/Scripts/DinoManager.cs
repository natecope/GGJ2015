using UnityEngine;
using System.Collections;

public class DinoManager : MonoBehaviour {

	public Animator head1;
	public Animator head2;
	public float movementSpeed;
	public bool fullSpeed;
	public bool jumping;


	// Use this for initialization
	void Start () {
		head1.SetBool("movingLeft", false);
		head2.SetBool("movingLeft", false);
		head1.SetBool ("movingRight", false);
		head2.SetBool ("movingRight", false);
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

	
	}
}
