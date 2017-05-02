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

	void Awake () {
		if(HeaderRowName != null && HeaderRowName != string.Empty){
			if(HeaderObject != null)
				HeaderObject.GetComponent<SheetToText>().RowName = HeaderRowName;
		}
		if(BodyRowName != null && BodyRowName != string.Empty){
			if(BodyObject != null)
				BodyObject.GetComponent<SheetToText>().RowName = BodyRowName;
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
}
