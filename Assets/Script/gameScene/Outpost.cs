using UnityEngine;
using System.Collections;

public class Outpost : MonoBehaviour
{
    public float PositionX
    {
        get
        {
            return m_fPositionX;
        }
        set
        {
            m_fPositionX = value;
        }
    }
    public float PositionY
    {
        get
        {
            return m_fPositionY;
        }
        set
        {
            m_fPositionY = value;
        }
    }
    public float PositionZ
    {
        get
        {
            return m_fPositionZ;
        }
        set
        {
            m_fPositionZ = value;
        }
    }
    private float m_fPositionX;
    private float m_fPositionY;
    private float m_fPositionZ;
    private int m_nTickCount;
    public GameObject arrowPrefab;
    // Use this for initialization
    void Start ()
    {
        PositionX = this.transform.position.x;
        PositionY = this.transform.position.y;
        PositionZ = this.transform.position.z;
        m_nTickCount = 0;
    }
    // Update is called once per frame
    void Update ()
    {
        float x = 0;
        float y = 0;
        float z = 0;
        float l = float.PositiveInfinity;

        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag( "enemyTag" );
        foreach ( var item in gameObjects )
        {
            float tx = m_fPositionX - item.transform.position.x;
            float ty = m_fPositionY - item.transform.position.y;
            float tl = tx * tx + ty * ty;
            tl = Mathf.Sqrt( tl );
            if ( tl < l )
            {
                l = tl;
                x = item.transform.position.x;
                y = item.transform.position.y;
                z = item.transform.position.z;
            }
        }
        if ( l < 30 )
        {
            if ( 0 == m_nTickCount )
            {
                m_nTickCount = 150;

                Vector3 worldMousePosition = new Vector3( x , y , z );

                float arrowRotation = ( 180 / Mathf.PI ) * Mathf.Atan2( worldMousePosition.y - transform.position.y , worldMousePosition.x - transform.position.x );
                GameObject weponObject = Instantiate( arrowPrefab , new Vector3( this.transform.position.x , this.transform.position.y , this.transform.position.z ) , transform.rotation ) as GameObject;
                arrow arrowObject = (arrow)weponObject.GetComponent<arrow>();
                arrowObject.mousePosition = worldMousePosition;
                arrowObject.arrowRotation = arrowRotation;
            }
            Debug.Log( true );
        }
        else
        {
            Debug.Log( false );
        }
        if ( 0 < m_nTickCount )
        {
            --m_nTickCount;
        }
    }
}
