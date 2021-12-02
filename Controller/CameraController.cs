using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	float cameraSpeed = 7f;
	Vector2 camMax = new Vector2 (3, 2.5f);
	GameManager gm;

	void Start(){
		gm = FindObjectOfType<GameManager>();
	}

	void FixedUpdate(){
		if(gm.currentState == GameManager.State.Game){
			if(Input.GetKey(KeyCode.Mouse1))
				UpdateCamera ();
			else{
				Vector3 toPlayer = new Vector3(this.transform.position.x, this.transform.position.y, -10);
				Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, toPlayer, 0.1f);
			}
		}
	}

	void UpdateCamera(){
		Vector2 mousePos = new Vector2(Camera.main.ScreenToViewportPoint(Input.mousePosition).x * 2 - 1, Camera.main.ScreenToViewportPoint(Input.mousePosition).y * 2 - 1);
		Vector2 camPos = new Vector2(Camera.main.transform.position.x, Camera.main.transform.position.y);
		
		if(camPos.x - this.transform.position.x > camMax.x && mousePos.x > 0){
			mousePos.x = 1;
		}
		else if (camPos.x - this.transform.position.x < -camMax.x && mousePos.x < 0){
			mousePos.x = -1;
		}
		
		if(camPos.y - this.transform.position.y > camMax.y && mousePos.y > 0){
			mousePos.y = 1;
		}
		else if (camPos.y - this.transform.position.y < -camMax.y && mousePos.y < 0){
			mousePos.y = -1;
		}
		
		Vector3 viewVector = new Vector3 (mousePos.x*cameraSpeed, mousePos.y*cameraSpeed, Camera.main.transform.position.z);
		Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, this.transform.position + viewVector, 0.02f);
	}
}
