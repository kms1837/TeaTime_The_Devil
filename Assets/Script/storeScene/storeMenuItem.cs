using UnityEngine;
using System.Collections;

public class storeMenuItem : MonoBehaviour {
	public int menuNumber;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseUp() {
	}
	
	void OnMouseOver() {
		if(menuNumber == 0) gameObject.renderer.material.color = Color.blue;
		else 				gameObject.renderer.material.color = Color.red;
	}
	
	void OnMouseExit() {

		if(menuNumber == 0) gameObject.renderer.material.color = Color.gray;
		else 				gameObject.renderer.material.color = Color.white;
	}
	
	void OnMouseDown() {
		switch(menuNumber) {
			case 0:
				Application.LoadLevel("GameScene");
				break;
			case 1:
				break;
			case 2:
				break;
		}
	}
}
