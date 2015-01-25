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

	public AudioSource musicSource;
	public AudioSource sfxSource;
	// Use this for initialization
	void Start () {
	
		instance = this;

		if(Application.loadedLevel == 0){
			// loaded level is 0 which is game, start with game music
			musicSource.clip = gameMusic;
			musicSource.Play();
		}

		if(Application.loadedLevel == 1){
			// loaded level is 0 which is title, start with title music
			musicSource.clip = titleMusic;
			musicSource.Play();
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void PlayFootStep(){
		Debug.Log ("Play random foot step sound here!");
		//sfxSource.clip = this.stepFx[Random.Range (0, this.stepFx.Length)];
		sfxSource.PlayOneShot(this.stepFx[Random.Range (0, this.stepFx.Length)]);
		//for(int i=0; i < this.stepFx.Length
	}

	public void PlayJump(){
		sfxSource.PlayOneShot(jumpFx);
	}

	public void PlayJumpTry(int dino){
		sfxSource.PlayOneShot(jumpVox[dino]);
	}
}
