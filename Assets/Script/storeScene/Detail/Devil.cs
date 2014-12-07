using UnityEngine;
using System.Collections;

public class Devil : MonoBehaviour {

    public int m_nMenuId;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseDown ()
    {
        int nowGold = gameManagment.Instance.getGold();

        switch ( m_nMenuId )
        {
            case 0:
                {
                    Application.LoadLevel( "StoreScene" );
                    break;
                }
            case 1:
                {
                    break;
                }
            case 2:
                {
                    break;
                }
        }

        GameObject storeObejct = GameObject.Find( "MainCamera" );
        DevilUI devilUI = storeObejct.GetComponent<DevilUI>();
        devilUI.updateUI();

    }
}
