using UnityEngine;
using System.Collections;

public class DinoBodyAudio : MonoBehaviour {

	public PlayerManager playerManager;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void PlayFootStep(){
		if(playerManager.onGround) AudioManager.instance.PlayFootStep();
	}
}
