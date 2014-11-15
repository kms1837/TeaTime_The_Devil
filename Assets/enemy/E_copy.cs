using UnityEngine;
using System.Collections;

public class E_copy : MonoBehaviour {
	
	int rand;
	int count_time;
	public int E_quantity = 0;
	int count;
	int curE_quant = 0;
	public Vector2 enemyAppearanceFrequency = new Vector2 (0, 0);

	// Use this for initialization
	void Start () {
		count_time = 0;
		count = E_quantity;
	}
	
	// Update is called once per frame
	void Update () {
		if (count_time == 0) {	
			rand = Random.Range ((int)enemyAppearanceFrequency.x, (int)enemyAppearanceFrequency.y);
			count_time = rand;
		} else {
			count_time--; 
			if(count_time==0){
				count--;
				GameObject Enemy = GameObject.FindWithTag("enemyTag");
				GameObject prefEnemy;
				prefEnemy = Instantiate(Enemy, transform.position, Quaternion.identity)as GameObject;
				curE_quant++;
				if(count == 0){
					count_time--;
				}
			}		
		}
		if (count == 0 && curE_quant == 0) {
			//스테이지 클리어
		}
	}
}
