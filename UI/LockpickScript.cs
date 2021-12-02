using UnityEngine;
using System.Collections;

public class LockpickScript : MonoBehaviour {
	public enum Difficulty{
		Hard,
		Medium,
		Easy
	}

	private const float MAX_PICK_DAMAGE = 1;

	float giveway = 2;
	float mousePos;
	StartLockPicking script;
	Transform pick;
	Transform doorLock;
	Transform door;
	float result;
	float pickDamage;
	GameManager gm;
	Initialise initial;

	void Start(){
		gm = FindObjectOfType<GameManager>();
		initial = gm.initialiseScript;
		pick = this.transform.GetChild(1);
		doorLock = this.transform.GetChild(0);
	}

	public void StartPick(Transform myDoor, Difficulty d){
		if(pick == null || doorLock == null)
			Start ();
		result = Random.Range(-90, 90);

		door = myDoor;

		RestartPick();

		switch(d){
		case Difficulty.Hard:
			giveway = 1;
			break;
		case Difficulty.Medium:
			giveway = 3;
			break;
		case Difficulty.Easy:
			giveway = 5;
			break;
		default:
			break;
		}
	}

	void Update () {
		if(Input.GetButtonDown("E")){
			Invoke("EndPick", 0.1f);
		}

		if(!Input.GetButton("A"))
			mousePos = Camera.main.ScreenToViewportPoint(Input.mousePosition).x * 2 - 1;

		if(mousePos > 1)
			mousePos = 1;
		else if(mousePos < -1)
			mousePos = -1;

		if(pick.gameObject.activeSelf){
			float rotateBy = (-90 - giveway) + Mathf.Abs(result-mousePos*90);

			float radians = Mathf.Deg2Rad * (mousePos * 90);
			if(pick.rotation.z < 90*Mathf.Deg2Rad && mousePos < 0 || pick.rotation.z > -90*Mathf.Deg2Rad && mousePos > 0)
				pick.rotation = Quaternion.Lerp(pick.rotation, new Quaternion(0, 0, Mathf.Sin(radians/2), Mathf.Cos(radians/2)), 0.3f);

			if(Input.GetButton("A") && rotateBy < 0){
				doorLock.rotation = Quaternion.Lerp(doorLock.rotation, new Quaternion(0, 0, Mathf.Sin(rotateBy * Mathf.Deg2Rad/2), Mathf.Cos(rotateBy * Mathf.Deg2Rad/2)), 0.1f);
			}
			else{
				doorLock.rotation = Quaternion.Lerp(doorLock.rotation, new Quaternion(0, 0, 0, 1), 0.1f);
			}
			if(Input.GetButton("A")){
				pickDamage += 0.01f;
			}
		}
		else
			doorLock.rotation = Quaternion.Lerp(doorLock.rotation, new Quaternion(0, 0, 0, 1), 0.1f);

		if(pickDamage > MAX_PICK_DAMAGE){
			gm.DisplayNotification("You broke a Pick!", Color.cyan);
			pickDamage = 0;
			pick.gameObject.SetActive(false);

			gm.inv.RemoveItem(gm.inv.itemInv[gm.inv.ContainsItem(initial.SearchItem(3.000f))], 1);

			Invoke("RestartPick", 1);
		}
		if(doorLock.rotation.z <= -0.65){
			door.GetComponent<StartLockPicking>().isUnlocked = true;
			EndPick();
		}
	}
	
	void EndPick(){
		gm.currentState = GameManager.State.Game;
		gm.GameState ();
	}

	public void RestartPick(){	
		pick.gameObject.SetActive(true);

		if(gm.inv.ContainsItem(initial.SearchItem(3.000f)) >= 0)
			pick.gameObject.SetActive(true);
		else{
			pick.gameObject.SetActive(false);
			gm.DisplayNotification("You have no picks!", Color.cyan);
		}
	}
}
