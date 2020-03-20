using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public int x = 0;
    public int y = 0;
    private List<Tile> Tilelist = new List<Tile>();
    ROOMType RooMType;
    
    

    public GameObject FloorTile;
    public GameObject WallTile;
    public GameObject DoorTile;
    public int OpeningDirection;
    // 0 --> 첫번쨰 방 스포너
    // 1 --> 위쪽 문이 필요함
    // 2 --> 아래쪽 문이 필요함
    // 3 --> 오른쪽 문이 필요함
    // 4 --> 왼쪽 문이 필요함
    private int rows = 13;
    private int columns = 21;

    private bool Spawned = false;
    void Awake()
    {
    
    }
    void Start()
    {
       // Invoke("Spawn", 0.1f);
    }

    void Spawn()
    {
        if (!Spawned)
        {
            if (OpeningDirection == 0)
            {
                TilePlacement();
            }
            else if (OpeningDirection == 1)
            {
                TilePlacement();
            }
            else if (OpeningDirection == 2)
            {
                TilePlacement();
            }
            else if (OpeningDirection == 3)
            {
                TilePlacement();
            }
            else if (OpeningDirection == 4)
            {
                TilePlacement();
            }
            Spawned = true;
        }

    }


    void TilePlacement()
    {
        int DoorDirection = Random.Range(0, 16);//문방향 설정 0  
        
       

        for (int y = 0; y < rows + 1; y++)
        {
            for (int x = 0; x < columns + 1; x++)
            {
                if (x == 0 || x == columns || y == 0 || y == rows)// Wall 타일을 테두리에 깔아주는 조건문
                {
                    GameObject Wall = Instantiate(WallTile, new Vector2(gameObject.transform.position.x + x, gameObject.transform.position.y + y), WallTile.transform.rotation);
                    Wall.name = "WallTile(" + x + "," + y + ")";
                    Wall.transform.parent = this.transform;
                    Wall.GetComponent<Tile>().SetTileInfo(x, y);
                    SetTileList(Wall.GetComponent<Tile>());
                }
                else // FloorTile 을 깔아주는 조건문
                {
                    GameObject Floor = Instantiate(FloorTile, new Vector2(gameObject.transform.position.x + x, gameObject.transform.position.y + y), FloorTile.transform.rotation);
                    Floor.name = "FloorTile(" + x + "," + y + ")";
                    Floor.transform.parent = this.transform;
                    Floor.GetComponent<Tile>().SetTileInfo(x, y);
                    SetTileList(Floor.GetComponent<Tile>());
                }

            }
        }
    }

    public void SetTileList(Tile tile)
    {
        Tilelist.Add(tile);
    }
    public void SetRoomInfo(int x, int y)
    {

        this.x = x;
        this.y = y;

    }

}
