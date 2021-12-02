using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class InvButtonScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler {
	public Item item;
	Inventory inv;
	private InvDisplay dis;
	public GameManager gm;

	void Start(){
		inv = this.transform.parent.GetComponent<InventoryList>().inv;
		dis = this.transform.parent.parent.parent.GetComponentInChildren<InvDisplay>();
	}

	public void OnPointerEnter(PointerEventData eventData){
		dis.Display(item);
	}
	
	public void OnPointerExit(PointerEventData eventData){
		dis.Clear();
	}
	
	public void OnPointerClick(PointerEventData eventData){
		inv.EquiptItem(item);
		this.transform.GetComponentInParent<InventoryList>().Refresh();
	}
}