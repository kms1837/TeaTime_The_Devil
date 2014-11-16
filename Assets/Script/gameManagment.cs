using UnityEngine;
using System.Collections;

public class gameManagment : MonoBehaviour {
	public static gameManagment _instance;
	private float castleHp, castleHpMax;
	private int day;
	private int gold;
	
	public static gameManagment Instance
	{
		get
		{
			if (_instance == null)
			{
				GameObject tempObject = new GameObject("gameManagmentObject");
				tempObject.AddComponent<gameManagment>();
				_instance = tempObject.GetComponent<gameManagment>();

				if (_instance == null)
					Debug.LogError("Not Found gameManagment !!");
			}
			return _instance;
		}
	}

	public float getCastleHp()	  {return castleHp;}
	public float getCastleHpMax() {return castleHpMax;}
	public int getDay()			  {return day;}
	public int getGold()		  {return gold;}

	public gameManagment()
	{
		castleHp 	= 100.0f;
		castleHpMax = 100.0f;
		day  = 1;
		gold = 1000;
	}
}