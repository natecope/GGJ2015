using UnityEngine;
using System.Collections;

public class MapGenerator : MonoBehaviour {

	public bool generateMap = true;

	public GameObject boxType1;
	public GameObject boxType2;
	public GameObject boxType3;
	public GameObject player;
	public float groundWidth, groundHeight;
	public float groundWidth2,groundWidth3;
	
	public bool drawBox = true;
	public bool drawLine = false;

	// Use this for initialization
	void Start () {
		if(!generateMap)
			return;
		float i,j;

		if (drawBox) {
			for (i=0.0f; i<groundWidth; i++) {
				for (j=0.0f; j<groundHeight; j++) {
					Instantiate (boxType1, new Vector3 (i, 0.0f - j), new Quaternion (0.0f, 0.0f, 0.0f, 0.0f));
				}
			}
		} else if (drawLine) {
			for (i=0.0f; i<groundWidth; i++) {
				Instantiate (boxType1, new Vector3 (i, 0.0f), new Quaternion (0.0f, 0.0f, 0.0f, 0.0f));
			}
			for (; i<groundWidth+groundWidth2; i++) {
				Instantiate (boxType2, new Vector3 (i, 0.0f), new Quaternion (0.0f, 0.0f, 0.0f, 0.0f));
			}
			for (; i<groundWidth+groundWidth2+groundWidth3; i++) {
				Instantiate (boxType3, new Vector3 (i, 0.0f), new Quaternion (0.0f, 0.0f, 0.0f, 0.0f));
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
