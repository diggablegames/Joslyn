using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[System.Serializable]
public class IconButton{
	public DestinationButton iconObject;
	public Sprite iconImage;
	public GameObject iconDestination;
}

public class LayoutScreenController : MonoBehaviour {
	[SerializeField] GameObject HeaderObject;
	[SerializeField] string HeaderRowName;
	[SerializeField] GameObject BodyObject;
	[SerializeField] string BodyRowName;

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

		foreach(IconButton iconButton in IconButtons){
			if(iconButton.iconDestination == null){
				iconButton.iconObject.gameObject.SetActive(false);
			}else{
				iconButton.iconObject.gameObject.SetActive(true);
				iconButton.iconObject.ButtonDestination = iconButton.iconDestination;
			}
		}

		if(CloseButtonObject != null){
			CloseButtonObject.ButtonDestination = CloseButtonDestination;
		}
	}

	void GoSheetsToText(GameObject iGameObject, string iRowName){
		if(GameManager.googleSheets.GoogleSheetsActive){
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
