using UnityEngine;
using System.Collections;

public class StoreManagment : MonoBehaviour {
	
	public void updateUI()
	{
		GameObject dayNumberObejct = GameObject.Find("DayNumber");
		dayNumberObejct.transform.guiText.text = gameManagment.Instance.getDay().ToString();
		
		GameObject goldNumberObejct = GameObject.Find("GoldNumber");
		goldNumberObejct.transform.guiText.text = gameManagment.Instance.getGold().ToString();

		GameObject castleHpMaxNumberObejct = GameObject.Find("castleHpMaxNumber");
		castleHpMaxNumberObejct.transform.guiText.text = gameManagment.Instance.getCastleHpMax().ToString();

		GameObject castleHpNumberObejct = GameObject.Find("castleHpNumber");
		castleHpNumberObejct.transform.guiText.text = gameManagment.Instance.getCastleHp().ToString();
	}

	void Start () {
		updateUI();
	}
	
	// Update is called once per frame
	void Update () {
	 
	}
}
