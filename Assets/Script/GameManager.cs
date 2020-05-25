using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    const int MaxLifeNum = 20;

    public int LifeNum=10;  //남은목숨



    public Coordinate Ch_RoomCordinate; // 캐릭터가있는 방의 좌표
   
    private static GameManager instance;
    public static GameManager GetInstance()
    {
        if (!instance)
        {
            instance = new GameManager();
        }

        return instance;
    }

    void Start()
    {
       
    }
    
    

  


}
