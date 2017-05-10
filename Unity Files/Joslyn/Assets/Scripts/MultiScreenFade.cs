using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MultiScreenFade : MonoBehaviour {
	[SerializeField] bool checkAllChildren;
	[SerializeField] Image[] screensToFade;
	[SerializeField] Image[] buttonsToFade;
	[SerializeField] float transitionTime;
	[SerializeField] float holdTime = 6;

	private float delayTimer;
	private int screenNumber;
	private Image activeScreen;
	private int myCounter;
	private float delay;

	void OnEnable(){
		if(checkAllChildren){
			screensToFade = GetComponentsInChildren<Image>();
		}else{
			screensToFade = new Image[gameObject.transform.childCount];
			for(int i=0; i<gameObject.transform.childCount; i++){
				screensToFade[i] = gameObject.transform.GetChild(i).GetComponent<Image>();
			}
		}

		delayTimer = Time.time + holdTime;
		myCounter = screensToFade.Length;
		screenNumber = screensToFade.Length;
		FadeInAll();
	}

	void Update(){
		if(delayTimer <= Time.time){
			screenNumber--;
			if(screenNumber <= 0){
				FadeInAll();
			}else{
				FadeOut();
			}
			delayTimer = Time.time + holdTime;
		}
	}

	void FadeOut() {
		activeScreen = screensToFade[screenNumber];
		foreach(Image img in activeScreen.gameObject.GetComponentsInChildren<Image>()){
			img.CrossFadeAlpha(0, transitionTime, false);
		}
	}

	void FadeInAll() {
		screenNumber = screensToFade.Length;
		myCounter = screensToFade.Length;
		delay = 0;
		foreach(Image screen in screensToFade){
			Invoke("FadeInScreen", delay);
			delay = .5F;
		}
	}

	void FadeInScreen() {
		myCounter--;
		Image screen = screensToFade[myCounter];
		foreach(Image img in screen.GetComponentsInChildren<Image>()){
			img.CrossFadeAlpha(1, transitionTime, false);
		}
	}
}
