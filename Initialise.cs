using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Initialise : MonoBehaviour {

	public List<Item> allItems = new List<Item>();
	public List<ButtonDetails> allAttributes = new List<ButtonDetails>();
	public List<ButtonDetails> allSkills = new List<ButtonDetails>();
	public List<Perk> allPerks = new List<Perk>();

	[SerializeField] Sprite[] weaponImagesInv;
	[SerializeField] Sprite[] armorImagesInv;
	[SerializeField] Sprite[] aidImagesInv;
	[SerializeField] Sprite[] miscImagesInv;
	[SerializeField] Sprite ammoImageInv;

	[SerializeField] Sprite[] weaponImages;
	[SerializeField] Sprite[] armorImages;
	
	[SerializeField] Sprite[] attributeImages;
	[SerializeField] Sprite[] skillImages;
	[SerializeField] Sprite[] perkImages;

	[SerializeField] GameObject[] bulletPrefabs;

	void Start () {
		Items ();
		Attributes();
		Skills();
		Perks();
	}

	void Items(){
		allItems.Add (new Weapon (0.000f, "Bat", null, weaponImages [0], 0, 0, Weapon.WepType.Melee, 20, 1));

		allItems.Add (new Weapon (0.010f, "AK", weaponImagesInv [0], weaponImages [1], 2, 1200, Weapon.WepType.Ranged, Weapon.WepSubType.AssaultRifle, 2, 0.1f, 1, 24, 2, bulletPrefabs [0]));
		allItems.Add (new Weapon (0.011f, "APS 630", weaponImagesInv [1], weaponImages [1], 3, 1200, Weapon.WepType.Ranged, Weapon.WepSubType.AssaultRifle, 3, 0.15f, 1, 12, 2, bulletPrefabs [0]));
		allItems.Add (new Weapon (0.012f, "AMD 75", weaponImagesInv [1], weaponImages [1], 4, 1200, Weapon.WepType.Ranged, Weapon.WepSubType.AssaultRifle, 4, 0.13f, 1, 12, 2.4f, bulletPrefabs [0]));
		allItems.Add (new Weapon (0.013f, "Bennett", weaponImagesInv [1], weaponImages [1], 4, 1500, Weapon.WepType.Ranged, Weapon.WepSubType.AssaultRifle, 3, 0.2f, 1, 14, 2, bulletPrefabs [0]));

		allItems.Add (new Weapon (0.020f, "MegaTech SG7", weaponImagesInv [2], weaponImages [2], 3, 2000, Weapon.WepType.Ranged, Weapon.WepSubType.Shotgun, 5, 0.55f, 3f, 4, 2, bulletPrefabs [0]));
		allItems.Add (new Weapon (0.021f, "Toyko K4A2", weaponImagesInv [2], weaponImages [2], 3, 2100, Weapon.WepType.Ranged, Weapon.WepSubType.Shotgun, 5, 0.5f, 3, 4, 1.5f, bulletPrefabs [0]));
		allItems.Add (new Weapon (0.022f, "Fluroiken", weaponImagesInv [2], weaponImages [2], 3, 1900, Weapon.WepType.Ranged, Weapon.WepSubType.Shotgun, 4, 0.7f, 3.5f, 6, 2, bulletPrefabs [0]));

		allItems.Add (new Weapon (0.030f, "MechTech P23", weaponImagesInv [3], weaponImages [3], 1, 900, Weapon.WepType.Ranged, Weapon.WepSubType.Pistol, 2, 0.3f, 1, 14, 0.4f, bulletPrefabs [0]));
		allItems.Add (new Weapon (0.031f, "Crosshair", weaponImagesInv [3], weaponImages [3], 1, 1000, Weapon.WepType.Ranged, Weapon.WepSubType.Pistol, 3, 0.3f, 0.7f, 14, 0.4f, bulletPrefabs [0]));
		allItems.Add (new Weapon (0.032f, "Deagle", weaponImagesInv [3], weaponImages [3], 1.2f, 1200, Weapon.WepType.Ranged, Weapon.WepSubType.Pistol, 6, 0.6f, 2.5f, 10, 0.4f, bulletPrefabs [0]));
		allItems.Add (new Weapon (0.033f, "G1280", weaponImagesInv [3], weaponImages [3], 1.1f, 800, Weapon.WepType.Ranged, Weapon.WepSubType.Pistol, 2, 0.4f, 1.5f, 12, 0.3f, bulletPrefabs [0]));
		allItems.Add (new Weapon (0.040f, "MechTech SR2", weaponImagesInv [4], weaponImages [4], 4, 2600, Weapon.WepType.Ranged, Weapon.WepSubType.SniperRifle, 25, 2.0f, 0f, 4, 3, bulletPrefabs [1]));

		allItems.Add (new Weapon (0.041f, "MechTech SR4", weaponImagesInv [4], weaponImages [4], 4.5f, 3000, Weapon.WepType.Ranged, Weapon.WepSubType.SniperRifle, 40, 2.0f, 0f, 4, 3.5f, bulletPrefabs [1]));

		allItems.Add (new Weapon (0.050f, "9mm SMG", weaponImagesInv [5], weaponImages [5], 2.5f, 900, Weapon.WepType.Ranged, Weapon.WepSubType.SMGs, 1, 0.05f, 3.5f, 25, 2, bulletPrefabs [0]));
		allItems.Add (new Weapon (0.051f, "10mm SMG", weaponImagesInv [5], weaponImages [5], 3f, 1100, Weapon.WepType.Ranged, Weapon.WepSubType.SMGs, 2, 0.05f, 3.5f, 25, 2, bulletPrefabs [0]));
		allItems.Add (new Weapon (0.052f, "MP85", weaponImagesInv [5], weaponImages [5], 2.5f, 1000, Weapon.WepType.Ranged, Weapon.WepSubType.SMGs, 1.5f, 0.07f, 2.6f, 18, 2, bulletPrefabs [0]));

		allItems.Add (new Weapon (0.060f, "Enchanted Bow", weaponImagesInv [6], weaponImages [6], 0, 4300, Weapon.WepType.Ranged, Weapon.WepSubType.Bow, 12, 0.5f, 1, 1, 1, bulletPrefabs [2]));
		allItems.Add (new Weapon (0.061f, "Lightshiv", weaponImagesInv [7], weaponImages [7], 0, 5000, Weapon.WepType.Melee, 40, 0.4f));
		allItems.Add (new Weapon (0.062f, "Earthrifle", weaponImagesInv [8], weaponImagesInv [8], 0, 6000, Weapon.WepType.Ranged, Weapon.WepSubType.AssaultRifle, 7, 0.2f, 0.7f, 1, 0f, bulletPrefabs [3]));

		allItems.Add (new Weapon (0.070f, "Flamethrower", weaponImagesInv [9], weaponImages [9], 7, 2600, Weapon.WepType.Ranged, Weapon.WepSubType.Special, 5, 0.1f, 3, 200, 3, bulletPrefabs[4]));
		allItems.Add (new Weapon (0.071f, "Grenade Launcher", weaponImagesInv [10], weaponImages [10], 7, 3000, Weapon.WepType.Ranged, Weapon.WepSubType.Special, 40, 1, 3, 2, 1, bulletPrefabs [5]));

		allItems.Add (new Weapon (0.080f, "Smoke Bomb", weaponImagesInv [11], weaponImages [11], 0.2f, 75, Weapon.WepType.Ranged, Weapon.WepSubType.Grenade, 0f, 1, 2, 1, 1, bulletPrefabs [6]));
		allItems.Add (new Weapon (0.081f, "Flash Bang", weaponImagesInv [11], weaponImages [11], 0.2f, 85, Weapon.WepType.Ranged, Weapon.WepSubType.Grenade, 0.5f, 1, 2, 1, 1, bulletPrefabs [6]));
		allItems.Add (new Weapon (0.082f, "Frag Grenade", weaponImagesInv [12], weaponImages [12], 0.2f, 120, Weapon.WepType.Ranged, Weapon.WepSubType.Grenade, 40f, 1, 2, 1, 1, bulletPrefabs [5]));

		allItems.Add (new Weapon (0.090f, "Tomahawk", weaponImagesInv [13], weaponImages [13], 3, 1200, Weapon.WepType.Melee, 40, 0.3f));
		allItems.Add (new Weapon (0.091f, "Police Baton", weaponImagesInv [14], weaponImages [14], 3, 1000, Weapon.WepType.Melee, 30, 0.3f));
		allItems.Add (new Weapon (0.092f, "Baseball Bat", weaponImagesInv [15], weaponImages [15], 3, 900, Weapon.WepType.Melee, 30, 0.34f));

		allItems.Add (new Armor (1.000f, "Base Head", null, armorImages [0], 0, 0, Armor.ArmorType.Head, 0, 0));
		allItems.Add (new Armor (1.001f, "Base Body", null, armorImages [1], 0, 0, Armor.ArmorType.Body, 0, 0));

		allItems.Add (new Armor (1.002f, "Leather Helmet", armorImagesInv [0], armorImages [2], 2, 120, Armor.ArmorType.Head, 4, 0.2f));
		allItems.Add (new Armor (1.003f, "Leather Armor", armorImagesInv [1], armorImages [3], 4, 120, Armor.ArmorType.Body, 4, 0.2f));
		allItems.Add (new Armor (1.004f, "Leather Plated Helmet", armorImagesInv [2], armorImages [4], 3, 240, Armor.ArmorType.Head, 5, 0.5f));
		allItems.Add (new Armor (1.005f, "Leather Plated Armor", armorImagesInv [3], armorImages [5], 7, 240, Armor.ArmorType.Body, 5, 0.5f));
		allItems.Add (new Armor (1.006f, "Soldier Helmet", armorImagesInv [4], armorImages [6], 3, 500, Armor.ArmorType.Head, 6, 1));
		allItems.Add (new Armor (1.007f, "BulletProof Vest", armorImagesInv [5], armorImages [7], 6, 500, Armor.ArmorType.Body, 6, 1));
		allItems.Add (new Armor (1.008f, "Human Remains", armorImagesInv [6], armorImages [8], 2, 150, Armor.ArmorType.Body, 4, 0.2f));

		allItems.Add (new Aid (2.000f, "First Aid", aidImagesInv [0], 0.1f, 120, 30));
		allItems.Add (new Aid (2.001f, "Steroids", aidImagesInv [1], 0.1f, 120, 0, 1, 0, 0, 0, 1, -1, 0, 0, 60));
		allItems.Add (new Aid (2.002f, "Painkillers", aidImagesInv [2], 0.1f, 60, 0, 0, 1, 0, 0, 0, 0, -1, 0, 60));
		allItems.Add (new Aid (2.003f, "Green Tea", aidImagesInv [3], 0.1f, 240, 30, 0, 0, 0, 1, 0, 1, 0, 0, 60));
		allItems.Add (new Aid (2.004f, "Cocaine", aidImagesInv [4], 0.1f, 250, -10, 0, 0, 2, -0.5f, 0.5f, 0.5f, 0, 0, 60));
		allItems.Add (new Aid (2.005f, "Meth", aidImagesInv [5], 0.1f, 350, -20, 0.2f, -0.5f, 3, -1, -1, 1, 0, 0, 60));
		allItems.Add (new Aid (2.006f, "Goblin Foot", aidImagesInv [6], 0.4f, 500, 20, 0, 0.2f, 0.1f, 0.3f, -1, 1, 0, 1, 60));
		allItems.Add (new Aid (2.007f, "Super Injection", aidImagesInv [7], 0.1f, 500, 0, 2, 2, 2, 2, 2, 2, 2, 2, 20));
		allItems.Add (new Aid (2.008f, "Orc Meat", aidImagesInv [8], 0.6f, 100, 30, 2, 0, -1, -2, -0.5f, 0, 0, 0, 30));

		allItems.Add (new Misc (3.000f, "Lockpick", miscImagesInv [0], 0.1f, 0.1f));
		allItems.Add (new Misc (3.001f, "Human Skull", miscImagesInv[1], 0.5f, 2));
		allItems.Add (new Misc (3.002f, "Human Dogtag", miscImagesInv[2], 0, 5));
		allItems.Add (new Misc (3.003f, "Cup", miscImagesInv[3], 0.2f, 2));
		allItems.Add (new Misc (3.004f, "Plate", miscImagesInv[4], 0.2f, 2));

		allItems.Add (new Ammo (4.000f, "Standard Ammo", ammoImageInv, 0.1f, 1, 0));
		allItems.Add (new Ammo (4.001f, "Recycled Ammo", ammoImageInv, 0.1f, 0.9f, 0));
		allItems.Add (new Ammo (4.002f, "Improved Ammo", ammoImageInv, 0.1f, 1.1f, 0));
		allItems.Add (new Ammo (4.003f, "Hollow-Point Ammo", ammoImageInv, 0.1f, 1.2f, -0.1f));
		allItems.Add (new Ammo (4.004f, "Armor-piercing Ammo", ammoImageInv, 0.1f, 0.9f, 0.1f));
	}

	void Attributes(){
		allAttributes.Add (new ButtonDetails (0, "Strength", attributeImages[0], "Helps with Carry Weight and Affects Skills Melee Damage and Defense"));
		allAttributes.Add (new ButtonDetails (1, "Constitution", attributeImages[1], "Affects Skills Hitpoints and Medicine"));
		allAttributes.Add (new ButtonDetails (2, "Dexterity", attributeImages[2], "Helps with Movement Speed and Affects Skills Weapons and Traps"));
		allAttributes.Add (new ButtonDetails (3, "Intelligence", attributeImages[3], "Helps with the Understanding of Languages and Affects the Science Skill"));
		allAttributes.Add (new ButtonDetails (4, "Charisma", attributeImages[4], "Affects the Influence Skill"));
		allAttributes.Add (new ButtonDetails (5, "Willpower", attributeImages[5], "Increases Skillpoints given on Level up and Affects the Magic Weapons Skill"));
		allAttributes.Add (new ButtonDetails (6, "Perception", attributeImages[6], "Increases the Warning Range and Affects Skills Explosives and Handiness"));
		allAttributes.Add (new ButtonDetails (7, "Luck", attributeImages[7], "Increases Chances of Critical Strike, Better Loot and Lowers the Chance of Enemy Ambushes"));
	}

	void Skills(){
		allSkills.Add (new ButtonDetails (0, "Hitpoints", skillImages[0], "Increases Hitpoints Total and makes the player more resist to poisons, illnesses, heat and cold"));
		allSkills.Add (new ButtonDetails (1, "Defense", skillImages[1], "Decreases Damage Taken from most Sources of Damage and Enables use of Advanced Armors"));
		allSkills.Add (new ButtonDetails (2, "Melee Damage", skillImages[2], "Increases Damage of Melee Attacks and Enables use of Advanced Melee Weapons"));
		allSkills.Add (new ButtonDetails (3, "Weapons", skillImages[3], "Inceases damage of Weapons that use Ammo (excluding Special Weaponry) and Enables use of Advanced Weapons"));
		allSkills.Add (new ButtonDetails (4, "Magic Weapons", skillImages[4], "Increases Damage of Magic Weapons and Enables use of Advanced Magic Weapons"));
		allSkills.Add (new ButtonDetails (5, "Explosives", skillImages[5], "Increases Damage of Grenades and Special Weaponry also enables use of Advanced Special Weapons"));
		allSkills.Add (new ButtonDetails (6, "Medicine", skillImages[6], "Enables the Crafting of more Advanced Medicine (Chems with Healing Properties) also Increaes the Amount Medicine Heals you"));
		allSkills.Add (new ButtonDetails (7, "Traps", skillImages[7], "Increases ability to disarm traps and pick locks"));
		allSkills.Add (new ButtonDetails (8, "Handiness", skillImages[8], "Enables the Crafting and Improvibility of Weapons and Armor"));
		allSkills.Add (new ButtonDetails (9, "Science", skillImages[9], "Enables the Crafting of more Advanced Chems also Increases your Ability to hack Databases"));
		allSkills.Add (new ButtonDetails (10, "Influence", skillImages[10], "Turns the Value to in your Favor while Trading and Unlocks Additional Options when Speaking to Others"));
	}

	void Perks(){
		allPerks.Add (new Perk (0, "Batter Up", perkImages[0], "Increases Melee Damage by 20%", new int[] {2}, new int[] {50}));
		allPerks.Add (new Perk (1, "Explosive Expert", perkImages[1], "Increases Explosive Damage by 20%", new int[] {5}, new int[] {50}));
		allPerks.Add (new Perk (2, "War Veteran", perkImages[2], "Increases Weapons Damage by 10%", new int[] {3}, new int[] {50}));
		allPerks.Add (new Perk (3, "Better Health", perkImages[3], "Increases Max Hitpoints by 15%", new int[] {0}, new int[] {50}));
		allPerks.Add (new Perk (4, "Think Skin", perkImages[4], "Increases Damage Resistance by 10%", new int[] {1}, new int[] {50}));
		allPerks.Add (new Perk (5, "Sorcerers Apprentice", perkImages[5], "Increases Damage from Magic Weapons by 10%", new int[] {4}, new int[] {50}));
		allPerks.Add (new Perk (6, "First Aid", perkImages[6], "You Heal 10% More from Medicine", new int[] {6}, new int[] {50}));
		allPerks.Add (new Perk (7, "Improved Picks", perkImages[7], "Lockpicks are twice as hard to break", new int[] {7}, new int[] {50}));
		allPerks.Add (new Perk (8, "Handyman", perkImages[8], "You need only half the resources to improve weapons and armor", new int[] {8}, new int[] {50}));
		allPerks.Add (new Perk (9, "Resourcefulness", perkImages[9], "You need only half the resources to craft chems", new int[] {9}, new int[] {50}));
		allPerks.Add (new Perk (10, "Silver Tongue", perkImages[10], "Your Items are more Valuable when Trading", new int[] {10}, new int[] {50}));

		allPerks.Add (new Perk (11, "Poisonious Swig", perkImages[11], "Melee gain a Poison Effect", new int[] {2}, new int[] {75}));
		allPerks.Add (new Perk (12, "Explosive Overlord", perkImages[12], "Increases Explosive Damage by 30%", new int[] {5}, new int[] {75}));
		allPerks.Add (new Perk (13, "Sharpshooter", perkImages[13], "Increases Weapon Damage by 15%", new int[] {3}, new int[] {75}));
		allPerks.Add (new Perk (14, "In-Perfect Health", perkImages[14], "Increases Max Hitpoints by 20%", new int[] {0}, new int[] {75}));
		allPerks.Add (new Perk (15, "Improved Armor", perkImages[15], "Increases Damage Resistance by 20%", new int[] {1}, new int[] {75}));
		allPerks.Add (new Perk (16, "Warlord Training", perkImages[16], "Magic Weapons Gain Area of Effect", new int[] {4}, new int[] {75}));
		allPerks.Add (new Perk (17, "Powerful Vitamins", perkImages[17], "You heal 20% more from Medicine", new int[] {6}, new int[] {75}));
		allPerks.Add (new Perk (18, "Master Thief", perkImages[18], "You no Longer Require Lockpicks", new int[] {7}, new int[] {75}));
		allPerks.Add (new Perk (19, "Master Craftsmanship", perkImages[19], "You need only half the Resources to Craft Weapons and Armor", new int[] {8}, new int[] {75}));
		allPerks.Add (new Perk (20, "Anon-Hacker", perkImages[20], "You cannot fail hack attempts (unlimited retries)", new int[] {9}, new int[] {75}));
		allPerks.Add (new Perk (21, "Golden Tongue", perkImages[21], "Unlock Additional Speech Options", new int[] {10}, new int[] {75}));
	}

	public Item SearchItem (float myID){
		foreach(Item i in allItems){
			if(i.id.Equals(myID)){
				return i;
			}
		}
		Debug.Log("Item that you are looking for isn't in the initialise inventory list");
		return null;
	}
}
