using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NpcWinScript : MonoBehaviour {
	Text textBox;
	Image npcImage;
	AudioSource audioPlayer;
	GameManager gm;

	void Start(){
		if(npcImage == null){
			gm = FindObjectOfType<GameManager>();
			audioPlayer = gm.voiceSource;
			textBox = this.GetComponentInChildren<Text>();
			npcImage = this.transform.GetChild(1).GetComponent<Image>();
		}
	}

	public void Setup(Sprite i){
		if(npcImage == null)
			Start ();
		npcImage.sprite = i;
	}
	
	public void ChangeText(string s, AudioClip clip){
		textBox.text = s;
		audioPlayer.PlayOneShot(clip);
	}
}