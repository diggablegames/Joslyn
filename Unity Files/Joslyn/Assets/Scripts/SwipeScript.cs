using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SwipeScript : MonoBehaviour {
	//inside class
	Vector2 firstPressPos = new Vector2(0,0);
	Vector2 secondPressPos = new Vector2(0,0);
	Vector2 currentSwipe = new Vector2(0,0);


	[SerializeField] ScrollRect scrollRect;
	Scrollbar hScrollbar;


	[SerializeField] Transform contentContainer;
	[SerializeField] int imageCount;
	[SerializeField] float snapDistance;
	float scrollValue;
	// Use this for initialization
	void Start () {
		if(scrollRect == null)
			scrollRect = GetComponent<ScrollRect>();
		hScrollbar = scrollRect.horizontalScrollbar;

		imageCount = contentContainer.childCount;
		snapDistance = 1.0f/(imageCount-1);
		snapDistance = Mathf.Round(snapDistance * 1000) / 1000;
	}

	void swipeUp(){
//		Debug.Log("swipeUp");
	}
	void swipeDown(){
//		Debug.Log("swipeDown");
	}
	void swipeLeft(){
		if(scrollValue == 1){
			hScrollbar.value = 0;
//		}else{
//			hScrollbar.value += snapDistance;
		}
//		Debug.Log("swipeLeft");
	}
	void swipeRight(){
		if(hScrollbar.value == 0){
			hScrollbar.value = 1;
//		}else{
//			hScrollbar.value -= snapDistance;
		}
//		Debug.Log("swipeRight");
	}

	void LateUpdate() {
		MouseSwipe();
		TouchSwipe();
	}


	public void TouchSwipe(){
		if(Input.touches.Length > 0){
			Touch t = Input.GetTouch(0);
			if(t.phase == TouchPhase.Began){
				//save began touch 2d point
				firstPressPos.x = t.position.x;
				firstPressPos.y = t.position.y;
			}
			if(t.phase == TouchPhase.Ended){
				secondPressPos.x = t.position.x;
				secondPressPos.y = t.position.y;

				//create vector from the two points
				currentSwipe.x = secondPressPos.x - firstPressPos.x;
				currentSwipe.y = secondPressPos.y - firstPressPos.y;
				currentSwipe.Normalize();

				if(currentSwipe.y > 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f){
					swipeUp();
				}
				if(currentSwipe.y < 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f){
					swipeDown();
				}
				if(currentSwipe.x < 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f){
					swipeLeft();
				}
				if(currentSwipe.x > 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f){
					swipeRight();
				}
			}
		}
	}

	public void MouseSwipe() {
		if(Input.GetMouseButtonDown(0)){
			firstPressPos.x = Input.mousePosition.x;
			firstPressPos.y = Input.mousePosition.y;
		}
		if(Input.GetMouseButtonUp(0)){
			//save ended touch 2d point
			secondPressPos.x = Input.mousePosition.x;
			secondPressPos.y = Input.mousePosition.y;
			currentSwipe.x = secondPressPos.x - firstPressPos.x;
			currentSwipe.y = secondPressPos.y - firstPressPos.y;
			currentSwipe.Normalize();

			if(currentSwipe.y > 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f){
				swipeUp();
			}
			if(currentSwipe.y < 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f){
				swipeDown();
			}
			if(currentSwipe.x < 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f){
				swipeLeft();
			}
			if(currentSwipe.x > 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f){
				swipeRight();
			}
		}
	}
}