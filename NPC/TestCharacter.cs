using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TestCharacter : NPC {
	[SerializeField] string[] words;
	[SerializeField] string[] btnWords;
	[SerializeField] AudioClip[] audioClips;
	[SerializeField] Sprite charSprite;

	public void InitaliseTalk(){
		spokenWords = words;
		selectWords = btnWords;
		spokenAudio = audioClips;
		characterSprite = charSprite;
		currText = 0;
		npcWindow.SetActive(true);
		npcWindow.GetComponent<NpcWinScript>().Setup(charSprite);
		LoadWords();
	}

	void NextWords(){
		if(gm.currentState == GameManager.State.NPC){
			switch(currText){
			case 0:
				npcWindow.SetActive(true);
				npcBtnWin.transform.parent.gameObject.SetActive(false);
				currText = 1;
				LoadWords();
				break;
			case 1:
				RemoveButtons();
				CreateButton(selectWords[0], 3);
				CreateButton(selectWords[1], 2);
				CreateButton(selectWords[2], 2);
				npcWindow.SetActive(false);
				npcBtnWin.transform.parent.gameObject.SetActive(true);
				break;
			case 2:
				npcWindow.SetActive(true);
				npcBtnWin.transform.parent.gameObject.SetActive(false);
				LoadWords();
				currText = -1;
				break;
			case 3:
				npcWindow.SetActive(true);
				npcBtnWin.transform.parent.gameObject.SetActive(false);
				LoadWords();
				currText = -1;
				break;
			default:
				gm.currentState = GameManager.State.Game;
				gm.GameState ();
				return;
			}
		}
	}
	
	public void ButtonClick(int i){
		currText = i;
		NextWords();
	}
}