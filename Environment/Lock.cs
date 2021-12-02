using UnityEngine;
using System.Collections;

public class Lock : MonoBehaviour {
	
	protected LockpickScript.Difficulty diff;
	protected GameManager gm;

	public void StartPick(){
		gm = FindObjectOfType<GameManager>();
		gm.pickWindow.GetComponent<LockpickScript>().StartPick(this.transform, diff);
	}
}
