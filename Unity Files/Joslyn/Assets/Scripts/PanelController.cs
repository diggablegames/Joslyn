using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PanelController : MonoBehaviour {
	public enum sceneNames{Gossaert, Rembrandt, Degas}
	public sceneNames sceneName;
	string VersionNumber;
	[SerializeField] bool buildPanelListDynamically;
	[SerializeField] GameObject dynamicDirectory;
	[SerializeField] GameObject startPanel;
	[SerializeField] GameObject[] PanelList;
	[SerializeField] float delayTimerInMinutes=3;
	[SerializeField] Sprite[] alternateSprites;

	float panelTimer;

	void Start(){
		int goChildCount = dynamicDirectory.transform.childCount;
		PanelList = new GameObject[goChildCount];
		panelTimer = Time.time + (delayTimerInMinutes*60);

		//System.IO.StreamReader file = new System.IO.StreamReader(Application.dataPath + "/Resources/version.txt");
		VersionNumber = "version: .011a";// file.ReadLine();
		for (int i=0;i<goChildCount;i++){
			PanelList[i] = dynamicDirectory.transform.GetChild(i).gameObject;
		}
		enablePanel(startPanel);
	}

	void Update(){
		if(Time.time > panelTimer){
			enablePanel(startPanel);
		}
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
		panelTimer = Time.time + (delayTimerInMinutes*60);
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
		panelTimer = Time.time + (delayTimerInMinutes*60);
		PanelList[panelId].SetActive(true);
	}

	public void getVersionNumber(Text versionField){
		versionField.text = VersionNumber;
	}

	public Sprite getOutlineSprite(string spriteName){
		foreach(Sprite outlineSprite in alternateSprites){
			if(outlineSprite.name == spriteName){
				return outlineSprite;
			}
		}
		return null;
	}
}
