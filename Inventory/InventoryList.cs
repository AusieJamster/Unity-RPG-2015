using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class InventoryList : MonoBehaviour {

	public Inventory inv;
	[SerializeField] Transform otherInv;
	private Button btnPrefab;
	private GameManager gm;
	private int category = 0;
	private PlayerController plyrCon;

	void Start(){
		if(plyrCon == null){
			gm = FindObjectOfType<GameManager>();
			plyrCon = gm.plyrController;
			if(otherInv != null)
				btnPrefab = gm.tradeBtn;
			else
				btnPrefab = gm.invBtn;
			AssignButtons(0);
		}
	}

	public void UpdateList(Slider slider){
		AssignButtons((int)slider.value);
	}

	public void AssignButtons(int setting){
		if(plyrCon == null)
			Start ();
		category = setting;
		for(int i = 0; i < this.transform.childCount; i++){
			Destroy(this.transform.GetChild(i).gameObject);
		}

		for(int i = 0; i < inv.itemInv.Count; i++){
			if(setting <= inv.itemInv[i].id && setting + 1 > inv.itemInv[i].id || setting == -1){
				Button btn = btnPrefab;
				btn.transform.GetChild(0).GetComponent<Text>().text = inv.itemInv[i].quantity + " - " + inv.itemInv[i].itemName;
				btn = Instantiate(btn);
				btn.transform.SetParent( this.transform );
				if(gm.currentState == GameManager.State.Inventory){
					btn.GetComponent<InvButtonScript>().item = inv.itemInv[i];
					btn.GetComponent<InvButtonScript>().gm = gm;
				}
				else if(gm.currentState == GameManager.State.Trade){
					btn.GetComponent<TradeButtonScript>().item = inv.itemInv[i];
					btn.GetComponent<TradeButtonScript>().otherInv = otherInv;
					btn.GetComponent<TradeButtonScript>().gm = gm;
				}
				if(inv.itemInv[i].id == plyrCon.eWeapon.id){
					btn.GetComponentInChildren<Text>().color = Color.white;
				}
				else if(inv.itemInv[i].id == plyrCon.eBody.id){
					btn.GetComponentInChildren<Text>().color = Color.white;
				}
				else if(inv.itemInv[i].id == plyrCon.eHead.id){
					btn.GetComponentInChildren<Text>().color = Color.white;
				}
				if(plyrCon.eAmmo != null){
					if(inv.itemInv[i].id == plyrCon.eAmmo.id){
						btn.GetComponentInChildren<Text>().color = Color.white;
					}
				}
			}
		}
	}
	public void Refresh(){
		AssignButtons(category);
	}
}