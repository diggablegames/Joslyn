using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AlphaSlider : MonoBehaviour {
	[SerializeField] Image sliderImage;
	[SerializeField] Slider slider;
	Color imageColor;

	void Start(){
		imageColor = sliderImage.color;
	}
	
	// Update is called once per frame
	public void ValueChanged () {
		imageColor.a = slider.value;
		sliderImage.color = imageColor;
	}
}
