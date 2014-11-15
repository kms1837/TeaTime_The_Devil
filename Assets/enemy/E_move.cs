using UnityEngine;
using System.Collections;

public class E_move : MonoBehaviour {
	
	public float moveSpeed = 5f;
	float E_position;
	
	// Use this for initialization
	void Start () {
		
		
		
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y <= 2.1f) {
						E_position = moveSpeed * Time.deltaTime;
						transform.Translate (E_position, 0, 0);
		}
	}
}
