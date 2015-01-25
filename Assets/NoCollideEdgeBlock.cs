using UnityEngine;
using System.Collections;

public class NoCollideEdgeBlock : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D (Collision2D other) {
		if (other.gameObject.tag == "MotionControlBlock")
			Physics2D.IgnoreCollision(collider2D, other.collider);
	}
}
