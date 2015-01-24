using UnityEngine;
using System.Collections;

public class CameraLock : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void LateUpdate() 
	{  
		transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y, 0.0f, transform.rotation.w);  // 90 degress on the X axis - change appropriately
	}
}
