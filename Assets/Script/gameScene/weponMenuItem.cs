using UnityEngine;
using System.Collections;

public class weponMenuItem : MonoBehaviour {
	public int weponNumber;
	public Color setColor;
	public float positionX, positionY;
	public Texture weponTexture;
	public bool mouseOver;
	public int size;

	// Use this for initialization
	void Start () {
		//mouseOver = false;
	}

	void OnGUI()
	{
		if(weponTexture != null){
			if(mouseOver) GUI.color = setColor;
			//positionY

			GUI.Box(new Rect(positionX, positionY, size, size), weponTexture);
			GUI.DrawTexture(new Rect(positionX, positionY, size, size), weponTexture, ScaleMode.StretchToFill, true);
		}
	}

	// Update is called once per frame
	void Update () {
	}

	void OnMouseUp() {
	}

	void OnMouseOver() {
		//gameObject.renderer.material.color = setColor;
	}

	void OnMouseExit() {
		//gameObject.renderer.material.color = Color.white;
	}

	void OnMouseDown() {
		Debug.Log ("무기넘버:" + weponNumber);
	}
}

/*
 무기의 아이템 하나하나 관리
 무기 선택시 값 전달
 */