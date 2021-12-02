using UnityEngine;
using System.Collections;

public class ButtonDetails {
	public int id;
	public string aName;
	public Sprite image;
	public string description;

	public ButtonDetails(int myID, string myName, Sprite myImage, string myDescription){
		this.id = myID;
		this.aName = myName;
		this.image = myImage;
		this.description = myDescription;
	}
}
