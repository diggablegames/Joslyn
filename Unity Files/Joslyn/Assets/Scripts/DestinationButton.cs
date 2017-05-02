using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class DestinationButton : MonoBehaviour {
	public GameObject ButtonDestination;

	void Start()
	{
		EventTrigger trigger = GetComponent<EventTrigger>();
		EventTrigger.Entry entry = new EventTrigger.Entry();
		entry.eventID = EventTriggerType.PointerDown;
		entry.callback.AddListener((data) => { OnPointerUp((PointerEventData)data); });
		trigger.triggers.Add(entry);
	}

	public void OnPointerUp(PointerEventData data)
	{
		Debug.Log("OnPointerUp: " + ButtonDestination.name);
		GameManager.panelController.enablePanel(ButtonDestination);
	}
}
