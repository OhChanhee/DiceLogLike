using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    private Coordinate TileCoordinate = new Coordinate();
    public TileType TileType;
    public void SetTileInfo(int x,int y)
    {
       
        TileCoordinate.x = x;      
        TileCoordinate.y = y;
        Debug.Log(TileCoordinate.x +","+TileCoordinate.y);
    }
    

}
