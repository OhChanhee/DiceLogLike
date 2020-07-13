using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager
{
    public int StageNum = 1;//스테이지 레벨

    const int MaxLifeNum = 20;//최대목숨
    public int LifeNum=10;  //남은목숨
    public int CoinValue = 0;
    public int KeyValue = 1;
    public int BombValue = 1;
    public int ActionPoint = 0;
    public int DiceCount = 100;

    public Coordinate Ch_RoomCordinate; // 캐릭터가있는 방의 좌표

    private static GameManager instance;  
    public static GameManager GetInstance()
    {
        if (instance == null)
        {
            instance = new GameManager();
        }

        return instance;
    }  

  


}
