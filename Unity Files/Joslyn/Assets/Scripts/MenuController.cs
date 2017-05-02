using UnityEngine;
using System.Collections;


public class MenuController : MonoBehaviour {
	[SerializeField] MenuPanel[] menuPanels;

	[SerializeField] DestinationButton CloseButtonObject;
	[SerializeField] GameObject CloseButtonDestination;

	void Awake () {
		foreach(MenuPanel menuItem in menuPanels){
			menuItem.MenuPanelObject.RowName = menuItem.menuTextRowName;
			menuItem.menuPanelButton.ButtonDestination = menuItem.menuPanelDestination;
		}

		if(CloseButtonObject != null){
			CloseButtonObject.ButtonDestination = CloseButtonDestination;
		}
	}
}
