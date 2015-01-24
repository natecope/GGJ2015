using UnityEngine;
using System.Collections;

public class BounceAction : MonoBehaviour {
	public float bounceFactor = 100.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void onTrigger (Collision other) {
		if(other.gameObject.tag=="Player") {
			other.gameObject.rigidbody2D.AddForce(new Vector2(0.0f, bounceFactor));
			Debug.Log("BOUNCE!");
		}
	}
}
