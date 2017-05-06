using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HotSpotsController : MonoBehaviour {
	[SerializeField] GameObject fullscreen;
	[SerializeField] Image HotSpotButton;
	[SerializeField] Sprite HotOn;
	[SerializeField] Sprite HotOff;

	void OnEnable(){
		setImage(false);
	}

	public void toggleImage(){
		if(fullscreen.activeSelf){
			setImage(false);
		}else{
			setImage(true);
		}
	}
	void setImage(bool setActive){
		if(setActive){
			HotSpotButton.sprite = HotOn;
			fullscreen.SetActive(true);
		}else{
			HotSpotButton.sprite = HotOff;
			fullscreen.SetActive(false);
		}
	}

	public void showHotSpotPopup(GameObject selectedHotSpot){
		GameManager.panelController.enablePopup(selectedHotSpot.name);
	}
}
