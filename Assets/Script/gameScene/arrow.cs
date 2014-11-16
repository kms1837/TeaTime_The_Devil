using UnityEngine;
using System.Collections;

public class arrow : MonoBehaviour {
	public Vector3 mousePosition;
	public float arrowRotation;
	private float PositionX, PositionY;

	void Start () {
		PositionX = this.transform.position.x;
		PositionY = this.transform.position.y;
	}

	void Update () {
		if (mousePosition != null) {
			if(PositionX < 24 && PositionX > -24 && PositionY < 24 && PositionY > -24){ //PositionX != mousePosition.x || PositionY != mousePosition.y
				PositionX = PositionX + Mathf.Cos ((Mathf.PI/180)*arrowRotation); //(targetPosition.x-PositionX)/temp1;
				PositionY = PositionY + Mathf.Sin ((Mathf.PI/180)*arrowRotation); //(targetPosition.y-PositionY)/temp1;
				transform.position = new Vector3(PositionX, PositionY, transform.position.z);
			}else{
				Destroy(this.gameObject);
			}
		}
		if (transform.position.y < 0) {
			Destroy(this.gameObject);		
		}
	}

	void OnTriggerEnter (Collider enemy){
		enemy.SendMessage ("HPzero");
	}

}
