using UnityEngine;
using System.Collections;

public class ChestScript : MonoBehaviour {
	private GameManager gm;
	private Initialise initial;
	private Inventory inv;
	private GameObject tradeWindow;
	private InventoryList inventoryOther;
	[SerializeField] float[] ids;

	private bool untouched = true;

	void Start(){
		gm = FindObjectOfType<GameManager>();
		inventoryOther = gm.invTradeListOther;
		inv = this.GetComponent<Inventory>();
		initial = gm.initialiseScript;
		tradeWindow = gm.tradeWindow;
	}

	void Update(){
		if(gm.currentState == GameManager.State.Trade){
			if(Input.GetButtonDown("E")){
				Invoke("EndTrade", 0.1f);
			}
		}
	}
	
	public void InitaliseTrade(){
		if(untouched)
			GetItems();
		untouched = false;
		tradeWindow.SetActive(true);
		inventoryOther.inv = this.GetComponent<Inventory>();
	}
	
	void EndTrade(){
		gm.currentState = GameManager.State.Game;
		gm.GameState();
	}

	void GetItems(){
		for(int i = 0; i < ids.Length; i++){
			Item temp = initial.SearchItem(ids[i]);
			inv.AddItem(temp, 1);
		}
	}
}
