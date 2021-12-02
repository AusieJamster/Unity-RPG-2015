using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerStats : MonoBehaviour {

	/* 0 - Strength
	 * 1 - Constitution
	 * 2 - Dexterity
	 * 3 - Intelligence
	 * 4 - Charisma
	 * 5 - Willpower
	 * 6 - Perception
	 * 7 - Luck
	 */
	public int[] attributes;
	public float[] currentAttributes;

	/*
	 * 0 - Hitpoints
	 * 1 - Defense
	 * 2 - Melee Damage
	 * 3 - Weapons
	 * 4 - Magic Weapons
	 * 5 - Explosives
	 * 6 - Medicine
	 * 7 - Traps
	 * 8 - Handiness
	 * 9 - Science
	 * 10 - Influence
	 */
	public int[] skills;
	public float[] currentSkills;
	
	public bool[] perks;

	public List<int> selectedSkills = new List<int>();	
	public int selectedPerk = -1;

	public float xp;
	public float needForLevel = 100;

	GameManager gm;
	Initialise initial;

	void Start(){
		gm = FindObjectOfType<GameManager>();
		initial = gm.initialiseScript;
		attributes = new int[initial.allAttributes.Count];
		skills = new int[initial.allSkills.Count];
		currentAttributes = new float[initial.allAttributes.Count];
		currentSkills = new float[initial.allSkills.Count];
		perks = new bool[initial.allPerks.Count];
		
		for(int i = 0; i < attributes.Length; i++){
			currentAttributes[i] = attributes[i];
		}
		
		for(int i = 0; i < skills.Length; i++){
			currentSkills[i] = skills[i];
		}

		for(int i = 0; i < attributes.Length; i++){
			attributes[i] = 5;
		}
	}

	void Update(){

		if(xp >= needForLevel)
			LevelUp();
	}

	void LevelUp(){
		xp = 0;
		needForLevel *= 1.8f;
		gm.currentState = GameManager.State.Levelup;
		gm.GameState ();
		gm.levelUpList.AssignButtons();
	}
	
	public void GainXP(float x){
		xp += x;
		gm.DisplayNotification("You gained " + x + " Experience!", Color.yellow);
	}
	
	public void AddSelectedSkill(int skillID){
		if(selectedSkills.Count < 3)
			selectedSkills.Add(skillID);
	}
	
	public void RemoveSelectedSkill(int skillID){
		if(selectedSkills.Contains(skillID))
			selectedSkills.RemoveAt(selectedSkills.IndexOf(skillID));
	}

	public void CalculateNewValues(){		
		for(int i = 0; i < selectedSkills.Count; i++){
			int result = (int)Random.Range(0, 12) + attributes[7];
			skills[selectedSkills[i]] += result > 12 ? 12 : result;
			skills[selectedSkills[i]] += attributes[5];
			currentSkills[selectedSkills[i]] += result + attributes[5];
			gm.DisplayNotification(result + attributes[5] + " points added to " + initial.allSkills[selectedSkills[i]].aName, Color.green);
		}

		if(gm.stats.selectedSkills.Count == 1){
			gm.currentState = GameManager.State.Perk;
			gm.GameState ();
		}
		else{
			gm.currentState = GameManager.State.Game;
			gm.GameState ();
		}
		
		selectedSkills = new List<int>();
	}

	public void GainPerk(){
		selectedPerk = -1;
		gm.currentState = GameManager.State.Game;
		gm.GameState ();
	}
}