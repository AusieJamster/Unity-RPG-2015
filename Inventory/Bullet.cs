using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	Rigidbody2D rb;
	public float damage;
	public float armReduction;
	public float speed;
	public Transform shooter;

	void Start(){
		rb = this.GetComponent<Rigidbody2D>();
	}

	void Update () {
		if(Mathf.Abs(rb.velocity.x) <= 7 && Mathf.Abs(rb.velocity.y) <= 7){
			Destroy(this.gameObject);
		}
	}

	void OnCollisionEnter2D(Collision2D hit){
		if(hit.gameObject.tag == "NPC"){
			AIScript hitScript = hit.transform.GetComponent<AIScript>();
			if(hitScript.eWeapon == null)
				hitScript.StartUp();
			hitScript.aggro = AIScript.Aggression.Aggressive;
			hitScript.target = shooter;
			float currFlatResist = (hitScript.eBody.resistFlat + hitScript.eHead.resistFlat) - ((hitScript.eBody.resistFlat + hitScript.eHead.resistFlat) * armReduction);
			float percentTotal = damage * (1 - (hitScript.eBody.resistPercent + hitScript.eHead.resistPercent));
			percentTotal = percentTotal < 0 ? 0 : percentTotal;
			hitScript.health -= percentTotal - currFlatResist;
		}
		else if(hit.gameObject.tag == "Player"){
			PlayerController hitScript = hit.transform.GetComponent<PlayerController>();
			float currFlatResist = (hitScript.eBody.resistFlat + hitScript.eHead.resistFlat) - ((hitScript.eBody.resistFlat + hitScript.eHead.resistFlat) * armReduction);
			float percentTotal = damage * (1 - (hitScript.eBody.resistPercent + hitScript.eHead.resistPercent));
			percentTotal = percentTotal < 0 ? 0 : percentTotal;
			hit.transform.GetComponent<PlayerStats>().currentSkills[0] -= percentTotal - currFlatResist;
		}
		Destroy(this.gameObject);
	}
}
