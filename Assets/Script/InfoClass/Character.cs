using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public Waepon waepon;
    public Item item;
    private bool isDead = false;
    public bool PlayerTurn = true;  
    public Coordinate RoomCoordinate;//방안에서의 좌표
    public Coordinate MapCoordinate;//맵상의 좌표

    public Map map;

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

    public List<Enemy> SearchInRangeEnemy(int dirNum)//캐릭터 사정거리에 들어오는 적들을 리턴함
    {
        
        Room CurRoom = map.SearchRoom(MapCoordinate);
        List<Enemy> targets = new List<Enemy>();
        for (int i=0 ; i < CurRoom.EnemyList.Count ; i++)
        {
            for(int j=0;j< waepon.range.Count;j++)
            {
                if (CurRoom.EnemyList[i].RoomCoordinate == MapCoordinate + SetDirection(dirNum)[i])
                {
                    targets.Add(CurRoom.EnemyList[i]);
                }
            }         
        }
    
        return new List<Enemy>();
    }

    private List<Coordinate> SetDirection(int dirNum)// 1 = 위쪽 , 2 = 아래쪽 , 3 = 왼쪽 , 4 = 오른쪽 을리턴함
    {
        List<Coordinate> Range = new List<Coordinate>();
        switch(dirNum)
        {
            case 1: for(int i=0;i < waepon.range.Count;i++)
                {
                    Range.Add(waepon.range[i].Reverse());
                }
                break;
            case 2:
                for (int i = 0; i < waepon.range.Count; i++)
                {
                    Range.Add(waepon.range[i].Reverse() * new Coordinate(1,-1));
                }
                break;
            case 3:
                for (int i = 0; i < waepon.range.Count; i++)
                {
                    Range.Add(waepon.range[i] * new Coordinate(-1, 1));
                }
                break;
            case 4:
                for (int i = 0; i < waepon.range.Count; i++)
                {
                    Range.Add(waepon.range[i]);
                }
                break;

        }
        return Range;
    }

    void Update()
    {
        
    }
}
