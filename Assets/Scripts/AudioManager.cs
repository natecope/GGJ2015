using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {
	public AudioClip gameMusic;
	public AudioClip titleMusic;
	public AudioClip deathMusic;
	public AudioClip jumpFx;
	public AudioClip[] deathVox;
	public AudioClip[] jumpVox;
	public AudioClip[] stepFx;
	public AudioClip[] tearFX;
	public AudioClip[] victoryVox;
	public AudioClip[] tearVox;

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
