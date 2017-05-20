using UnityEngine;
using System.Collections;

public class AutoEnablePanel : MonoBehaviour {
	[SerializeField] GameObject enablePanel;
	[SerializeField] GameObject HeaderObject;
	[SerializeField] string HeaderRowName;
	[SerializeField] GameObject BodyObject;
	[SerializeField] string BodyRowName;

	// Use this for initialization
	void OnEnable () {
		if(HeaderRowName != null && HeaderRowName != string.Empty){
			if(HeaderObject != null)
				HeaderObject.GetComponent<SheetToText>().RowName = HeaderRowName;
		}
		if(BodyRowName != null && BodyRowName != string.Empty){
			if(BodyObject != null)
				BodyObject.GetComponent<SheetToText>().RowName = BodyRowName;
		}

		enablePanel.SetActive(true);
	}

}
