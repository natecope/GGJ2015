using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

	public GameObject dinoPrefab;
	public List<GameObject> playerRefs;
	public int numberPlayers = 2;
	public Camera camRef;
	public DinoManager dino;
	public PlayerManager playerManager;
	
	public Text ripTimeText;
	public Text healthText;

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

		// print out timer
		ripTimeText.text = "RIP TIME - " + dino.ripTimeSeconds.ToString("#0");
		healthText.text = "HEALTH - " + playerManager.hitPoints.ToString("#0");

	}
	/*
	void SpawnPlayer() {
		
		Debug.Log("Spawning " + numberPlayers + " players!");
		
		for (int i = 0; i < numberPlayers; ++i) {
			GameObject player = (GameObject)Instantiate(dinoPrefab);
			playerRefs.Add(player);
			player.GetComponent<InputController>().axisName = "Player" + (i+1) + "_";

		}

	}*/
}
