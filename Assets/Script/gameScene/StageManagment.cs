using UnityEngine;
using System.Collections;

public class StageManagment : MonoBehaviour {
	bool isFin;
	private Texture2D hpTexture;
	private Texture2D mpTexture;

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
		hpTexture = MakeTex( (int)hpWight , 20, Color.red);

		mpWight = (Screen.width / 3)  / ( maxMp / mp );
		mpTexture = MakeTex((int)mpWight, 20, Color.blue);
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

		GUIStyle hpStyle = new GUIStyle( GUI.skin.box ); 
		GUIStyle mpStyle = new GUIStyle( GUI.skin.box ); 

		GUI.Box(new Rect( 15 , 10 , (Screen.width / 3)  / ( maxHealth / curHealth ) , 30 ), "", hpStyle);
		GUI.Box(new Rect( 15 , 10 , (Screen.width / 3) , 30 ) , curHealth + " / " + maxHealth );

		hpStyle.normal.background = hpTexture;
		mpStyle.normal.background = mpTexture;

		GUI.Box(new Rect( 15 , 50 , (Screen.width / 3)  / ( maxMp / mp ) , 30 ) , "", mpStyle);
		GUI.Box(new Rect( 15 , 50 , (Screen.width / 3), 30 ) , mp + " / " + maxMp);
		
	}
}
