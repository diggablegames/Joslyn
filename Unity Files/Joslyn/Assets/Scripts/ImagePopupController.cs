using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ImagePopupController : MonoBehaviour {
	[SerializeField] Sprite displayImage;
	[SerializeField] Image imageDestination;

	[SerializeField] string BodyRowName;
	[SerializeField] GameObject BodyObject;
	[SerializeField] RectTransform BodyBGRectT;
	[SerializeField] float BodyBGPadding;
	Vector2 rectSize = new Vector2(0,0);

	ScrollRect bodyScrollRect;
//	[SerializeField] GameObject BodyUpArrow;
//	[SerializeField] GameObject BodyDnArrow;

	void Start(){
		//add text into header from google sheets doc
		//add text into body from google sheets doc
		if(BodyRowName != null && BodyRowName != string.Empty){
			if(BodyObject != null)
				GoSheetsToText(BodyObject, BodyRowName);
		}
		if(imageDestination != null)
			imageDestination.sprite = displayImage;
		bodyScrollRect = gameObject.GetComponentInChildren<ScrollRect>();
//		BodyUpArrow.SetActive(false);
//		BodyDnArrow.SetActive(false);
		if(bodyScrollRect.viewport.rect.height/bodyScrollRect.content.rect.height > 1){
			RectTransform rt = BodyObject.GetComponent<RectTransform>();
			rectSize.x = BodyBGRectT.sizeDelta.x;
			rectSize.y = rt.sizeDelta.y + BodyBGPadding;
			BodyBGRectT.sizeDelta = rectSize;
		}
	}

	void OnEnable(){
		if(bodyScrollRect == null)
			bodyScrollRect = gameObject.GetComponentInChildren<ScrollRect>();
		bodyScrollRect.verticalNormalizedPosition = 1; //reset scrolling panel back to top
	}

	void Update(){
		if(bodyScrollRect == null)
			bodyScrollRect = gameObject.GetComponentInChildren<ScrollRect>();

		if(bodyScrollRect.viewport.rect.height/bodyScrollRect.content.rect.height > 1){
//			BodyUpArrow.SetActive(false);
//			BodyDnArrow.SetActive(false);
			RectTransform rt = BodyObject.GetComponent<RectTransform>();
			rectSize.x = BodyBGRectT.sizeDelta.x;
			rectSize.y = rt.sizeDelta.y + BodyBGPadding;
			BodyBGRectT.sizeDelta = rectSize;
		}
	}

	public void scrollBodyUp(){
		if(bodyScrollRect.verticalNormalizedPosition<=1)
			bodyScrollRect.verticalNormalizedPosition += bodyScrollRect.viewport.rect.height/bodyScrollRect.content.rect.height;
	}
	public void scrollBodyDown(){
		if(bodyScrollRect.verticalNormalizedPosition >0)
			bodyScrollRect.verticalNormalizedPosition -= bodyScrollRect.viewport.rect.height/bodyScrollRect.content.rect.height;
	}


	void GoSheetsToText(GameObject iGameObject, string iRowName){
		if(GameManager.googleSheets.GoogleSheetsActive && Application.internetReachability == NetworkReachability.ReachableViaLocalAreaNetwork){
			string newText = GameManager.googleSheets.GetSheetText(iRowName);

			Text TextData = iGameObject.GetComponent<Text>();
			if(newText != "error" && TextData != null)
				TextData.text = newText;
			TextWithEvents twe = iGameObject.GetComponent<TextWithEvents>();
			if(twe != null)
				twe.Restart(newText);
		}
	}
}
