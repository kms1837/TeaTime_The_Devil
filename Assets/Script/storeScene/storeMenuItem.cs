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
		int nowGold 		  = gameManagment.Instance.getGold();
		float tempCastleHp 	  = gameManagment.Instance.getCastleHp();
		float tempCastleHpMax = gameManagment.Instance.getCastleHpMax();

		switch(menuNumber) {
			case 0:{
				Application.LoadLevel("GameScene");
				break;
			}
			case 1:{
				if((nowGold-10) >= 0 && tempCastleHp != tempCastleHpMax) {
					gameManagment.Instance.setGold(nowGold - 10);
					if((tempCastleHp+30.0f) >= tempCastleHpMax){
						gameManagment.Instance.setCastleHp(tempCastleHpMax);
					}else{
						gameManagment.Instance.setCastleHp(tempCastleHp+30.0f);
					}
				}
				break;
			}
			case 2:{
				if((nowGold-30) >= 0){
					gameManagment.Instance.setGold(nowGold - 30);
					gameManagment.Instance.setCastleHpMax(tempCastleHpMax + 20.0f);
				}
				break;
			}
		}

		GameObject storeObejct = GameObject.Find("MainCamera");
		StoreManagment storeManagment = storeObejct.GetComponent<StoreManagment>();
		storeManagment.updateUI();

	}
}
