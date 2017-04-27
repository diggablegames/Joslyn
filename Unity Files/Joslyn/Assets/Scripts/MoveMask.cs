using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class MoveMask : MonoBehaviour {
	Material DemoCubeTexMaterial;
	InstantShaderMask IMShaderGUIScript;


	void Start(){
		IMShaderGUIScript = GetComponent<InstantShaderMask> ();
	}
	void Update(){
		
		//IMShaderGUIScript.Mask1Position += new Vector2(.001f, .001f);
	}

	public void touchPosition(){
		IMShaderGUIScript.Mask1Position = new Vector2((Input.mousePosition.x/Screen.width)-.07f, (Input.mousePosition.y/Screen.height)-.1f);
//		Debug.Log( "X: " + Input.mousePosition.x/Screen.width + "   Y: " + Input.mousePosition.y/Screen.height);
	}
}

