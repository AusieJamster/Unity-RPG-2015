using UnityEngine;
using System.Collections;

public class CopyMachine {

	public static Item CopyItem(Item source){
		switch(source.itemType){
		case Item.ItemType.Weapon:
			Weapon wep = source as Weapon;
			Weapon w = new Weapon(wep.id, wep.itemName, wep.invImage, wep.image, wep.weight, wep.value, wep.wepType, wep.wepSubType,
			                      wep.damage, wep.fireRate, wep.accuracy, wep.magSize, wep.reloadSpeed, wep.bulletPrefab);
			w.quantity = wep.quantity;
			w.wepType = wep.wepType;
			w.wepSubType = wep.wepSubType;
			return w;
		case Item.ItemType.Armor:
			Armor arm = source as Armor;
			Armor armor = new Armor(arm.id, arm.itemName, arm.invImage, arm.image, arm.weight, arm.value, arm.armType, arm.resistPercent, arm.resistFlat);
			armor.quantity = arm.quantity;
			return armor;
		case Item.ItemType.Aid:
			Aid a = source as Aid;
			Aid aid;
			if(a.aidType == Aid.AidType.Standard){
				aid = new Aid(a.id, a.itemName, a.image, a.weight, a.value, a.healthRestore);
			} else {
				aid = new Aid(a.id, a.itemName, a.image, a.weight, a.value, a.healthRestore, a.strength,
			               a.constitution, a.dexterity, a.intelligence, a.charisma, a.willpower, 
			               a.perception, a.luck, a.duration);
			}
			aid.quantity = a.quantity;
			aid.aidType = a.aidType;
			return aid;
		case Item.ItemType.Misc:
			Misc m = source as Misc;
			Misc misc = new Misc(m.id, m.itemName, m.image, m.weight, m.value);
			misc.quantity = m.quantity;
			return misc;
		case Item.ItemType.Ammo:
			Ammo am = source as Ammo;
			Ammo ammo = new Ammo(am.id, am.itemName, am.image, am.value, am.damagePercent, am.armorReduction);
			ammo.quantity = am.quantity;
			return ammo;
		default:
			Debug.LogError("Copy Failed");
			return new Item();
		}
	}
}