using UnityEngine;
using System.Collections;

public class E_drag : MonoBehaviour {

	Vector3 mouse_start = new Vector3 (0, 0, 0);
	Vector3 mouse_end = new Vector3 (0, 0, 0);
	float t = 0f;
	float g = 9.80665f;
	
	IEnumerator OnMouseDown()
	{
		mouse_start = Camera.main.WorldToScreenPoint (Input.mousePosition);
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
		mouse_end = Camera.main.WorldToScreenPoint (Input.mousePosition);
	}

	void Update(){
		if(mouse_start != new Vector3 (0, 0, 0) && mouse_end != new Vector3 (0, 0, 0)){
			float vx, vy, x, y, x2, y2, t2, vx2, vy2;
			x = mouse_end.x - mouse_start.x;
			y = mouse_end.y - mouse_start.y;
			vx = x/t;
			vy = y/t;
			t2 = vy/g;
			x2 = vx*x*t2;
			y2 = vy*y*t2 - 0.5f*g*t2*t2;
			vx2 = x2/t2;
			vy2 = y2/t2;
			/*if(t>0){
				t = t - Time.deltaTime;
				transform.Translate(vx2, vy2, 0);
			}
			else if(transform.position.y!=0) {
				transform.Translate(vx2, 0, 0);
			}*/
		}
	}
}
