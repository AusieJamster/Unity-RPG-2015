using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIScript : MonoBehaviour {

	public void LoadLevel (string level){
		Application.LoadLevel(level);
	}

	public void SaveOptions(Transform optionsPanel){
		Slider[] sliders = optionsPanel.GetComponentsInChildren<Slider>();
		Toggle[] toggles = optionsPanel.GetComponentsInChildren<Toggle>();

		PlayerPrefs.SetFloat("volumeMusic", sliders[0].value);
		PlayerPrefs.SetFloat("volumeSFX", sliders[1].value);
		
		if(toggles[0].isOn)
			PlayerPrefs.SetInt("muteMusic", 1);
		else
			PlayerPrefs.SetInt("muteMusic", 0);
		if(toggles[1].isOn)
			PlayerPrefs.SetInt("muteSFX", 1);
		else
			PlayerPrefs.SetInt("muteSFX", 0);
	}
}
