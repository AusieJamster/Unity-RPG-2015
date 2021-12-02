using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class QuantityScript : MonoBehaviour {

	Text quantityText;
	Slider slider;

	GameManager gm;

	Inventory inv;
	Item item;

	void StartUp () {
		gm = FindObjectOfType<GameManager>();
		quantityText = this.GetComponentInChildren<Text>();
		slider = this.GetComponentInChildren<Slider>();
	}

	public void Setup(Item myItem, Inventory myInv){
		if(slider == null)
			StartUp ();
		slider.maxValue = myItem.quantity;
		inv = myInv;
		item = myItem;
	}

	void Update () {
		quantityText.text = "Amount to Move: " + slider.value;
	}
	
	public void AcceptPressed(){
		inv.AddItem(item, (int)slider.value);
		item.quantity -= (int)slider.value;
		
		gm.currentState = GameManager.State.Trade;
		gm.GameState ();

		gm.invTradeListOther.Refresh();
		gm.invTradeList.Refresh();
	}
	
	public void CancelPressed(){
		gm.currentState = GameManager.State.Trade;
		gm.GameState ();

		gm.invTradeListOther.Refresh();
		gm.invTradeList.Refresh();
	}
}
