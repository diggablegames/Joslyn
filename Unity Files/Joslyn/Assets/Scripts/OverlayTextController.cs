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

	ScrollRect bodyScrollRect;
//	[SerializeField] GameObject BodyUpArrow;
//	[SerializeField] GameObject BodyDnArrow;

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

	void Start(){
		bodyScrollRect = gameObject.GetComponentInChildren<ScrollRect>();
//		if(bodyScrollRect.viewport.rect.height/bodyScrollRect.content.rect.height > 1){
//			BodyUpArrow.SetActive(false);
//			BodyDnArrow.SetActive(false);
//		}
	}
	void OnEnable(){
		if(bodyScrollRect == null)
			bodyScrollRect = gameObject.GetComponentInChildren<ScrollRect>();
		bodyScrollRect.verticalNormalizedPosition = 1; //reset scrolling panel back to top
	}

	void Update(){
		if(bodyScrollRect == null)
			bodyScrollRect = gameObject.GetComponentInChildren<ScrollRect>();

//		if(bodyScrollRect.viewport.rect.height/bodyScrollRect.content.rect.height > 1){
//			BodyUpArrow.SetActive(false);
//			BodyDnArrow.SetActive(false);
//		}
	}

	public void scrollBodyUp(){
		if(bodyScrollRect.verticalNormalizedPosition<=1)
			bodyScrollRect.verticalNormalizedPosition += bodyScrollRect.viewport.rect.height/bodyScrollRect.content.rect.height;
	}
	public void scrollBodyDown(){
		if(bodyScrollRect.verticalNormalizedPosition >0)
			bodyScrollRect.verticalNormalizedPosition -= bodyScrollRect.viewport.rect.height/bodyScrollRect.content.rect.height;
	}
}
