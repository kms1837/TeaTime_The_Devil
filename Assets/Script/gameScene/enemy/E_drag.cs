using UnityEngine;
using System.Collections;

public class E_drag : MonoBehaviour {

	Vector3 mouse_start = new Vector3 (0, 0, 0);
	Vector3 mouse_end = new Vector3 (0, 0, 0);
	float t = 0f;
	float g = 9.80665f;
	bool heightToDeath = false;
	public int heavy = 1;

	
	IEnumerator OnMouseDown()
	{
		mouse_start = Input.mousePosition;
		//Debug.Log (mouse_start.x + ", " + mouse_start.y);
		//Debug.Log (Input.mousePosition.x + ", " + Input.mousePosition.y);
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
		mouse_end = Input.mousePosition;
		//Debug.Log (mouse_end.x + ", " + mouse_end.y);
		//Debug.Log (Input.mousePosition.x + ", " + Input.mousePosition.y);

		float mcx = (mouse_end.x - mouse_start.x)*(2/heavy)/t;
		float mcy = (mouse_end.y - mouse_start.y)*(2/heavy)/t;

		Debug.Log (mcx + ", " + mcy);

		this.rigidbody.AddForce (-mcx, mcy, 0);
	}

	void Update(){
		if(transform.position.y > 30){
			heightToDeath = true;
		}
	}

	void OnCollisionEnter (Collision other){
		if (heightToDeath == true) {
			this.SendMessage ("HPzero");
		}
		else if (heightToDeath == false && transform.position.x > 12) {
			Vector3 newPos = new Vector3 (10f, 2.7f, 0f);
			transform.position = newPos;
		}
	}
}
