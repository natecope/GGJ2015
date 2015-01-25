using UnityEngine;
using System.Collections;

public class ShrewBehavior : MonoBehaviour {

	public bool isDangerous = true;
	public Animator sprite;
	public Collider2D shrewCollider;
	// Use this for initialization
	void Start () {
		sprite = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D other) {
		if(other.gameObject.tag == "Feet" && isDangerous) {
			isDangerous = false;
			Debug.Log("SO DEAD");
			transform.localScale = new Vector2(transform.localScale.x, -0.2f);
			sprite.speed=0;
		}
	}

	void OnCollisionEnter2D (Collision2D other) {
		if(!isDangerous) {
			if(other.gameObject.tag != "Ground") {
				Physics2D.IgnoreCollision(this.collider2D, other.collider);
				//Destroy(gameObject);
			}
		}
	}
}
