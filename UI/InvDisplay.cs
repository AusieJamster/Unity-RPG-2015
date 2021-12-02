using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InvDisplay : MonoBehaviour {
	[SerializeField] Slider mySlider;
	private Text itemNameText;
	private Image itemImage;
	private Text itemDetails;
	[SerializeField] Sprite blankImage;
	GameManager gm;

	void Start(){
		gm = FindObjectOfType<GameManager>();
		itemNameText = this.transform.GetChild(0).GetComponent<Text>();
		itemImage = this.transform.GetChild(1).GetComponent<Image>();
		itemDetails = this.transform.GetChild(2).GetComponent<Text>();
	}

	public void Display(Item temp){
		switch(temp.itemType){
		case Item.ItemType.Weapon:
			Weapon w = temp as Weapon;
			itemNameText.text = w.itemName;
			itemImage.sprite = w.invImage;
			itemDetails.text = "Weight: " + w.weight + "\nValue: " + w.value
				+ "\nDamage: " + w.damage + "\nAccuracy: " + w.accuracy
				+ "\nMagazine Size: " + w.magSize+ "\nRate of Fire: " + w.fireRate + "\nReload Speed: " + w.reloadSpeed
					+ "\nType: " + w.wepType + "\nSub-Type: " + w.wepSubType;
			break;
		case Item.ItemType.Armor:
			Armor arm = temp as Armor;
			itemNameText.text = arm.itemName;
			itemImage.sprite = arm.invImage;
			itemDetails.text = "Weight: " + arm.weight + "\nValue: " + arm.value
				+ "\nType: " + arm.armType + "\nPrecentage Resist: " + arm.resistPercent + "\nFlat Resist: " + arm.resistFlat;
			break;
		case Item.ItemType.Aid:
			Aid aid = temp as Aid;
			itemNameText.text = aid.itemName;
			itemImage.sprite = aid.invImage;
			itemDetails.text = "Weight: " + aid.weight + "\nValue: " + aid.value + CreateAidString(aid);
			break;
		case Item.ItemType.Misc:
			Misc misc = temp as Misc;
			itemNameText.text = misc.itemName;
			itemImage.sprite = misc.invImage;
			itemDetails.text = "Weight: " + misc.weight + "\nValue: " + misc.value;
			break;
		case Item.ItemType.Ammo:
			Ammo ammo = temp as Ammo;
			itemNameText.text = ammo.itemName;
			itemImage.sprite = ammo.invImage;
			itemDetails.text = "Value: " + ammo.value + "\nDamage Modifier: " + ammo.damagePercent + 
				"\nArmor Reduction Modifier: " + ammo.armorReduction;
			break;
		default:
			break;
		}
		if(itemImage.sprite == null){
			itemImage.sprite = blankImage;
		}
	}
	
	public void Display(ButtonDetails temp){
		itemNameText.text = temp.aName;
		itemImage.sprite = temp.image;
		itemDetails.text = temp.description;
	}
	
	public void Display(Perk temp){
		itemNameText.text = temp.aName;
		itemImage.sprite = temp.image;
		itemDetails.text = PerkDiscriptionString(temp) + temp.description;
	}

	string PerkDiscriptionString(Perk p){
		string s = "Skills Needed\n";
		for(int i = 0; i < p.skillID.Length; i++){
			s += gm.initialiseScript.allSkills[p.skillID[i]].aName + " - " + p.skillLevel[i] + "\t";
		}
		return s += "\n";
	}

	string CreateAidString(Item temp){
		string myString = "\n";
		Aid i = temp as Aid;
		if(i.healthRestore != 0)
			myString += "Health Restore: " + i.healthRestore + "\n";
		if(i.duration != 0)
			myString += "Aid Duration: " + i.duration + "\n";

		if(i.strength != 0)
			myString += "Strength: " + i.strength + "\n";
		if(i.constitution != 0)
			myString += "Constitution: " + i.constitution + "\n";
		if(i.dexterity != 0)
			myString += "Dexterity: " + i.dexterity + "\n";
		if(i.intelligence != 0)
			myString += "Intelligence: " + i.intelligence + "\n";
		if(i.charisma != 0)
			myString += "Charisma: " + i.charisma + "\n";
		if(i.willpower != 0)
			myString += "Willpower: " + i.willpower + "\n";
		if(i.perception != 0)
			myString += "Perception: " + i.perception + "\n";
		if(i.luck != 0)
			myString += "Luck: " + i.luck + "\n";

		return myString;
	}
	
	public void Clear(){
		itemNameText.text = "";
		itemImage.sprite = null;
		itemDetails.text = "";
	}
}
