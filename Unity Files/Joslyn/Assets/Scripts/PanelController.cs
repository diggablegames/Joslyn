using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PanelController : MonoBehaviour {
	[SerializeField] bool buildPanelListDynamically;
	[SerializeField] GameObject dynamicDirectory;
	[SerializeField] GameObject startPanel;
	[SerializeField] GameObject[] PanelList;

	void Start(){
		int goChildCount = dynamicDirectory.transform.childCount;
		PanelList = new GameObject[goChildCount];
		for (int i=0;i<goChildCount;i++){
			PanelList[i] = dynamicDirectory.transform.GetChild(i).gameObject;
		}
		enablePanel(startPanel);
	}


	//since we are working with images we may want to make these fade instead of pop in and out
	void disableAllPanels(){
		foreach(GameObject go in PanelList){
			go.SetActive(false);
		}
	}

	public void enablePanel(string panelName){
		for(int i=0;i<PanelList.Length;i++){
			if(PanelList[i].name == panelName){
				enablePanel(i);
			}
		}
	}

	public void enablePanel(GameObject panelObject){
		for(int i=0;i<PanelList.Length;i++){
			if(PanelList[i] == panelObject){
				enablePanel(i);
			}
		}
	}

	public void enablePanel(int panelId){
		for(int i=0;i<PanelList.Length;i++){
			if(i==panelId)
				PanelList[panelId].SetActive(true);
			else
				PanelList[i].SetActive(false);
		}
	}

	public void enablePopup(string panelName){
		for(int i=0;i<PanelList.Length;i++){
			if(PanelList[i].name == panelName){
				enablePopup(i);
			}
		}
	}

	public void enablePopup(GameObject panelObject){
		for(int i=0;i<PanelList.Length;i++){
			if(PanelList[i] == panelObject){
				enablePopup(i);
			}
		}
	}

	public void enablePopup(int panelId){
		PanelList[panelId].SetActive(true);
	}
}
