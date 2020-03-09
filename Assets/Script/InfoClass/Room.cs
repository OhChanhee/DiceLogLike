using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    private Coordinate RoomCoordinate;
    private List<Tile> Tilelist = new List<Tile>();

    public void SetTileList(Tile tile)
    {
        Tilelist.Add(tile);
    }
    private void Start()
    {
        
       
    }
}
