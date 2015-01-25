using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {
	public AudioClip music;

	public static AudioManager instance;

	private AudioSource[] audioSource;
	// Use this for initialization
	void Start () {
	
		instance = this;
		audioSource = GetComponents<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
