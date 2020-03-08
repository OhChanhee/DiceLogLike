using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class RoomManager : MonoBehaviour
{
    public Tile FloorTile;

    private int ColumnNum = 16;
    private int RowsNum = 8;

    private int RoomNumber;
    private Tile[,] ROOMtileInfo;

    private Tilemap tilemap;
    void Start()
    {
        tilemap = GetComponent<Tilemap>();
        RoomConfig();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void RoomConfig()
    {
        for (int x = 0; x < ColumnNum; x++)
        {
            for (int y = 0; y < RowsNum; y++)
            {
                tilemap.SetTile(tilemap.WorldToCell(new Vector2(x,y)), FloorTile);
            }
        }
    }

 
}
