using UnityEngine;
using System.Collections;

public class gameManagment : MonoBehaviour {
	public static gameManagment _instance;
	//static GameObject container = null;

	private float castleHp, castleHpMax;
	private float mp, mpMax;
	private int day;
	private int gold;
	//private int slavePoint;
	
	public static gameManagment Instance
	{
		get
		{
			if (_instance == null)
			{
				GameObject container = new GameObject();
				container.name = typeof(gameManagment).ToString ();
				_instance = container.AddComponent(typeof(gameManagment)) as gameManagment;
				
				DontDestroyOnLoad(container);

				if (_instance == null)
					Debug.LogError("Not Found gameManagment !!");
			}
			return _instance;
		}
	}

	public int slavePoint
	{
		get{
			return slavePoint;
		}

		set{
			slavePoint = value;
		}
	}

	public float getCastleHp()	  { return castleHp; }
	public float getCastleHpMax() { return castleHpMax; }
	public float getMp()	 	  { return mp; }
	public float getMpMax() 	  { return mpMax; }
	public int getDay()			  { return day; }
	public int getGold()		  { return gold; }

	public void nextDay(){day = day+1;}
	public void setCastleHp(float inputHp) 		 { castleHp = inputHp; }
	public void setCastleHpMax(float inputHpMax) { castleHpMax = inputHpMax; }
	public void setMp(float inputMp) 		 	 { mp = inputMp; }
	public void setMpMax(float inputMpMax) 		 { mpMax = inputMpMax; }
	public void setGold(int inputGold) 			 { gold = inputGold; }

	public gameManagment()
	{
		//Screen.SetResolution(Screen.width, Screen.width/16*9, true);
		castleHp 	= 100.0f;
		castleHpMax = 100.0f;
		slavePoint  = 0;
		mp = 100;
		mpMax = 100;
		day  = 1;
		gold = 0;
		Debug.Log("create");
	}
}