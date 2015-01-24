using UnityEngine;
using System.Collections;

public class MapGenerator : MonoBehaviour {

	public GameObject blackCube;
	public GameObject player;
	public float groundWidth, groundHeight;
	
	public bool drawBox = true;
	public bool drawLine = false;

	// Use this for initialization
	void Start () {
		float i,j;

		if (drawBox) {
						for (i=0.0f; i<groundWidth; i++) {
								for (j=0.0f; j<groundHeight; j++) {
										Instantiate (blackCube, new Vector3 (i, 0.0f - j), new Quaternion (0.0f, 0.0f, 0.0f, 0.0f));
								}
						}
				} else if (drawLine) {

				}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
