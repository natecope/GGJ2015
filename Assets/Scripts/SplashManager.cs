using UnityEngine;
using System.Collections;

public class SplashManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if((Input.GetKey (KeyCode.W) || (Input.GetKey (KeyCode.Joystick1Button0))) && (Input.GetKey (KeyCode.UpArrow) || Input.GetKey (KeyCode.Joystick2Button0))){

			Application.LoadLevel(0);

		}
	}
}
