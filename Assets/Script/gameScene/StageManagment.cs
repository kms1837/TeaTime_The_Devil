using UnityEngine;
using System.Collections;

public class StageManagment : MonoBehaviour {
	public int deadCount;
	// Use this for initialization
	void Start () {
		deadCount = 0;
		updateUi();
	}

	public void updateUi()
	{
		GameObject castleHpMaxNumberObejct = GameObject.Find("castleHpMaxNumber");
		castleHpMaxNumberObejct.transform.guiText.text = gameManagment.Instance.getCastleHpMax().ToString();
		
		GameObject castleHpNumberObejct = GameObject.Find("castleHpNumber");
		castleHpNumberObejct.transform.guiText.text = gameManagment.Instance.getCastleHp().ToString();
	}
	
	// Update is called once per frame
	void Update () {
		if(deadCount >= 10){
			gameManagment.Instance.nextDay();
			gameManagment.Instance.setGold(gameManagment.Instance.getGold() + 30);
			Application.LoadLevel("StoreScene");
			deadCount = 0;
		}
	}
}
