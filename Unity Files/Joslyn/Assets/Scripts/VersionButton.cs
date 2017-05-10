using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class VersionButton : MonoBehaviour {
	[SerializeField] Text versionField;

	void Start(){
		HideVersionNumber();
	}

	public void ShowVersionNumber(){
		GameManager.panelController.getVersionNumber(versionField);
		versionField.gameObject.SetActive(true);
	}

	public void HideVersionNumber(){
		versionField.gameObject.SetActive(false);
	}
}
