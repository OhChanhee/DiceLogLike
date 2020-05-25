using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public Coordinate RoomCoordinate;
    public Coordinate MapCoordinate;
    void Start()
    {
        SetStartPosition();
        Debug.Log(RoomCoordinate);
    }

    void SetStartPosition()
    {
        gameObject.transform.position = new Vector2(0.5f, 0.7f);
        RoomCoordinate = new Coordinate(11,6);
        MapCoordinate = new Coordinate(0,0);
    }
    void Update()
    {
        
    }
}
