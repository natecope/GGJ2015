using UnityEngine;
using System.Collections;
//player states handling the different animations
public enum PlayerAction{
	Standing,
	Walking,
	Running,
	Confused,
	EffectiveJump,
	Jump,
	CounterJump,
	Duck
}

public class Player : MonoBehaviour {

	public static int speed;
	public static int hitPoints;
	public static PlayerAction currentState;
	public static float MovementSpeed = 100.0f;
	Vector3 oldPos;
	Vector3 newPos;
	// Use this for initialization
	void Start () {
		hitPoints = 3;
		oldPos = transform.localPosition;
		newPos = transform.localPosition;

	}
	
	// Update is called once per frame
	void Update () {
//		base.update();
//		getInput();
	}

	void getInput()
	{
//		if (Input.GetKeyDown (KeyCode.D)) {
//			transform.localPosition.x = 1 * MovementSpeed * Time.deltaTime();		
//		}
	}
}
