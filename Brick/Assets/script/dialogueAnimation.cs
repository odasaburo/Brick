using UnityEngine;
using System.Collections;

public class dialogueAnimation : MonoBehaviour {

	public float x1,y1;
	public int viewState;
	public float speed;
	public bool appearFlag = false;
	public bool disappearFlag = false;
	// Use this for initialization
	void Start () {
		x1 = transform.position.x;
		y1 = transform.position.y;
		switch (viewState) {
		case 0: // center
			transform.position = new Vector3(Screen.width/2,Screen.height/2,0);
			break;
		case 1: // right
			transform.position = new Vector3(Screen.width * 3/2,Screen.height/2,0);
			break;
		case 2: // left
			transform.position = new Vector3(-Screen.width/2,Screen.height/2,0);
			break;
		case 3: // top
			transform.position = new Vector3(Screen.width/2,Screen.height * 3/2,0);
			break;
		case 4: // bottom
			transform.position = new Vector3(Screen.width/2,-Screen.height/2,0);
			break;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (appearFlag) {
			disappearFlag = false;
			speed += 0.1f;
			switch (viewState) {
			case 0: // center
				transform.position = new Vector3 (Screen.width / 2, Screen.height / 2, 0);
				speed = 0;
				appearFlag = false;
				break;
			case 1: // right
				if(transform.position == new Vector3 (Screen.width / 2, Screen.height / 2, 0)){
					viewState = 0;
					appearFlag = false;
					speed = 0;
				}else{
					transform.position = Vector3.Lerp ( new Vector3 (Screen.width * 3 / 2, Screen.height / 2, 0),new Vector3 (Screen.width / 2, Screen.height / 2, 0), speed);
					appearFlag = true;
				}
				break;
			case 2: // left
				if(transform.position == new Vector3 (Screen.width / 2, Screen.height / 2, 0)){
					viewState = 0;
					appearFlag = false;
					speed = 0;
				}else{
					transform.position = Vector3.Lerp ( new Vector3 (-Screen.width / 2, Screen.height / 2, 0), new Vector3 (Screen.width / 2, Screen.height / 2, 0), speed);
					appearFlag = true;
				}
				break;
			case 3: // top
				if(transform.position == new Vector3 (Screen.width / 2, Screen.height / 2, 0)){
					viewState = 0;
					appearFlag = false;
					speed = 0;
				}else{
					transform.position = Vector3.Lerp ( new Vector3 (Screen.width / 2, Screen.height * 3 / 2, 0),new Vector3 (Screen.width / 2, Screen.height / 2, 0), speed);
					appearFlag = true;
				}
				break;
			case 4: // bottom
				if(transform.position == new Vector3 (Screen.width / 2, Screen.height / 2, 0)){
					viewState = 0;
					appearFlag = false;
					speed = 0;
				}else{
					transform.position = Vector3.Lerp ( new Vector3 (Screen.width / 2, -Screen.height / 2, 0),new Vector3 (Screen.width / 2, Screen.height / 2, 0), speed);
					appearFlag = true;
				}
				break;
			}
		}

		if (disappearFlag) {
			appearFlag = false;
			speed += 0.1f;
			switch(viewState){
			case 0:
				viewState = Random.Range (1, 4);
				speed = 0;
				break;
			case 1: // right
				if(transform.position == new Vector3 (Screen.width * 3 / 2, Screen.height / 2, 0)){
					disappearFlag = false;
					speed = 0;
				}else{
					disappearFlag = true;
					transform.position = Vector3.Lerp(new Vector3 (Screen.width / 2, Screen.height / 2, 0),new Vector3 (Screen.width * 3 / 2, Screen.height / 2, 0),speed);
				}
				break;
			case 2: // left
				if(transform.position == new Vector3 (-Screen.width / 2, Screen.height / 2, 0)){
					disappearFlag = false;
					speed = 0;
				}else{
					disappearFlag = true;
					transform.position = Vector3.Lerp(new Vector3 (Screen.width / 2, Screen.height / 2, 0),new Vector3 (-Screen.width / 2, Screen.height / 2, 0),speed);
				}
				break;
			case 3: // top
				if(transform.position == new Vector3 (Screen.width / 2, Screen.height * 3 / 2, 0)){
					disappearFlag = false;
					speed = 0;
				}else{
					disappearFlag = true;
					transform.position = Vector3.Lerp(new Vector3 (Screen.width / 2, Screen.height / 2, 0),new Vector3 (Screen.width / 2, Screen.height * 3 / 2, 0),speed);
				}
				break;
			case 4: // bottom
				if(transform.position == new Vector3 (Screen.width / 2, -Screen.height / 2, 0)){
					disappearFlag = false;
					speed = 0;
				}else{
					disappearFlag = true;
					transform.position = Vector3.Lerp(new Vector3 (Screen.width / 2, Screen.height / 2, 0),new Vector3 (Screen.width / 2, -Screen.height / 2, 0),speed);
				}
				break;
			}
		}
	}

	public void appearDialogue(){
		appearFlag = true;
	}

	public void disappearDialogue(){
		disappearFlag = true;
		viewState = Random.Range (1, 4);
	}
}
