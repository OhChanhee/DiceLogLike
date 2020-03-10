using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public int x=0;
    public int y=0;
    public TileType TileType;
    public void SetTileInfo(int x,int y)
    {
       
        this.x = x;
        this.y = y;
 
    }
    

}
