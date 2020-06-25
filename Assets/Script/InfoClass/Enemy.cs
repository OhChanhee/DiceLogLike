using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int Life;//목숨
    int Range_x;//x축 공격범위
    int Range_y;//y축 공격범위
    public int MinDamage;//최소데미지
    public int MaxDamage;//최대데미지
    public int ActionPoint;//행동력
    public bool EnemyTurn = false;
    public Coordinate RoomCoordinate;//방안에서의 좌표
    public Coordinate MapCoordinate;//맵상의 좌표
    void Start()
    {
        gameObject.transform.localPosition = new Vector2(-10.5f, -5.3f);
        for (int i = 0; i < RoomCoordinate.x; i++)
        {
            gameObject.transform.localPosition += new Vector3(1f, 0f);
        }
        for (int i = 0; i < RoomCoordinate.y; i++)
        {
            gameObject.transform.localPosition += new Vector3(0f, 1f);
        }
    }

    public virtual void Action()
    {
        //몬스터의 패턴을 구현
        EnemyTurn = false;
    }  

    // Update is called once per frame
    void Update()
    { 
        
    }
}
