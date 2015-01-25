using UnityEngine;
using System.Collections;

public class CameraJumpController : MonoBehaviour {

	public GameObject camera;
	public GameObject hero;

	public PlayerManager playerManager;

	private Animator _camAnimator;
	
	// Use this for initialization
	void Start () {
		_camAnimator = camera.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {


		if (Mathf.Abs (hero.transform.rigidbody2D.velocity.y) > 0.1f) {
			_camAnimator.SetBool("shouldGoD",false);
			_camAnimator.SetBool("shouldGoU",true);
			//Debug.Log("Jumping Up");
		} else if (hero.transform.rigidbody2D.velocity.y == 0 && playerManager.onGround) {
			_camAnimator.SetBool("shouldGoU",false);
			_camAnimator.SetBool("shouldGoD",true);
			//Debug.Log ("Landed");
		}
	}
}
