using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class MoveMask : MonoBehaviour {
	[SerializeField] Canvas myCanvas;
	[SerializeField] Transform MaskObject;

	void Start(){
	}

	void Update(){
		Vector2 pos;
		RectTransformUtility.ScreenPointToLocalPointInRectangle(myCanvas.transform as RectTransform, Input.mousePosition, myCanvas.worldCamera, out pos);
		MaskObject.position = myCanvas.transform.TransformPoint(pos);
		//touchPosition();
	}
}

