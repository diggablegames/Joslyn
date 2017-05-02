using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

[System.Serializable]
public class MenuPanel{
	public SheetToText MenuPanelObject;
	public string menuTextRowName;
	public DestinationButton menuPanelButton;
	public GameObject menuPanelDestination;
}

public class OverlayTextController : MonoBehaviour {
	[SerializeField] GameObject HeaderObject;
	[SerializeField] string HeaderRowName;
	[SerializeField] GameObject BodyObject;
	[SerializeField] string BodyRowName;

	[SerializeField] DestinationButton CloseButtonObject;
	[SerializeField] GameObject CloseButtonDestination;

	[Header("Background Menu Text")]
	[SerializeField] MenuPanel[] menuPanels;

	// Use this for initialization
	void Awake () {
		if(HeaderRowName != null && HeaderRowName != string.Empty){
			if(HeaderObject != null)
				HeaderObject.GetComponent<SheetToText>().RowName = HeaderRowName;
		}
		if(BodyRowName != null && BodyRowName != string.Empty){
			if(BodyObject != null)
				BodyObject.GetComponent<SheetToText>().RowName = BodyRowName;
		}

		foreach(MenuPanel menuItem in menuPanels){
			menuItem.MenuPanelObject.RowName = menuItem.menuTextRowName;
			if(menuItem.menuPanelDestination != null)
				menuItem.menuPanelButton.ButtonDestination = menuItem.menuPanelDestination;
		}

		if(CloseButtonObject != null){
			CloseButtonObject.ButtonDestination = CloseButtonDestination;
		}
	}
}
