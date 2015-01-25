using UnityEngine;
using System.Collections;

public class ShrewBehavior : MonoBehaviour {

	public bool isDangerous = true;
	public Animator sprite;
	public Collider2D shrewCollider;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D other) {
		if(other.gameObject.tag == "Feet") {
			isDangerous = false;
			sprite.SetBool("shrewDead",true);
			Debug.Log("SO DEAD");
			Destroy(shrewCollider);
		}
	}

	void OnCollisionEnter2D (Collision2D other) {
		if(!isDangerous) {
			if(other.gameObject.tag != "Ground") {
				Physics2D.IgnoreCollision(this.collider2D, other.collider);
			}
		}
	}
}
