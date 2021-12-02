using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour {

	public List<Item> itemInv = new List<Item>();

	GameManager gm;
	float weight = 0;

	void Start(){
		gm = FindObjectOfType<GameManager>();
	}

	public void AddItem(Item i, int quantity){
		Item temp = CopyMachine.CopyItem(i);
		temp.quantity = quantity;

		if(quantity > i.quantity)
			Debug.Log("You are trying to add " + quantity + " items but there is only " + i.quantity + " items in that object");

		int index = ContainsItem(i);
		if(index >= 0){
			itemInv[index].quantity += temp.quantity;
			gm.CheckIfPlayer(this.transform, i.itemName + " was added", Color.yellow);
			return;
		}
		itemInv.Add(temp);

		gm.CheckIfPlayer(this.transform, temp.itemName + " was added", Color.yellow);
	}
	
	public void RemoveItem(Item i, int quantity){
		int index = ContainsItem(i);
		if(index >= 0){				
			if(itemInv[index].quantity > quantity){
				itemInv[index].quantity -= quantity;
				gm.CheckIfPlayer(this.transform, i.itemName + " was removed", Color.yellow);
				return;
			} else {
				itemInv.RemoveAt(index);
				gm.CheckIfPlayer(this.transform, i.itemName + " was removed", Color.yellow);
				return;
			}
		}
	}
	
	public int FiredAmmo(Item i){
		int index = ContainsItem(i);
		if(index >= 0){				
			if(itemInv[index].quantity > 1){
				itemInv[index].quantity--;
				return itemInv[index].quantity;
			} else {
				itemInv.RemoveAt(index);
			}
		}
		return 0;
	}
	
	public int ContainsItem(Item i){
		for(int j = 0; j < itemInv.Count; j++){
			if(itemInv[j].id == i.id){
				return j;
			}
		}
		return -1;
	}

	public void EquiptItem(Item i){
		if(this.gameObject.tag == "Player"){
			this.transform.GetComponent<PlayerController>().EquiptItem(i);
		}
	}
	
	void CheckWeight(){
		foreach(Item i in itemInv){
			weight += i.weight;
		}
	}
}