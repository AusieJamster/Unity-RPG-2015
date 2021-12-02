using UnityEngine;
using System.Collections;

public class AIScript : MonoBehaviour {	
	public enum Aggression{
		Aggressive,
		Neutral,
		Passive
	}
	
	public Aggression aggro;
	public Armor eHead;
	public Armor eBody;
	public Weapon eWeapon;
	public Ammo eAmmo;
	public Transform target;
	public Transform bulletSpawn;
	
	protected float timer = 0;
	protected GameManager gm;
	protected float speed = 70;
	protected float xp = 180;

	protected int currMag;
	protected float reloadTimer = 0;

	public float healthTotal = 100;
	public float health = 100;

	public void StartUp(){
		gm = FindObjectOfType<GameManager>();
		eWeapon = CopyMachine.CopyItem(gm.initialiseScript.SearchItem(0.010f)) as Weapon;
		eHead = CopyMachine.CopyItem(gm.initialiseScript.SearchItem(1.001f)) as Armor;
		eBody = CopyMachine.CopyItem(gm.initialiseScript.SearchItem(1.000f)) as Armor;
		eAmmo = CopyMachine.CopyItem(gm.initialiseScript.SearchItem(4.000f)) as Ammo;

		currMag = eWeapon.magSize;
	}

	void Update(){
		timer += Time.deltaTime;
		reloadTimer += Time.deltaTime;

		if(aggro == Aggression.Aggressive){
			Movement ();

			int mask = ~1 << LayerMask.NameToLayer("Interactable") | 1 << LayerMask.NameToLayer("Player") | 1 << LayerMask.NameToLayer("Ground");

			RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, 12, mask);
			if(hit.collider != null){
				Debug.Log(hit.collider.tag);
				if(hit.collider.tag == "Player"){
					if(eWeapon.wepType == Weapon.WepType.Ranged){				
						PlayerShoot();
					}
					else if (eWeapon.wepType == Weapon.WepType.Melee){
						PlayerMelee();
					}
				}
			}
			if(reloadTimer >= eWeapon.reloadSpeed && currMag <= 0){
				currMag = eWeapon.magSize;
			}
		}
		
		if(health <= 0){
			Destroy(this.gameObject);
			if(target != null){
				if(target.tag == "Player"){
					target.GetComponent<PlayerStats>().GainXP(xp);
				}
			}
		}
	}

	void Movement(){
		Vector2 vecToTarget = target.transform.position - this.transform.position;
		float angle = Mathf.Atan2(vecToTarget.y, vecToTarget.x) * Mathf.Rad2Deg;
		this.transform.rotation = Quaternion.Lerp(this.transform.rotation, Quaternion.AngleAxis(angle-90, Vector3.forward), 0.5f);

		float distanceFromTarget = Mathf.Sqrt(vecToTarget.x*vecToTarget.x + vecToTarget.y*vecToTarget.y);
		if(Mathf.Abs(distanceFromTarget) <= 3)
			this.GetComponent<Rigidbody2D>().AddForce(-this.transform.up * speed);
		else if (Mathf.Abs(distanceFromTarget) >= 6)
			this.GetComponent<Rigidbody2D>().AddForce(this.transform.up * speed);
	}

	void PlayerShoot(){		
		if(timer > eWeapon.fireRate){
			timer = 0;
			if(eAmmo != null && currMag > 0){
				GameObject bullet = eWeapon.bulletPrefab;
				Bullet bulletscript = bullet.GetComponent<Bullet>();
				bulletscript.damage = eWeapon.damage * eAmmo.damagePercent;
				bulletscript.armReduction = eAmmo.armorReduction;
				bulletscript.shooter = this.transform;
				bullet = (GameObject)Instantiate(bullet, bulletSpawn.transform.position, this.transform.rotation);
				bullet.gameObject.GetComponent<Rigidbody2D>().AddForce(bullet.gameObject.transform.up * bullet.GetComponent<Bullet>().speed);
				currMag--;				
				if(currMag <= 0){
					reloadTimer = 0;
				}
			}
		}
	}
	void PlayerMelee(){		
		if(timer > eWeapon.fireRate){
			timer = 0;
		}
	}
}
