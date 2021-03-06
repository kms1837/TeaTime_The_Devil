﻿using UnityEngine;
using System.Collections;

public class E_copy : MonoBehaviour {
	
	int rand;
	int count_time;
	public int E_quantity = 0;
	int count;
	int curE_quant = 0;
	float AFmin, AFmax;

	// Use this for initialization
	void Start () {
		count_time = 0;
		count = E_quantity;
		AFmin = 200f - (float)(gameManagment.Instance.getDay ())*1.9f;
		AFmax = 400f - (float)(gameManagment.Instance.getDay ())*2f;
	}

	void countMinus() {
		curE_quant--;
	}
	
	// Update is called once per frame
	void Update () {
		if (count_time == 0) {	
			rand = (int)Random.Range (AFmin, AFmax);
			count_time = rand;
		} else {
			count_time--; 
			if(count_time==0){
				count--;
				GameObject Enemy = GameObject.FindWithTag("enemyTag");
				GameObject prefEnemy;
				prefEnemy = Instantiate(Enemy, transform.position, Quaternion.Euler(90, 0, 0))as GameObject;
				//Quaternion.identity
				curE_quant++;
				if(count == 0){
					count_time--;
				}
			}		
		}
		if (count == 0 && curE_quant == 0) {
			GameObject stageObejct = GameObject.Find("MainCamera");
			StageManagment stageManagment = stageObejct.GetComponent<StageManagment>();
			stageManagment.Finished();
		}
	}
}
