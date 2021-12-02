using UnityEngine;
using System.Collections;

public class StartLockPicking : Lock {

	public bool isUnlocked = false;
	[SerializeField] LockpickScript.Difficulty d;

	void Start(){
		diff = d;
	}

	public void Open(){
		if(this.transform.rotation.z < 0.7)
			this.transform.rotation = Quaternion.AngleAxis(90, Vector3.forward);
		else if(this.transform.rotation.z > 0)
			this.transform.rotation = Quaternion.AngleAxis(0, Vector3.forward);
	}
}
