using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using UnityEditor.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Linq;
using System.Text.RegularExpressions;

public class ImportGoSheetsText : EditorWindow{
	private static string url;
	private static string gId = "0";
	private static int languageNumber = 1;
//	private static GameObject obj;
	private static string[][] sheet;

	[MenuItem("Tools/Build GoSheets")]
	static void BuildGoSheets(){
		sheet = GoSheets.GetGoogleSheetNative("https://docs.google.com/spreadsheets/d/1x4joknHAdlCSH_G1ADuBNX9450I-avkazXRfbHPsvx4/edit?usp=sharing", "0");
//		List<string> foundFields = new List<string>();
		GameObject[] selectedObjects = Selection.gameObjects;
		foreach(GameObject go in selectedObjects){
			setTextField(go);
		}
	}


	static void setTextField(GameObject obj){
		TextWithEvents textWEvents = obj.GetComponent<TextWithEvents>();
		if(textWEvents){
//			textWEvents.text = GetSheetText(obj.name);
			setTextWithEvents(obj, GetSheetText(obj.name));
			Debug.Log("Found Text With Event Component: " + obj.name);
		}else{
			EditorUtility.SetDirty(obj);
			EditorSceneManager.MarkSceneDirty(obj.scene);
			Text textComponent = obj.GetComponent<Text>();
			if(textComponent){
				string goText = GetSheetText(obj.name);
				if(goText == "error" || goText == string.Empty){
					textComponent.text = "";
				}else{
					textComponent.text = goText;
				}
				UnityEditor.EditorUtility.SetDirty(textComponent);

//				Debug.Log("Found Text Component: " + obj.name);
			}
		}
	}
	static void setTextWithEvents(GameObject obj, string newText){
//		string newText = GameManager.googleSheets.GetSheetText(RowName);
		Text TextData = obj.GetComponent<Text>();
		if(newText != "error" && TextData != null){
			TextData.text = newText;
			UnityEditor.EditorUtility.SetDirty(TextData);
		}
		TextWithEvents twe = obj.GetComponent<TextWithEvents>();
		if(twe != null){
			twe.text = newText;
			UnityEditor.EditorUtility.SetDirty(twe);
			twe.Restart(newText);
		}
	}

	static string GetSheetText(string rowName) {
		if(rowName == string.Empty || rowName == null){
			//			Debug.Log("RowName is empty");
			return "error";
		}
		if(sheet == null) sheet = GoSheets.GetGoogleSheetNative("https://docs.google.com/spreadsheets/d/1x4joknHAdlCSH_G1ADuBNX9450I-avkazXRfbHPsvx4/edit?usp=sharing", "0");

		int rowNumber = FindRow(rowName);
		if(rowNumber > 0)
			return Regex.Replace(sheet[rowNumber][languageNumber], @"<br>", "\n");
		else{
			Debug.Log("Error: Cell Not Found ( English (" + languageNumber + ") : " + rowName + "(" + rowNumber + "))");
			return "error";
		}
	}

	static int FindRow(string rowName){
		for(int i=0; i<sheet.Length; i++){
			if(sheet[i][0] == rowName){
				return i;
			}
		}
		return -1;
	}

}
