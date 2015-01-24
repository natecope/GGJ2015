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

public class PlayerManager : MonoBehaviour {

	public static int speed;
	public static int hitPoints;
	public static PlayerAction currentState;
	public static float MovementSpeed = 1.1f;
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
		getInput();
	}

	void getInput()
	{
		if (Input.GetKeyDown (KeyCode.D)) {
			newPos.x = 1 * MovementSpeed * Time.deltaTime;		
		}
		transform.localPosition = newPos;
	}
}
