using UnityEngine;
using System.Collections;

public class E_death : MonoBehaviour {
	
	public int hp = 1;

	// Use this for initialization
	void Start () {

	}

	void HPzero () {

		hp--;

	}
	
	// Update is called once per frame
	void Update () {

		if (hp == 0) {
			//사망로직
			Destroy (gameObject);
		}
	
	}
}
