using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[System.Serializable]
public class IconButton{
	public bool showHilight;
	public DestinationButton iconObject;
	public Sprite iconImage;
	public GameObject iconDestination;
}

public class LayoutScreenController : MonoBehaviour {
	[SerializeField] GameObject HeaderObject;
	[SerializeField] string HeaderRowName;
	[SerializeField] GameObject BodyObject;
	[SerializeField] string BodyRowName;
	[SerializeField] RectTransform BodyBGRectT;
	[SerializeField] float BodyBGPadding;
	Vector2 rectSize = new Vector2(0,0);

	ScrollRect bodyScrollRect;
	[SerializeField] GameObject BodyUpArrow;
	[SerializeField] GameObject BodyDnArrow;

	[SerializeField] IconButton[] IconButtons;

	[SerializeField] DestinationButton CloseButtonObject;
	[SerializeField] GameObject CloseButtonDestination;

	void Start () {
		//add text into header from google sheets doc
		if(HeaderRowName != null && HeaderRowName != string.Empty){
			if(HeaderObject != null)
				GoSheetsToText(HeaderObject, HeaderRowName);
		}
		//add text into body from google sheets doc
		if(BodyRowName != null && BodyRowName != string.Empty){
			if(BodyObject != null)
				GoSheetsToText(BodyObject, BodyRowName);
		}
		
		bodyScrollRect = gameObject.GetComponentInChildren<ScrollRect>();
		if(bodyScrollRect.viewport.rect.height/bodyScrollRect.content.rect.height > 1){
			BodyUpArrow.SetActive(false);
			BodyDnArrow.SetActive(false);
			RectTransform rt = BodyObject.GetComponent<RectTransform>();
			rectSize.x = BodyBGRectT.sizeDelta.x;
			rectSize.y = rt.sizeDelta.y + BodyBGPadding;
			BodyBGRectT.sizeDelta = rectSize;
		}

		foreach(IconButton iconButton in IconButtons){
			if(iconButton.iconDestination == null){
				if(iconButton.showHilight){
//					iconButton.iconObject.gameObject.GetComponent<Outline>().enabled = true;
					iconButton.iconObject.gameObject.SetActive(true);
				}else{
//					iconButton.iconObject.gameObject.GetComponent<Outline>().enabled = false;
					iconButton.iconObject.gameObject.SetActive(false);
				}
			}else{
				iconButton.iconObject.gameObject.SetActive(true);
//				iconButton.iconObject.gameObject.GetComponent<Outline>().enabled = false;
				iconButton.iconObject.ButtonDestination = iconButton.iconDestination;
			}
		}

		if(CloseButtonObject != null){
			CloseButtonObject.ButtonDestination = CloseButtonDestination;
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
			BodyUpArrow.SetActive(false);
			BodyDnArrow.SetActive(false);
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
