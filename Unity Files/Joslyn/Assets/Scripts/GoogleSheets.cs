using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class GoogleSheets : MonoBehaviour {
	public bool GoogleSheetsActive;
	public enum Languages{ENGLISH, FRENCH, ITALIAN, GERMAN, SPANISH}
	[SerializeField] Languages language = Languages.ENGLISH;
	int languageNumber;
	string[][] sheet;

	[SerializeField] string url;
	[SerializeField] string gId = "0";

	void OnEnable(){
		if(GoogleSheetsActive)
			GetSheet();
	}

	void GetSheet(){
		languageNumber = (int)language + 1;
		sheet = GoSheets.GetGoogleSheetNative(url, gId);
	}


	public string GetSheetText(string rowName) {
		if(rowName == string.Empty || rowName == null){
//			Debug.Log("RowName is empty");
			return "error";
		}
		if(sheet == null) GetSheet();
		int rowNumber = FindRow(rowName);
		if(rowNumber > 0)
			return GetCell(rowNumber, languageNumber);
		else
			
			Debug.Log("Error: Cell Not Found (" + language + "(" + languageNumber + ") : " + rowName + "(" + rowNumber + "))");
			return "error";
	}

	public void ChangeLanguage(Languages lang){
		language = lang;
		languageNumber = (int)language + 1;
		Debug.Log("Language: " + language + " (" + (int)languageNumber + ")");
	}

	int FindRow(string rowName){
		for(int i=0; i<sheet.Length; i++){
			if(sheet[i][0] == rowName){
				return i;
			}
		}
		return -1;
	}

	string GetCell(int x, int y){
		string result = Regex.Replace(sheet[x][y], @"<br>", "\n");
		return result;
	}



}
