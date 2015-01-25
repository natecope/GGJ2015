using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public int sceneNumber;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void progressToNext(int SN) {
		// TODO Here put the congratulations etc for winning th level
		// TODO fade out of level, perhaps remove control
		Debug.Log("#WINNING");
		Application.LoadLevel(SN);
	}

	void OnTriggerEnter2D (Collider2D other) {
		if(other.gameObject.tag == "Player") {
			progressToNext(sceneNumber);
		}
	}
}
