using UnityEngine;
using System.Collections;

public class HealthBarManager : MonoBehaviour {

	public GameObject hero;
	private PlayerManager _playerManager;

	// Use this for initialization
	void Start () {
		_playerManager = hero.GetComponent<PlayerManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
