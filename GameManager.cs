using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {
	public enum State {
		Game,
		Inventory,
		Paused,
		Trade,
		NPC,
		Lockpicking,
		Levelup,
		Perk,
		Quantity
	}
	//consts
	private const int DISPLAYLENGTH = 5;

	//Scripts
	public Initialise initialiseScript;
	public InventoryList invTradeListOther;
	public InventoryList invList;
	public InventoryList invTradeList;
	public AttriPerkList levelUpList;
	public PlayerController plyrController;
	public PlayerStats stats;
	public Inventory inv;

	//Notification Stuff
	[SerializeField] Text noteText;
	[SerializeField] Transform notificationPanel;

	//Ingame panel
	[SerializeField] Transform gameInfoPanel;
	private Text interactText;
	private Text healthText;
	private Text ammoText;

	//Windows
	public GameObject invWindow;
	public GameObject npcWindow;
	public GameObject npcBtnWin;
	public GameObject tradeWindow;
	public GameObject pickWindow;
	public GameObject levelWindow;
	public GameObject quantitySlider;

	//AudioSources
	public AudioSource voiceSource;

	//Buttons
	public Button npcBtn;
	public Button tradeBtn;
	public Button invBtn;
	public Button skillPerkBtn;
	public Button submitButton;

	// Notification Stuff
	List<Text> notifications = new List<Text>();
	public State currentState = State.Game;

	void Start(){
		initialiseScript = this.GetComponent<Initialise>();
		interactText = gameInfoPanel.GetChild(0).GetComponent<Text>();
		healthText = gameInfoPanel.GetChild(1).GetComponent<Text>();
		ammoText = gameInfoPanel.GetChild(2).GetComponent<Text>();
	}

	public void InteractDisplay(string s){
		interactText.text = s;
		Color c = interactText.color;
		c.a = 1;
		interactText.color = c;
	}

	public void DisplayNotification(string s, Color c){
		MoveNotificationsDown();
		Text msg = noteText;
		msg.text = s;
		msg.color = c;
		msg.rectTransform.anchoredPosition = new Vector2(160, Screen.height-25);
		msg = Instantiate(msg) as Text;
		msg.transform.SetParent( notificationPanel );
		msg.GetComponent<NotificationText>().y = msg.rectTransform.anchoredPosition.y - 20;
		notifications.Add(msg);
	}

	void Update(){
		if(interactText.color.a > 0){
			interactText.color = new Color (interactText.color.r, interactText.color.g, interactText.color.b, interactText.color.a-0.1f);
		}
		for(int i = 0; i < notifications.Count; i++){
			notifications[i].GetComponent<NotificationText>().timer += Time.deltaTime;
		}
		if(plyrController.eAmmo == null)
			ammoText.text = "Ammo - None Equipt";
		else
			ammoText.text = "Ammo - " + plyrController.currMag + " / " + plyrController.eAmmo.quantity;
		healthText.text = "Health - " + stats.currentSkills[0] + " / " + stats.skills[0];
	}

	void LateUpdate(){
		for(int i = 0; i < notifications.Count; i++){
			NotificationText n = notifications[i].GetComponent<NotificationText>();
			if(n.fadeIn)
				notifications[i].color = new Color(notifications[i].color.r, notifications[i].color.g, notifications[i].color.b, notifications[i].color.a + 0.03f);
			else if(n.timer > DISPLAYLENGTH){
				notifications[i].color = new Color(notifications[i].color.r, notifications[i].color.g, notifications[i].color.b, notifications[i].color.a - 0.01f);
			}
			if(notifications[i].color.a > 1){
				n.fadeIn = false;
			}
			if(n.y < notifications[i].transform.position.y){
				notifications[i].rectTransform.anchoredPosition = Vector2.Lerp(notifications[i].rectTransform.anchoredPosition, new Vector2(160, n.y), 0.04f);
			}
			if(notifications[i].color.a < -1){
				Destroy(notifications[i].gameObject, 2);
				notifications.Remove(notifications[i]);
			}
		}
	}
	
	void MoveNotificationsDown(){
		for(int i = 0; i < notifications.Count; i++){
			notifications[i].GetComponent<NotificationText>().y -= 40;
		}
	}
	
	public void CheckIfPlayer(Transform trans, string s, Color c){
		if(trans.tag == "Player")
			DisplayNotification(s, c);
	}

	public void GameState(){
		bool invWindowBool = false;
		bool npcWindowBool = false;
		bool tradeWindowBool = false;
		bool pickWindowBool = false;
		bool levelWindowBool = false;
		bool quantitySliderBool = false;

		switch(currentState){
		case State.Game:
			break;
		case State.Inventory:
			invWindowBool = true;
			break;
		case State.Levelup:
			levelWindowBool = true;
			break;
		case State.Lockpicking:
			pickWindowBool = true;
			break;
		case State.NPC:
			npcWindowBool = true;
			break;
		case State.Paused:
			break;
		case State.Perk:
			levelWindowBool = true;
			break;
		case State.Quantity:
			quantitySliderBool = true;
			break;
		case State.Trade:
			tradeWindowBool = true;
			break;
		default:
			break;
		}

		invWindow.SetActive(invWindowBool);
		npcWindow.SetActive(npcWindowBool);
		tradeWindow.SetActive(tradeWindowBool);
		pickWindow.SetActive(pickWindowBool);
		levelWindow.SetActive(levelWindowBool);
		quantitySlider.SetActive(quantitySliderBool);
	}
	
	public void SubmitClicked(){
		if(currentState == State.Levelup){
			stats.CalculateNewValues();
		}
		else{
			stats.GainPerk();
		}
	}
}