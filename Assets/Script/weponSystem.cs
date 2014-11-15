/*
* 무기창 생성, 무기 총 관리
*/

using UnityEngine;
using System.Collections;

public class weponSystem : MonoBehaviour {
	public GameObject arrowPrefab;
	public GameObject firePrefab;
	public GameObject weponMenuItemPrefab;

	private int selectedWepon;
	private bool arrowSwitch, fireSwitch;
	private GameObject[] weponMenuItemObject;
	private Color[] weponColor;

	void arrowCoolingTime(){ arrowSwitch = true; }
	void fireCoolingTime() { fireSwitch  = true; }

	void Start () {
		selectedWepon = 0;
		weponMenuItemObject = new GameObject[4];
		weponColor  = new Color[]{Color.green, Color.red, Color.blue, Color.gray};
		arrowSwitch = true;
		fireSwitch  = true;
		//GameObject testPrefab = (GameObject)Resources.Load("/Prefabs/yourPrefab");
	}

	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			Vector3 originMousePosition = Input.mousePosition;
			originMousePosition.z = 26;
			
			Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(originMousePosition);

			switch(selectedWepon){
				case 1:{
					if(arrowSwitch){
						Invoke("arrowCoolingTime", 1.0f);

						float arrowRotation = (180/Mathf.PI) * Mathf.Atan2 (worldMousePosition.y-transform.position.y, worldMousePosition.x-transform.position.x);
						GameObject weponObject = Instantiate (arrowPrefab, new Vector3 (this.transform.position.x, this.transform.position.y, this.transform.position.z), transform.rotation)as GameObject;
						arrow arrowObject = (arrow)weponObject.GetComponent<arrow>();
						arrowObject.mousePosition = worldMousePosition;
						arrowObject.arrowRotation = arrowRotation;
						
						arrowSwitch = false;
					}
					break;
				}//arrow
				case 2:{
					if(fireSwitch){
						Invoke("fireCoolingTime", 3.0f);

						GameObject weponObject = Instantiate (firePrefab, new Vector3 (worldMousePosition.x, worldMousePosition.y, this.transform.position.z), Quaternion.Euler(-90, 0, 0))as GameObject;

						fireSwitch = false;
					}
					break;
				}//fire
			}
		}
	}

	void OnMouseUp() {
		weponMenuItem getWeponMenuItem;
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;

		for (int i=0; i<weponMenuItemObject.Length; i++) {
			if (Physics.Raycast (ray, out hit)) {
				getWeponMenuItem = (weponMenuItem)weponMenuItemObject [i].GetComponent<weponMenuItem> ();
				if (getWeponMenuItem == hit.transform.GetComponent<weponMenuItem>()) { //weponMenuItemObject [i].gameObject.collider.Raycast (ray, out hit)
					gameObject.renderer.material.color = weponColor[getWeponMenuItem.weponNumber-1];
					selectedWepon = getWeponMenuItem.weponNumber;
					//Debug.Log (getWeponMenuItem.weponNumber);
				}
			}
			Destroy (weponMenuItemObject [i]);
		}
	}

	void OnMouseDown() {
		weponMenuItem setWeponMenuItem;
		weponMenuItemObject[0] = Instantiate (weponMenuItemPrefab, new Vector3 (this.transform.position.x - 6, this.transform.position.y + 2, 6),  Quaternion.Euler(90, 0, 0))as GameObject;
		setWeponMenuItem = weponMenuItemObject[0].GetComponent<weponMenuItem>();
		setWeponMenuItem.weponNumber = 1;
		setWeponMenuItem.setColor = Color.green;

		weponMenuItemObject[1] = Instantiate (weponMenuItemPrefab, new Vector3 (this.transform.position.x - 3, this.transform.position.y + 2, 6), Quaternion.Euler(90, 0, 0))as GameObject;
		setWeponMenuItem = weponMenuItemObject[1].GetComponent<weponMenuItem>();
		setWeponMenuItem.weponNumber = 2;
		setWeponMenuItem.setColor = Color.red;

		weponMenuItemObject[2] = Instantiate (weponMenuItemPrefab, new Vector3 (this.transform.position.x, this.transform.position.y + 2, 6), Quaternion.Euler(90, 0, 0))as GameObject;
		setWeponMenuItem = weponMenuItemObject[2].GetComponent<weponMenuItem>();
		setWeponMenuItem.weponNumber = 3;
		setWeponMenuItem.setColor = Color.blue;

		weponMenuItemObject[3] = Instantiate (weponMenuItemPrefab, new Vector3 (this.transform.position.x + 3, this.transform.position.y + 2, 6), Quaternion.Euler(90, 0, 0))as GameObject;
		setWeponMenuItem = weponMenuItemObject[3].GetComponent<weponMenuItem>();
		setWeponMenuItem.weponNumber = 4;
		setWeponMenuItem.setColor = Color.gray;
	}

}