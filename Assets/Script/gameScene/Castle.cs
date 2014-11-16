using UnityEngine;
using System.Collections;

public class Castle : MonoBehaviour {
	private float _hp, _maxHp;
	
	void Start () {
		_hp		= gameManagment.Instance.getCastleHp();
		_maxHp 	= gameManagment.Instance.getCastleHpMax();
		Debug.Log("castleHP : " + _hp);
	}

	void Update () {
	
	}
}
