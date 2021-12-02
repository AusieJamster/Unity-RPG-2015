using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class SkillBtnScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler {

	public ButtonDetails skill;
	public Perk perk;
	public GameManager gm;
	private InvDisplay dis;
	public AttriPerkList list;

	void Start(){
		dis = this.transform.parent.parent.parent.GetComponentInChildren<InvDisplay>();
	}
	
	public void OnPointerEnter(PointerEventData eventData){
		if(gm.currentState == GameManager.State.Levelup)
			dis.Display(skill);
		else
			dis.Display(perk);
	}
	
	public void OnPointerExit(PointerEventData eventData){
		dis.Clear ();
	}
	
	public void OnPointerClick(PointerEventData eventData){
		if(this.GetComponent<Button>().interactable){
			if(gm.currentState == GameManager.State.Levelup){
				if(this.transform.GetComponentInChildren<Text>().color != Color.white){
					gm.stats.AddSelectedSkill(skill.id);
					list.AssignButtons();
				}
				else{
					gm.stats.RemoveSelectedSkill(skill.id);
					list.AssignButtons();
				}
			}
			else{
				gm.stats.selectedPerk = perk.id;
				list.AssignButtons();
			}
		}
	}
}

