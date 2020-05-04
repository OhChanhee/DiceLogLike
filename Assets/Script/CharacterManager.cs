using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public static CharacterManager instance;
    public static CharacterManager GetInstance()
    {
        if (!instance)
        {
            instance = new CharacterManager();
        }

        return instance;
    }

    void Start()
    {
      //gameObject.transform.position =   
    }
    public delegate int TileDelegate();
    Transform TR;
    public Coordinate Ch_RoomCordinate = new Coordinate(); // 캐릭터가있는 방의 좌표
    

  


}
