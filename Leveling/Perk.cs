using UnityEngine;
using System.Collections;

public class Perk {
	public int id;
	public string aName;
	public Sprite image;
	public string description;
	public int[] skillID;
	public int[] skillLevel;
	
	public Perk(int myID, string myName, Sprite myImage, string myDescription, int[] mySkillID, int[] mySkillLevel){
		if(mySkillID.Length != mySkillLevel.Length)
			Debug.LogError("skillID and skillLevel Lengths don't match");

		this.id = myID;
		this.aName = myName;
		this.image = myImage;
		this.description = myDescription;
		this.skillID = mySkillID;
		this.skillLevel = mySkillLevel;
	}
}
