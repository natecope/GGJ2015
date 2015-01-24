using UnityEngine;
using System.Collections;

public class MapGenerator : MonoBehaviour {

	public GameObject blackCube;
	public GameObject player;
	public float groundWidth, groundHeight;

	// Use this for initialization
	void Start () {
		float i,j;

		for (i=0.0f; i<groundWidth; i++) {
			for (j=0.0f; j<groundHeight; j++) {
				Instantiate (blackCube, new Vector3 (i,0.0f-j), new Quaternion(0.0f,0.0f,0.0f,0.0f));
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
