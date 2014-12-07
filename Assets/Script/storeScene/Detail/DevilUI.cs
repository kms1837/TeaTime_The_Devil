using UnityEngine;
using System.Collections;

public class DevilUI : MonoBehaviour {
	
	public void updateUI()
	{
		GameObject dayNumberObejct = GameObject.Find("DayNumber");
		dayNumberObejct.transform.guiText.text = gameManagment.Instance.getDay().ToString();
		
		GameObject goldNumberObejct = GameObject.Find("GoldNumber");
		goldNumberObejct.transform.guiText.text = gameManagment.Instance.getGold().ToString();
	}

	void Start () {
		updateUI();
	}
	
	// Update is called once per frame
	void Update () {
	 
	}
}
