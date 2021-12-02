using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class NPCBtnScript : MonoBehaviour, IPointerClickHandler {

	public TestCharacter character;
	public int button;

	public void OnPointerClick(PointerEventData eventData){
		character.ButtonClick(button);
	}
}
