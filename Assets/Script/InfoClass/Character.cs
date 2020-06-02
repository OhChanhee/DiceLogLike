using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public Waepon waepon;
    public Item item;
    private bool isDead = false;
    public bool PlayerTurn;
    public Coordinate RoomCoordinate;//방안에서의 좌표
    public Coordinate MapCoordinate;//맵상의 좌표
    void Start()
    {
        SetStartPosition();
        Debug.Log(RoomCoordinate);
    }

    void SetStartPosition()//기본 좌표와 포지션 세팅
    {
        gameObject.transform.position = new Vector2(0.5f, 0.7f);
        RoomCoordinate = new Coordinate(11,6);
        MapCoordinate = new Coordinate(0,0);
    }
    void Update()
    {
        
    }
}
