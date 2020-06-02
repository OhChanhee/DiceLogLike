using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public Coordinate coordinate;
    public GameObject OnObject;//타일에 위치한 오브젝트 ex)보물상자,소모성아이템,바위 등 
    public TileType TileType;
    public void SetTileInfo(int x,int y)
    {

        coordinate.x = x;
        coordinate.y = y;
 
    }
    

}
