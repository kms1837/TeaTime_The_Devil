using UnityEngine;
using System.Collections;

public class fire : MonoBehaviour {
	void Start  () { Invoke("fireEnd", 3.0f); }
	void fireEnd() { Destroy (this.gameObject); }
	void Update () {
	
	}

	void OnTriggerEnter (Collider enemy){
		enemy.SendMessage ("HPzero");
	}
}
