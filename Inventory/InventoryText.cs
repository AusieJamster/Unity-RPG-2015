using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InventoryText : MonoBehaviour {
	private Text[] texts;

	void Start(){
		texts = this.transform.GetComponentsInChildren<Text>();
		foreach(Text t in texts){
			t.color = Color.gray;
		}
		if(texts.Length > 5){
			texts[1].color = Color.white;
		}
		else{
			texts[0].color = Color.white;
		}
	}

	public void Change(Slider slider){
		int v = (int)slider.value;
		if(slider.minValue == -1){
			v++;
		}
		foreach(Text t in texts){
			t.color = Color.gray;
		}

		texts[v].color = Color.white;
	}
}
