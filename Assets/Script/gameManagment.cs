using UnityEngine;
using System.Collections;

public class gameManagment : MonoBehaviour {
	public static gameManagment _instance;
	static GameObject container = null;

	private float castleHp, castleHpMax;
	private int day;
	private int gold;
	
	public static gameManagment Instance
	{
		get
		{
			if (_instance == null)
			{
				container = new GameObject();
				container.name = typeof(gameManagment).ToString ();
				_instance = container.AddComponent(typeof(gameManagment)) as gameManagment;
				
				DontDestroyOnLoad(container);

				if (_instance == null)
					Debug.LogError("Not Found gameManagment !!");
			}
			return _instance;
		}
	}

	public float getCastleHp()	  { return castleHp; }
	public float getCastleHpMax() { return castleHpMax; }
	public int getDay()			  { return day; }
	public int getGold()		  { return gold; }

	public void nextDay(){day = day+1;}

	public gameManagment()
	{
		castleHp 	= 100.0f;
		castleHpMax = 100.0f;
		day  = 1;
		gold = 1000;
		Debug.Log("create");
	}
}