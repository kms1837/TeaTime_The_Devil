using UnityEngine;
using System.Collections;

public class storeMenuItem : MonoBehaviour
{
    public int menuNumber;

    // Use this for initialization
    void Start ()
    {

    }

    // Update is called once per frame
    void Update ()
    {

    }

    void OnMouseUp ()
    {
    }

    void OnMouseOver ()
    {
        if ( menuNumber == 0 ) gameObject.renderer.material.color = Color.blue;
        else gameObject.renderer.material.color = Color.red;
    }

    void OnMouseExit ()
    {

        if ( menuNumber == 0 ) gameObject.renderer.material.color = Color.gray;
        else gameObject.renderer.material.color = Color.white;
    }

    void OnMouseDown ()
    {
        int nowGold = gameManagment.Instance.getGold();
        float tempCastleHp = gameManagment.Instance.getCastleHp();
        float tempCastleHpMax = gameManagment.Instance.getCastleHpMax();

        switch ( menuNumber )
        {
            case 0:
                {
                    Application.LoadLevel( "GameScene" );
                    break;
                }
            case 1:
                {
                    Application.LoadLevel( "StoreSceneDetail_d" );
                    break;
                }
            case 2:
                {
                    Application.LoadLevel( "StoreSceneDetail_s" );
                    break;
                }
        }

        GameObject storeObejct = GameObject.Find( "MainCamera" );
        StoreManagment storeManagment = storeObejct.GetComponent<StoreManagment>();
        storeManagment.updateUI();

    }
}
