using UnityEngine;
using System.Collections;

public class StageManagment : MonoBehaviour {
	public int deadCount;
	// Use this for initialization
	void Start () {
		deadCount = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if(deadCount >= 10){
			gameManagment.Instance.nextDay();
			Application.LoadLevel("StoreScene");
			deadCount = 0;
		}
	}
}
