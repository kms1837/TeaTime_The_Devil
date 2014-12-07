using UnityEngine;
using System.Collections;

public class Structure : MonoBehaviour
{
    public int m_nMenuId;

    // Use this for initialization
    void Start ()
    {

    }

    // Update is called once per frame
    void Update ()
    {

    }

    void OnMouseDown ()
    {
        int nowGold = gameManagment.Instance.getGold();
        float tempCastleHp = gameManagment.Instance.getCastleHp();
        float tempCastleHpMax = gameManagment.Instance.getCastleHpMax();

        switch ( m_nMenuId )
        {
            case 0:
                {
                    Application.LoadLevel( "StoreScene" );
                    break;
                }
            case 1:
                {
                    if ( ( nowGold - 10 ) >= 0 && tempCastleHp != tempCastleHpMax )
                    {
                        gameManagment.Instance.setGold( nowGold - 10 );
                        if ( ( tempCastleHp + 30.0f ) >= tempCastleHpMax )
                        {
                            gameManagment.Instance.setCastleHp( tempCastleHpMax );
                        }
                        else
                        {
                            gameManagment.Instance.setCastleHp( tempCastleHp + 30.0f );
                        }
                    }
                    break;
                }
            case 2:
                {
                    if ( ( nowGold - 30 ) >= 0 )
                    {
                        gameManagment.Instance.setGold( nowGold - 30 );
                        gameManagment.Instance.setCastleHpMax( tempCastleHpMax + 20.0f );
                    }
                    break;
                }
        }

        GameObject storeObejct = GameObject.Find( "MainCamera" );
        StoreManagment storeManagment = storeObejct.GetComponent<StoreManagment>();
        storeManagment.updateUI();

    }
}
