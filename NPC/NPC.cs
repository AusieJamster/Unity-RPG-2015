using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NPC : MonoBehaviour {
	protected GameManager gm;
	protected GameObject npcWindow;
	protected GameObject npcBtnWin;
	protected Button button;

	protected string[] spokenWords;
	protected string[] selectWords;
	protected AudioClip[] spokenAudio;
	protected Sprite characterSprite;
	
	protected int currText;
	
	protected void Start(){
		gm = FindObjectOfType<GameManager>();
		npcWindow = gm.npcWindow;
		npcBtnWin = gm.npcBtnWin;
		button = gm.npcBtn;
	}
	
	protected void Update(){
		if(gm.currentState == GameManager.State.NPC){
			if(Input.GetButtonDown("E")){
				Invoke("EndTalk", 0.1f);
			}
		}
	}
	
	protected void LoadWords(){
		npcWindow.GetComponent<NpcWinScript>().ChangeText(spokenWords[currText], spokenAudio[currText]);
		if(currText < spokenAudio.Length){
			Invoke("NextWords", spokenAudio[currText].length);
		}
	}
	
	protected void CreateButton(string s, int i){
		Button b = button;
		b = Instantiate(button);
		b.GetComponentInChildren<Text>().text = s;
		b.transform.SetParent( npcBtnWin.transform );
		b.GetComponent<NPCBtnScript>().character = this.GetComponent<TestCharacter>();
		b.GetComponent<NPCBtnScript>().button = i;
	}
	
	protected void RemoveButtons(){
		for(int i = 0; i < npcBtnWin.transform.childCount; i++){
			Destroy(npcBtnWin.transform.GetChild(i).gameObject);
		}
	}
	
	protected void EndTalk(){
		gm.currentState = GameManager.State.Game;
		gm.GameState ();
	}
}
