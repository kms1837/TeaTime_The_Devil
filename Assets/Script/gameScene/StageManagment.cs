using UnityEngine;
using System.Collections;

public class StageManagment : MonoBehaviour {
	bool isFin;
	// Use this for initialization
	void Start () {
		isFin = false;
	}

	public void Finished () {
		isFin = true;
	}
	
	// Update is called once per frame
	void Update () {
		if(isFin){
			gameManagment.Instance.nextDay();
			Application.LoadLevel("StoreScene");
			isFin = false;
		}

		if(gameManagment.Instance.getCastleHp() < 0){
			Application.LoadLevel("GameOverScene");
		}
	}

	void OnGUI()
	{
		float maxHealth = gameManagment.Instance.getCastleHpMax();
		float curHealth = gameManagment.Instance.getCastleHp();
		float maxMp		= gameManagment.Instance.getMpMax();
		float mp		= gameManagment.Instance.getMp();
		
		GUI.Box(new Rect( 15 , 10 , (Screen.width / 3)  / ( maxHealth / curHealth ) , 20 ), "");
		GUI.Box(new Rect( 15 , 10 , (Screen.width / 3) , 20 ) , curHealth + "/" + maxHealth );
		
		GUI.Box(new Rect( 15 , 40 , (Screen.width / 3)  / ( maxMp / mp ) , 20 ) , "" );
		GUI.Box(new Rect( 15 , 40 , (Screen.width / 3), 20 ) , mp + "/" + maxMp);
		
	}
}
