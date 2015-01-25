using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SplashScreen : MonoBehaviour {

	public GameObject blackBkg;
	public GameObject actualCredits;

	private bool _areCreditsShowing;

	private Image actualCreditsImg;

	private Animator _blackBkgAnimator;

	// Use this for initialization
	void Start () {
		Image blackBkgImg = blackBkg.GetComponent<Image>();
		actualCreditsImg = actualCredits.GetComponent<Image>();

		blackBkgImg.color = new Vector4(blackBkgImg.color.r,blackBkgImg.color.g,blackBkgImg.color.b,0.0f);
		actualCreditsImg.color = new Vector4(actualCreditsImg.color.r,actualCreditsImg.color.g,actualCreditsImg.color.b,0.0f);

		_blackBkgAnimator = blackBkg.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ToggleCredits() {
		//Debug.Log("Toggle Creeeedits");
		if (_areCreditsShowing) { HideCredits();}
		else { ShowCredits();}
		_areCreditsShowing = !_areCreditsShowing;
	}

	private void ShowCredits() {
		//Debug.Log("Shoooow");
		_blackBkgAnimator.SetBool("shouldHideCredits",false);
		_blackBkgAnimator.SetBool("shouldShowCredits",true);
		actualCreditsImg.color = actualCreditsImg.color = new Vector4(actualCreditsImg.color.r,actualCreditsImg.color.g,actualCreditsImg.color.b,1.0f);
	}

	private void HideCredits() {
		//Debug.Log("Hide");
		_blackBkgAnimator.SetBool("shouldShowCredits",false);
		_blackBkgAnimator.SetBool("shouldHideCredits",true);
		actualCreditsImg.color = actualCreditsImg.color = new Vector4(actualCreditsImg.color.r,actualCreditsImg.color.g,actualCreditsImg.color.b,0.0f);
	}
}
