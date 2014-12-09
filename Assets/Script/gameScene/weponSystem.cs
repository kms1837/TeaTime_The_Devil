/*
* 무기창 생성, 무기 총 관리
*/

using UnityEngine;
using System.Collections;

public class weponSystem : MonoBehaviour {
	public GameObject arrowPrefab;
	public GameObject firePrefab;
	public GameObject weponMenuItemPrefab;

	//public Texture testT;
	public Texture fireT;
	public Texture arrowT;
	public Texture normalT;

	public Texture[] weponTexture;

	private int selectedWepon;
	private bool arrowSwitch, fireSwitch, weponMenuOpen;
	private GameObject[] weponMenuItemObject;
	private Color[] weponColor;

	private int menuItemGap; //menu item gap

	void arrowCoolingTime(){ arrowSwitch = true; }
	void fireCoolingTime() { fireSwitch  = true; }

	void Start () {
		selectedWepon = 0;
		weponMenuItemObject = new GameObject[3];
		weponColor   = new Color[]{Color.green, Color.red, Color.blue, Color.gray, Color.black, Color.green};
		weponTexture = new Texture[]{arrowT, fireT, normalT, normalT, normalT, normalT, normalT, normalT};
		arrowSwitch  = true;
		fireSwitch   = true;
		menuItemGap  = 80;
	}

	bool shotMagic(float inputMp)
	{
		float mp = gameManagment.Instance.getMp();
		if((mp-inputMp) >= 0){
			gameManagment.Instance.setMp(mp-inputMp);
			return true;
		}

		return false;
	}

	void Update () {

		if(weponMenuOpen) {
			weponMenuItem getWeponMenuItem;
			float itemPositionX, itemPositionY;
			int objectSize;

			Vector3 screenMousePosition = Input.mousePosition;

			for (int i=0; i<weponMenuItemObject.Length; i++) {
				getWeponMenuItem = weponMenuItemObject[i].GetComponent<weponMenuItem>();
				itemPositionX 	 = getWeponMenuItem.positionX;
				itemPositionY 	 = Screen.height - getWeponMenuItem.positionY;
				objectSize 		 = getWeponMenuItem.size;
				//스크린 좌표계의 최상단은 스크린 높이를 600이라 하면 ex)(0, 600) 이지만 drawTexture는 최상단이 (0, 0)기준으로 그린다.

				if(	  screenMousePosition.x >= itemPositionX && screenMousePosition.x <= itemPositionX + objectSize
				   && screenMousePosition.y <= itemPositionY && screenMousePosition.y >= itemPositionY - objectSize)
				{
					getWeponMenuItem.mouseOver = true;
				}else{
					getWeponMenuItem.mouseOver = false;
				}
			}
		}

		if (Input.GetMouseButtonDown (0) && !weponMenuOpen) {
			//Vector3 originMousePosition = Input.mousePosition;
			//originMousePosition.z = 26;
			//Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(originMousePosition);

			Vector3 scrPos = Camera.main.WorldToScreenPoint(transform.position);
			Vector3 curScrPos = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, scrPos.z);
			Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(curScrPos);

			switch(selectedWepon){
				case 1:{
					if(arrowSwitch){
						if(shotMagic(1.0f)){
							Invoke("arrowCoolingTime", 1.0f);

							float arrowRotation = (180/Mathf.PI) * Mathf.Atan2 (worldMousePosition.y-transform.position.y, worldMousePosition.x-transform.position.x);
							GameObject weponObject = Instantiate (arrowPrefab, new Vector3 (this.transform.position.x, this.transform.position.y, this.transform.position.z), transform.rotation)as GameObject;
							arrow arrowObject = (arrow)weponObject.GetComponent<arrow>();
							arrowObject.mousePosition = worldMousePosition;
							arrowObject.arrowRotation = arrowRotation;

							gameObject.renderer.material.color = Color.white;
							selectedWepon = 3;	

							arrowSwitch = false;
						}
					}
					break;
				}//arrow
				case 2:{
					if(fireSwitch){
						if(shotMagic(10.0f)){
							Invoke("fireCoolingTime", 3.0f);

							GameObject weponObject = Instantiate (firePrefab, new Vector3 (worldMousePosition.x, worldMousePosition.y, this.transform.position.z), Quaternion.Euler(-90, 0, 0))as GameObject;
							
							gameObject.renderer.material.color = Color.white;
							selectedWepon = 3;

							fireSwitch = false;
						}
					}
					break;
				}//fire
			}
		}
	}

	void OnMouseUp() {

		weponMenuItem getWeponMenuItem;
		float itemPositionX, itemPositionY;
		int objectSize;

		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;

		Vector3 screenMousePosition = Input.mousePosition;

		//Debug.Log(screenMousePosition);

		weponMenuOpen = false;

		for (int i=0; i<weponMenuItemObject.Length; i++) {
			getWeponMenuItem = weponMenuItemObject[i].GetComponent<weponMenuItem>();
			itemPositionX = getWeponMenuItem.positionX;
			itemPositionY = Screen.height - getWeponMenuItem.positionY;
			//스크린 좌표계의 최상단은 스크린 높이를 600이라 하면 ex)(0, 600) 이지만 drawTexture는 최상단이 (0, 0)기준으로 그린다.
			objectSize = getWeponMenuItem.size;

			if(	  screenMousePosition.x >= itemPositionX && screenMousePosition.x <= itemPositionX + objectSize
			   && screenMousePosition.y <= itemPositionY && screenMousePosition.y >= itemPositionY - objectSize)
			{

				gameObject.renderer.material.color = weponColor[getWeponMenuItem.weponNumber-1];
				selectedWepon = getWeponMenuItem.weponNumber;
			}

			Destroy (weponMenuItemObject [i]);
		}
	}

	void OnMouseDown() {

		weponMenuItem setWeponMenuItem;

		float setPositionX, setPositionY;

		Vector3 objectBounds = gameObject.renderer.bounds.size;
		Vector3 objectSize   = Camera.main.WorldToScreenPoint(objectBounds);

		Vector3 screenMousePosition = Input.mousePosition;
		Vector3 screenPosition 		= Camera.main.WorldToScreenPoint(this.transform.position);

		weponMenuOpen = true;

		Debug.Log(objectBounds);
		
		for (int i = 0; i < 3; i++) {          
			float deg = 360 / 3 * i;
			float radian = deg * Mathf.PI/180;
			//+ (objectBounds.x/2)
			// - (objectBounds.y/2)
			setPositionX = (screenPosition.x-25) + menuItemGap * Mathf.Cos(radian);
			setPositionY = (screenPosition.y-25) + menuItemGap * Mathf.Sin(radian);
			//- 30 : z position 보정

			weponMenuItemObject[i] = new GameObject("weponMenuItem" + (i+1));

			setWeponMenuItem = weponMenuItemObject[i].AddComponent<weponMenuItem>();

			setWeponMenuItem.positionX		= setPositionX;
			setWeponMenuItem.positionY		= setPositionY;
			setWeponMenuItem.weponTexture	= weponTexture[i];
			setWeponMenuItem.weponNumber 	= i + 1;
			setWeponMenuItem.setColor 	 	= weponColor[i];
			setWeponMenuItem.size			= 40;
		}
	}

}