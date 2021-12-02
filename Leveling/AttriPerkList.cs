using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class AttriPerkList : MonoBehaviour {

	GameManager gm;
	Button btnPrefab;
	Initialise inital;

	void Start(){
		gm = FindObjectOfType<GameManager>();
		btnPrefab = gm.skillPerkBtn;
		inital = gm.initialiseScript;
	}

	public void AssignButtons(){
		int perksAvaliable = 0;

		if(gm == null)
			Start ();
		for(int i = 0; i < this.transform.childCount; i++){
			Destroy(this.transform.GetChild(i).gameObject);
		}
		if(gm.currentState == GameManager.State.Levelup){
			for(int i = 0; i < inital.allSkills.Count; i++){
				Button btn = btnPrefab;
				btn.transform.GetChild(0).GetComponent<Text>().text = inital.allSkills[i].aName;
				btn = Instantiate(btn);
				btn.transform.SetParent( this.transform );
				SkillBtnScript script = btn.GetComponent<SkillBtnScript>();
				if(gm.stats.selectedSkills.Contains(inital.allSkills[i].id))
					btn.transform.GetComponentInChildren<Text>().color = Color.white;
				script.skill = inital.allSkills[i];
				script.gm = gm;
				script.list = this;
			}

			for(int i = 0; i < inital.allPerks.Count; i++){
				bool avaliable = true;
				for(int j = 0; j < inital.allPerks[i].skillID.Length; j++){
					if(gm.stats.skills[inital.allPerks[i].skillID[j]] < inital.allPerks[i].skillLevel[j]){
						avaliable = false;
					}
				}
				if(avaliable)
					perksAvaliable++;
			}

			if(gm.stats.selectedSkills.Count == 3 || gm.stats.selectedSkills.Count == 1 && perksAvaliable > 0){
				gm.submitButton.GetComponentInChildren<Text>().color = Color.cyan;
				gm.submitButton.interactable = true;
			}
			else{
				gm.submitButton.GetComponentInChildren<Text>().color = Color.grey;
				gm.submitButton.interactable = false;
			}
		}
		else if(gm.currentState == GameManager.State.Perk){
			for(int i = 0; i < inital.allPerks.Count; i++){
				Button btn = btnPrefab;
				btn.transform.GetChild(0).GetComponent<Text>().text = inital.allPerks[i].aName;
				btn = Instantiate(btn);
				btn.transform.SetParent( this.transform );
				SkillBtnScript script = btn.GetComponent<SkillBtnScript>();
				script.perk = inital.allPerks[i];
				script.gm = gm;
				script.list = this;
				for(int j = 0; j < inital.allPerks[i].skillID.Length; j++){
					if(gm.stats.skills[inital.allPerks[i].skillID[j]] >= inital.allPerks[i].skillLevel[j]){
						btn.interactable = true;
						btn.GetComponentInChildren<Text>().color = Color.cyan;
						perksAvaliable++;
					}
					else{
						btn.interactable = false;
						btn.GetComponentInChildren<Text>().color = Color.grey;
					}
				}
				if(gm.stats.selectedPerk == inital.allPerks[i].id)
					btn.transform.GetComponentInChildren<Text>().color = Color.white;
			}
			Debug.Log(gm.stats.selectedPerk);

			if(gm.stats.selectedPerk != -1){
				Debug.Log("Active");
				gm.submitButton.GetComponentInChildren<Text>().color = Color.cyan;
				gm.submitButton.interactable = true;
			}
			else{
				Debug.Log("Inactive");
				gm.submitButton.GetComponentInChildren<Text>().color = Color.grey;
				gm.submitButton.interactable = false;
			}
			Debug.Log(gm.stats.selectedPerk);
		}
	}
}