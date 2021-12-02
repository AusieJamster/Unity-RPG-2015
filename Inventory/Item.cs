using UnityEngine;
using System.Collections;

public class Item {
	public enum ItemType{
		Weapon,
		Armor,
		Aid,
		Misc,
		Ammo
	}

	public string itemName;
	public ItemType itemType;
	public Sprite invImage;
	public Sprite image;
	public float weight;
	public float value;
	public float id;
	public int quantity;

	public Item (){
		this.itemName = "";
		this.itemType = ItemType.Misc;
		this.invImage = null;
		this.image = null;
		this.weight = 0;
		this.value = 0;
		this.id = 0;
		this.quantity = 0;
	}
}

public class Weapon : Item {	
	public enum WepType{
		Ranged,
		Melee
	}
	
	public enum WepSubType{
		Melee,
		Grenade,
		AssaultRifle,
		Shotgun,
		Pistol,
		SniperRifle,
		SMGs,
		Special,
		Bow
	}

	public GameObject bulletPrefab;
	public WepType wepType;
	public WepSubType wepSubType;
	public float damage;
	public float fireRate;
	public float accuracy;
	public int magSize;
	public float reloadSpeed;
	public float deteriorationRate;

	public Weapon(float myID, string myName, Sprite myInvImage, Sprite myImage, float myWeight, float myValue, WepType myType, 
	              WepSubType mySubType, float myDamage, float myFireRate, float myAccuracy, int myMagSize, float myReloadSpeed, GameObject myBulletPrefab){
		this.id = myID;
		this.itemType = ItemType.Weapon;
		this.itemName = myName;
		this.invImage = myInvImage;
		this.image = myImage;
		this.weight = myWeight;
		this.value = myValue;
		
		this.wepType = myType;
		this.wepSubType = mySubType;
		this.damage = myDamage;
		this.fireRate = myFireRate;
		this.accuracy = myAccuracy;
		this.magSize = myMagSize;
		this.reloadSpeed = myReloadSpeed;
		this.bulletPrefab = myBulletPrefab;
		this.quantity = 1;
	}
	
	public Weapon(float myID, string myName, Sprite myInvImage, Sprite myImage, float myWeight, float myValue, WepType myType,
	              float myDamage, float myFireRate){
		this.id = myID;
		this.itemType = ItemType.Weapon;
		this.itemName = myName;
		this.invImage = myInvImage;
		this.image = myImage;
		this.weight = myWeight;
		this.value = myValue;
		
		this.wepType = myType;
		this.wepSubType = WepSubType.Melee;
		this.damage = myDamage;
		this.fireRate = myFireRate;
		this.accuracy = 0;
		this.magSize = 1;
		this.deteriorationRate = 0;
		this.reloadSpeed = 0;
		this.bulletPrefab = null;
		this.quantity = 1;
	}
}

public class Armor : Item {

	public enum ArmorType{
		Head,
		Body
	}

	public ArmorType armType;
	public float resistPercent;
	public float resistFlat;

	public Armor(float myID, string myName, Sprite myImageInv, Sprite myImage, float myWeight, float myValue, ArmorType myType, float myPercentResist,
	            float myFlatResist){
		this.id = myID;
		this.itemType = ItemType.Armor;
		this.itemName = myName;
		this.invImage = myImageInv;
		this.image = myImage;
		this.weight = myWeight;
		this.value = myValue;
		
		this.armType = myType;
		this.image = myImage;
		this.resistPercent = myPercentResist;
		this.resistFlat = myFlatResist;
		this.quantity = 1;
	}
}

public class Aid : Item {
	
	public enum AidType{
		Standard,
		Attribute
	}

	public float healthRestore;
	public float duration;
	public AidType aidType;
	
	public float strength;
	public float constitution;
	public float dexterity;
	public float intelligence;
	public float charisma;
	public float willpower;
	public float perception;
	public float luck;

	public Aid(float myID, string myName, Sprite myImage, float myWeight, float myValue, float hlth){
		this.id = myID;
		this.aidType = AidType.Standard;
		this.itemType = ItemType.Aid;
		this.itemName = myName;
		this.invImage = myImage;
		this.weight = myWeight;
		this.value = myValue;
		
		this.healthRestore = hlth;
		this.quantity = 1;
	}

	public Aid(float myID, string myName, Sprite myImage, float myWeight, float myValue, float hlth, float str, float con, 
	            float dex, float intel, float cha, float will, float per, float myLuck, float myDuration){
		this.id = myID;
		this.aidType = AidType.Attribute;
		this.itemType = ItemType.Aid;
		this.itemName = myName;
		this.invImage = myImage;
		this.weight = myWeight;
		this.value = myValue;
		
		this.healthRestore = hlth;
		
		this.strength = str;
		this.constitution = con;
		this.dexterity = dex;
		this.intelligence = intel;
		this.charisma = cha;
		this.willpower = will;
		this.perception = per;
		this.luck = myLuck;
		this.quantity = 1;
	}
}

public class Misc : Item {	
	public Misc(float myID, string myName, Sprite myImage, float myWeight, float myValue){
		this.id = myID;
		this.itemType = ItemType.Misc;
		this.itemName = myName;
		this.invImage = myImage;
		this.weight = myWeight;
		this.value = myValue;
		this.quantity = 1;
	}
}

public class Ammo : Item {
	public float damagePercent;
	public float armorReduction;

	public Ammo(float myID, string myName, Sprite myImage, float myValue, float myDamPercent, float armorReductMulti){
		this.id = myID;
		this.itemType = ItemType.Ammo;
		this.itemName = myName;
		this.invImage = myImage;
		this.weight = 0;
		this.value = myValue;
		this.damagePercent = myDamPercent;
		this.armorReduction = armorReductMulti;

		this.quantity = 1;
	}
}
