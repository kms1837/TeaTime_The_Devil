using UnityEngine;
using System.Collections;

public class PrologueScene : MonoBehaviour {
	private int eventNumber;
	private GameObject talkBox;
	private GameObject talk;
	private GameObject talkName;
	private GameObject deviltxt;

	private GameObject char1;
	private GameObject char2;

	private GameObject back;

	public Texture back3;
	public Texture back4;

	private string[] talkString = { "asd", "test" };

	// Use this for initialization
	void Start () {
		eventNumber = 0;
		talkBox  = GameObject.Find("talkBox");
		talk     = GameObject.Find("talk");
		talkName = GameObject.Find("name");

		deviltxt = GameObject.Find("deviltxt");

		char1 = GameObject.Find("char1");
		char2 = GameObject.Find("char2");

		back = GameObject.Find("back3");

		eventNumber = 0;

		talkBoxHide();
		charHide(char1);
		charHide(char2);
	}

	private void changeBack(Texture inputTexture)
	{
		back.renderer.material.mainTexture = inputTexture;
	}

	private void charShow(GameObject inputObject, Texture inputTexture)
	{
		inputObject.renderer.material.color = Color.white;
	}

	private void charHide(GameObject inputObject)
	{
		inputObject.renderer.material.color = Color.clear;
	}

	private void talkBoxHide()
	{
		talkBox.renderer.material.color = Color.clear;
		talk.renderer.material.color = Color.clear;
		talkName.renderer.material.color = Color.clear;
	}
	
	private void setTalk(string inputName, string inputTalk)
	{
		talkName.GetComponent<TextMesh>().text = inputName;
		talk.GetComponent<TextMesh>().text     = inputTalk;
	}
	
	private void talkBoxShow()
	{
		talkBox.renderer.material.color = Color.white;
		talk.renderer.material.color = Color.white;
		talkName.renderer.material.color = Color.white;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)){
			eventNumber++;

			switch(eventNumber){
				case 1:
					deviltxt.renderer.material.color = Color.clear;
					changeBack(back3);
					setTalk("마왕", "흠~ 역시 티타임엔 아일랜드 상공 1km 에서 키운 고산 케모마일이!...");
					charShow(char1, null);
					talkBoxShow();
					break;
				case 2:
					charHide (char1);
					changeBack(back4);
					setTalk("해설", "우글우글우글우글 쿠구구구구구궁");
					break;
				case 3:
					charShow(char1, null);
					setTalk("마왕", "으응? 뭐지?");
					break;
				case 4:
					charHide(char1);
					charShow(char2, null);
					setTalk("왕군군 대장", "마왕성이 코앞이다!! 사악한 마왕을 물리치고 왕국의 평화를 되찾자!!!");
					break;
				case 5:
					charHide(char2);
					setTalk("병사들", "우와아아아아아아아아!!!!");
					break;
				case 6:
					charShow(char1, null);
					setTalk("마왕", "어...? 뭐..뭐야 난 평화주의ㅈ ..");
					break;
				case 7:
					charHide(char1);
					charShow(char2, null);
					setTalk("왕군군 대장", "돌격 앞으로!!");
					break;
				case 8:
					charHide(char2);
					setTalk("병사들", "우와아아아아아아아아!!!!");
					break;
				case 9:
					charShow(char1, null);
					setTalk("마왕", "으악 뭐야 저놈들 차라도 다 마시게 해달라고!!");
					break;
				case 10:
					Application.LoadLevel("StoreScene");
					break;
			}
		}
	}
}
