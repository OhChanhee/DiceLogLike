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
    public bool EnemyTurn;
    public Coordinate RoomCoordinate;//방안에서의 좌표
    public Coordinate MapCoordinate;//맵상의 좌표


    public virtual void Action()
    {
        //몬스터의 패턴을 구현
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
