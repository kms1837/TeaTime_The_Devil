using UnityEngine;
using System.Collections;

public class E_drag : MonoBehaviour {

	Vector3 mouse_start = new Vector3 (0, 0, 0);
	Vector3 mouse_end = new Vector3 (0, 0, 0);
	float t = 0f;
	float g = 9.80665f;
	bool heightToDeath = false;

	
	IEnumerator OnMouseDown()
	{
		mouse_start = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		Vector3 scrSpace = Camera.main.WorldToScreenPoint (transform.position);
		Vector3 offset = transform.position - Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, scrSpace.z));
		
		while (Input.GetMouseButton(0))
		{
			Vector3 curScreenSpace = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, scrSpace.z);
			Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenSpace) + offset;
			curPosition = new Vector3(curPosition.x, curPosition.y, 0f);
			transform.position = curPosition;
			t = t + Time.deltaTime;
			yield return null;
		}
		mouse_end = Camera.main.ScreenToWorldPoint (Input.mousePosition);
	}

	void Update(){
		if(transform.position.y > 15){
			heightToDeath = true;
		}
		if (heightToDeath == true && this.transform.position.y < 3.0f) {
			this.SendMessage ("HPzero");
		}
	}

	void OnTriggerEnter (Collider other){
		if (heightToDeath == true) {
			this.SendMessage ("HPzero");
		}
	}
}
