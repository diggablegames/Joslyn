using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SheetToText : MonoBehaviour {
	public string RowName;

	void Start () {
		if(GameManager.googleSheets.GoogleSheetsActive){
			string newText = GameManager.googleSheets.GetSheetText(RowName);
			Text TextData = gameObject.GetComponent<Text>();
			if(newText != "error" && TextData != null)
				TextData.text = newText;
			TextWithEvents twe = gameObject.GetComponent<TextWithEvents>();
			if(twe != null)
				twe.Restart(newText);
		}
	}

}
