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

	private Texture2D MakeTex( int width, int height, Color col )
	{
		Color[] pix = new Color[width * height];
		for( int i = 0; i < pix.Length; ++i )
		{
			pix[ i ] = col;
		}
		Texture2D result = new Texture2D( width, height );
		result.SetPixels( pix );
		result.Apply();
		return result;
	}

	void OnGUI()
	{
		float maxHealth = gameManagment.Instance.getCastleHpMax();
		float curHealth = gameManagment.Instance.getCastleHp();
		float maxMp		= gameManagment.Instance.getMpMax();
		float mp		= gameManagment.Instance.getMp();

		float hpWight 	 = (Screen.width / 3)  / ( maxHealth / curHealth );
		GUIStyle hpStyle = new GUIStyle( GUI.skin.box ); 
		hpStyle.normal.background = MakeTex( (int)hpWight , 20, Color.red);

		GUI.Box(new Rect( 15 , 10 , (Screen.width / 3)  / ( maxHealth / curHealth ) , 20 ), "", hpStyle);
		GUI.Box(new Rect( 15 , 10 , (Screen.width / 3) , 20 ) , curHealth + " / " + maxHealth );

		float mpWight 	 = (Screen.width / 3)  / ( maxMp / mp );
		GUIStyle mpStyle = new GUIStyle( GUI.skin.box ); 
		mpStyle.normal.background = MakeTex((int)mpWight, 20, Color.blue);

		GUI.Box(new Rect( 15 , 40 , (Screen.width / 3)  / ( maxMp / mp ) , 20 ) , "", mpStyle);
		GUI.Box(new Rect( 15 , 40 , (Screen.width / 3), 20 ) , mp + " / " + maxMp);
		
	}
}
