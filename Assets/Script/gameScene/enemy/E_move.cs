using UnityEngine;
using System.Collections;

public class E_move : MonoBehaviour {
	
	public float moveSpeed;
	float E_position;
	
	// Use this for initialization
	void Start ()
	{
		moveSpeed = 5f + (gameManagment.Instance.getDay())/2;
	}
	

	// Update is called once per frame
	void Update ()
	{
		//if (transform.position.y <= 2.0f) {
		if (transform.position.y <= 3.0f) {
			E_position = moveSpeed * Time.deltaTime;
			transform.Translate (E_position, 0, 0);
			Vector3 rePosition = new Vector3 (transform.position.x, transform.position.y, 0f);
			transform.position = rePosition;
		}

		//if (transform.position.y <= 2.0f && transform.position.x > 8) {

		/*if (transform.position.y <= 3.0f && transform.position.x > 10) {
			//공격
			transform.Translate (-E_position, 0, 0);
		}*/

		//Debug.Log("y position : " + transform.position.y);
		//Debug.Log("x position : " + transform.position.x);
	}

	void OnCollisionEnter(Collision other)
	{
		if(other.transform.tag == "castle") {
			float castleHp = gameManagment.Instance.getCastleHp();
			gameManagment.Instance.setCastleHp(castleHp-1.0f);

			E_position = E_position - 2;

			transform.Translate (E_position, 0, 0);

			GameObject stageObejct = GameObject.Find("MainCamera");
			StageManagment stageManagment = stageObejct.GetComponent<StageManagment>();
		}

	}
}
