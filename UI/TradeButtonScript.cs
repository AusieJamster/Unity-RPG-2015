using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class TradeButtonScript : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler {
	public Item item;
	private Inventory inv;
	public Transform otherInv;
	private InvDisplay dis;
	public GameManager gm;

	void Start(){
		inv = this.transform.parent.GetComponent<InventoryList>().inv;
		dis = this.transform.parent.parent.parent.GetComponentInChildren<InvDisplay>();

		if(item.quantity <= 0){
			inv.RemoveItem(item, 0);
			Destroy(this.gameObject);
		}
	}

	public void OnPointerEnter(PointerEventData eventData){
		dis.Display(item);
	}
	
	public void OnPointerClick(PointerEventData eventData){

		if(item.quantity > 5){
			gm.currentState = GameManager.State.Quantity;
			gm.GameState ();
			gm.quantitySlider.GetComponent<QuantityScript>().Setup(item, otherInv.GetComponent<InventoryList>().inv);
		}
		else if(item.quantity <= 0){
			otherInv.GetComponent<InventoryList>().inv.AddItem(item, 1);
			item.quantity--;
			inv.RemoveItem(item, 0);
			Destroy(this.gameObject);
		}
		else{			
			otherInv.GetComponent<InventoryList>().inv.AddItem(item, 1);
			item.quantity--;
		}

		otherInv.GetComponent<InventoryList>().Refresh();
		this.transform.parent.GetComponent<InventoryList>().Refresh();
	}
}