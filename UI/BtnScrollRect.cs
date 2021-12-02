using UnityEngine;
using System.Collections;

public class BtnScrollRect : MonoBehaviour {

	[SerializeField] float divideScreenBy;

	void LateUpdate() {
		float buttonHeight = Screen.height / 20;
		float myHeight = this.transform.childCount * (buttonHeight);

		this.GetComponent<RectTransform>().sizeDelta = new Vector2 ( 0, myHeight - Screen.height/divideScreenBy);
	}
}
