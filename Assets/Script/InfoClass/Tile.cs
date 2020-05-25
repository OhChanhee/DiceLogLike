using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public Coordinate coordinate;
    public TileType TileType;
    public void SetTileInfo(int x,int y)
    {

        coordinate.x = x;
        coordinate.y = y;
 
    }
    

}
