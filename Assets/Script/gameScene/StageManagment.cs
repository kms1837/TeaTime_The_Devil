using UnityEngine;
using System.Collections;

public class StageManagment : MonoBehaviour {
	bool isFin;
	public Texture2D hpTexture;
	public Texture2D mpTexture;
	public Texture2D backTexture;

	float hpWight;
	float mpWight;

	// Use this for initialization
	void Start () {
		float maxHealth = gameManagment.Instance.getCastleHpMax();
		float curHealth = gameManagment.Instance.getCastleHp();
		float maxMp		= gameManagment.Instance.getMpMax();
		float mp		= gameManagment.Instance.getMp();

		isFin = false;
		hpWight = (Screen.width / 3)  / ( maxHealth / curHealth );
		mpWight = (Screen.width / 3)  / ( maxMp / mp );

		Debug.Log(mp);
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

		GUIStyle hpStyle = new GUIStyle( GUI.skin.box );
		GUIStyle mpStyle = new GUIStyle( GUI.skin.box );
		GUIStyle backStyle = new GUIStyle( GUI.skin.box );

		backStyle.normal.background = backTexture;

		hpStyle.normal.background = hpTexture;

		GUI.skin.box.normal.textColor = Color.black;

		GUI.Box(new Rect( 15 , 10 , (Screen.width / 4) , 50 ) , "", backStyle);
		GUI.Box(new Rect( 15 , 10 , (Screen.width / 4)  / ( maxHealth / curHealth ) , 50 ), curHealth + " / " + maxHealth, hpStyle);

		mpStyle.normal.background = mpTexture;

		GUI.Box(new Rect( 15 , 80 , (Screen.width / 4), 50 ), "", backStyle);
		GUI.Box(new Rect( 15 , 80 , (Screen.width / 4)  / ( maxMp / mp ) , 50 ) , mp + " / " + maxMp, mpStyle);
		
	}
}
