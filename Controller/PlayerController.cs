using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour {

	private float playerSpeed = 100f;
	private Rigidbody2D rb;
	private Animator wepAnim;
	private GameManager gm;
	private Initialise initial;
	
	private float timer;
	private bool fire = false;
	public int currMag;
	private float reloadTimer = 0;
	
	private SpriteRenderer weaponSprite;
	private SpriteRenderer bodySprite;
	private SpriteRenderer headSprite;

	public Armor eHead;
	public Armor eBody;
	public Weapon eWeapon;
	public Ammo eAmmo;
	public Transform bulletSpawn;

	void Start(){
		gm = FindObjectOfType<GameManager>();
		initial = gm.initialiseScript;
		rb = this.GetComponent<Rigidbody2D>();
		wepAnim = this.transform.GetChild(2).GetComponent<Animator>();
		weaponSprite = this.transform.GetChild(2).GetComponent<SpriteRenderer>();
		bodySprite = this.transform.GetChild(1).GetComponent<SpriteRenderer>();
		headSprite = this.transform.GetChild(0).GetComponent<SpriteRenderer>();

		CheckIfEquiptmentNull();
	}

	void Update(){
		CheckIfEquiptmentNull();
		timer += Time.deltaTime;

		if(gm.currentState == GameManager.State.Game){
			if(Input.GetButtonDown("Fire1")){
				fire = true;
				if(eWeapon.wepType == Weapon.WepType.Ranged && eAmmo == null){
					gm.DisplayNotification("There is no Ammo equipt", Color.cyan);
				}
			}
			if(Input.GetButtonUp("Fire1")){
				fire = false;
			}	
			CheckInteractable();
		}
		if(Input.GetButtonDown("Tab")){
			if(gm.currentState == GameManager.State.Game){
				gm.currentState = GameManager.State.Inventory;
				gm.GameState ();
				gm.invList.Refresh();
			}
			else if(gm.currentState == GameManager.State.Inventory){
				gm.currentState = GameManager.State.Game;
				gm.GameState ();
			}
		}

		//Reload Stuff
		reloadTimer += Time.deltaTime;
		if(reloadTimer >= eWeapon.reloadSpeed && currMag <= 0){
			currMag = eWeapon.magSize;
		}
	}
	
	void FixedUpdate(){
		if(gm.currentState == GameManager.State.Game){
			PlayerMovement();
			PlayerShooting();
		}
	}
	
	public void EquiptItem(Item i){
		if(!IfItemEquiptRemove(i)){
			if(i.itemType == Item.ItemType.Weapon){
				Weapon temp = i as Weapon;
				gm.DisplayNotification(temp.itemName + " was equipt", Color.yellow);
				eWeapon = temp;
				weaponSprite.sprite = eWeapon.image;
				currMag = eWeapon.magSize;
			}
			else if(i.itemType == Item.ItemType.Armor){
				Armor temp = i as Armor;
				if(temp.armType == Armor.ArmorType.Head){
					gm.DisplayNotification(temp.itemName + " was equipt", Color.yellow);
					eHead = temp;
					headSprite.sprite = eHead.image;
				}
				else{
					gm.DisplayNotification(temp.itemName + " was equipt", Color.yellow);
					eBody = temp;
					bodySprite.sprite = eBody.image;
				}
			}
			else if(i.itemType == Item.ItemType.Ammo){
				Ammo temp = i as Ammo;
				gm.DisplayNotification(temp.itemName + " was equipt", Color.yellow);
				eAmmo = temp;
			}
		}
	}

	void CheckIfEquiptmentNull(){
		if(eWeapon == null){
			eWeapon = initial.SearchItem(0) as Weapon;
			weaponSprite.sprite = eWeapon.image;
			currMag = eWeapon.magSize;
		}
		if(eHead == null){
			eHead = initial.SearchItem(1) as Armor;
			headSprite.sprite = eHead.image;
		}
		if(eBody == null){
			eBody = initial.SearchItem(1.001f) as Armor;
			bodySprite.sprite = eBody.image;
		}
	}

	//If the item is equipt it removes it	
	bool IfItemEquiptRemove(Item i){		
		if(i.id == eWeapon.id){
			eWeapon = initial.SearchItem(0) as Weapon;
			weaponSprite.sprite = eWeapon.image;
			currMag = eWeapon.magSize;
			gm.DisplayNotification(i.itemName + " was unequipt", Color.yellow);
			return true;
		}
		else if(i.id == eHead.id){
			eHead = initial.SearchItem(1) as Armor;
			headSprite.sprite = eHead.image;
			gm.DisplayNotification(i.itemName + " was unequipt", Color.yellow);
			return true;
		}
		else if(i.id == eBody.id){
			eBody = initial.SearchItem(1.001f) as Armor;
			bodySprite.sprite = eBody.image;
			gm.DisplayNotification(i.itemName + " was unequipt", Color.yellow);
			return true;
		}
		if(eAmmo != null && i.id == eAmmo.id){
			eAmmo = null;
			gm.DisplayNotification(i.itemName + " was unequipt", Color.yellow);
			return true;
		}
		return false;
	}
	
	void CheckInteractable(){
		int mask = 1 << LayerMask.NameToLayer("Interactable");
		RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, 1, mask);
		if(hit.collider != null){
			if(hit.transform.tag == "Chest"){
				gm.InteractDisplay("Press E to Search Chest");
				if(Input.GetButtonDown("E")){
					gm.currentState = GameManager.State.Trade;
					hit.transform.GetComponent<ChestScript>().InitaliseTrade();
				}
			}
			else if(hit.transform.tag == "NPC"){
				gm.InteractDisplay("Press E to Talk to " + hit.transform.name);
				if(Input.GetButtonDown("E")){
					gm.currentState = GameManager.State.NPC;
					hit.transform.GetComponent<TestCharacter>().InitaliseTalk();
				}
			}
			else if(hit.transform.tag == "Door"){
				gm.InteractDisplay("Press E to Open Door");
				if(Input.GetButtonDown("E") && !hit.transform.GetComponent<StartLockPicking>().isUnlocked){
					gm.currentState = GameManager.State.Lockpicking;
					gm.GameState();
					hit.transform.GetComponent<StartLockPicking>().StartPick();
				}
				else if (Input.GetButtonDown("E") && hit.transform.GetComponent<StartLockPicking>().isUnlocked) {
					hit.transform.GetComponent<StartLockPicking>().Open();
				}
			}
		}
	}
	
	void PlayerMovement(){
		Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		Quaternion rot = Quaternion.LookRotation(transform.position - mousePosition, Vector3.forward);
		
		transform.rotation = rot;
		transform.eulerAngles = new Vector3 (0, 0, transform.eulerAngles.z);
		rb.angularVelocity = 0;
		float ver = Input.GetAxis ("Vertical");
		float hor = Input.GetAxis ("Horizontal");
		rb.AddForce(Vector2.up * playerSpeed * ver);
		rb.AddForce(Vector2.right * playerSpeed * hor);		
	}
	
	void PlayerShooting(){
		if(timer > eWeapon.fireRate && fire){
			timer = 0;
			
			if(eWeapon.wepType == Weapon.WepType.Ranged && currMag > 0){
				if(eAmmo != null){
					GameObject bullet = eWeapon.bulletPrefab;
					Bullet bulletscript = bullet.GetComponent<Bullet>();
					bulletscript.damage = eWeapon.damage * eAmmo.damagePercent;
					bulletscript.armReduction = eAmmo.armorReduction;
					bulletscript.shooter = this.transform;
					bullet = (GameObject)Instantiate(bullet, bulletSpawn.transform.position, this.transform.rotation);
					bullet.gameObject.GetComponent<Rigidbody2D>().AddForce(bullet.gameObject.transform.up * bullet.GetComponent<Bullet>().speed);
					currMag--;
					if(currMag <= 0){
						gm.DisplayNotification("Reloading!", Color.yellow);
						reloadTimer = 0;
					}
					if(gm.inv.FiredAmmo(eAmmo) <= 0){
						gm.DisplayNotification("You ran out of " + eAmmo.itemName, Color.cyan);
						IfItemEquiptRemove(eAmmo);
					}
				}
			}
			else if(eWeapon.wepType == Weapon.WepType.Melee){
				wepAnim.SetTrigger("Melee");
				int mask = 1 << LayerMask.NameToLayer("Interactable");
				RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, 1.5f, mask);
				if(hit.collider != null){
					if(hit.transform.tag == "NPC"){
						AIScript hitScript = hit.transform.GetComponent<AIScript>();
						if(hitScript.eWeapon == null)
							hitScript.StartUp();
						hitScript.aggro = AIScript.Aggression.Aggressive;
						hitScript.target = this.transform;
						float currFlatResist = hitScript.eBody.resistFlat + hitScript.eHead.resistFlat;
						float percentTotal = eWeapon.damage * (1 - (hitScript.eBody.resistPercent + hitScript.eHead.resistPercent));
						percentTotal = percentTotal < 0 ? 0 : percentTotal;
						hitScript.health -= percentTotal - currFlatResist;
					}
				}
			}
		}
	}
}