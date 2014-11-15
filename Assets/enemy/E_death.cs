using UnityEngine;
using System.Collections;

public class E_death : MonoBehaviour {

	private bool death = false;
	public int hp = 1;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		if (hp == 0) {
						death = true;
				}
	
	}
}
