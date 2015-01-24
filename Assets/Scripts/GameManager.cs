using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

	public GameObject dinoPrefab;
	public List<GameObject> playerRefs;
	public int numberPlayers = 2;
	
	private GameObject dino;
	public static PlayerManager playerObject;

	// Use this for initialization
	void Start () {
	
		this.playerRefs = new List<GameObject>();
//		dino = (GameObject)Instantiate (dinoPrefab);


	}
	
	// Update is called once per frame
	void Update () {
	
		foreach (GameObject player in this.playerRefs) {
			PlayerManager manager = player.GetComponent<PlayerManager>();


			// do stuff with each player here
		}

	}

	void SpawnPlayer() {
		
		Debug.Log("Spawning " + numberPlayers + " players!");
		
		for (int i = 0; i < numberPlayers; ++i) {
			GameObject player = (GameObject)Instantiate(dinoPrefab);
			playerRefs.Add(player);
			player.GetComponent<InputController>().axisName = "Player" + (i+1) + "_";

		}

	}
}
