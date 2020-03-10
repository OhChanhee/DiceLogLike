using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    public GameObject Room;
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
        Invoke("Spawn", 0.1f);
    }

    void Spawn()
    {
        if(!Spawned)
        {
            if (OpeningDirection == 0)
            {
                InitRoom();
            }
            else if (OpeningDirection == 1)
            {
                InitRoom();
            }
            else if (OpeningDirection == 2)
            {
                InitRoom();
            }
            else if (OpeningDirection == 3)
            {
                InitRoom();
            }
            else if (OpeningDirection == 4)
            {
                InitRoom();
            }
            Spawned = true;
        }
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("SpawnPoint")&&other.GetComponent<RoomSpawner>().Spawned == true)
        {
            Destroy(gameObject);
        }
    }

    void InitRoom()
    {
        int DoorDirection = Random.Range(0, 16);//문방향 설정 0  
        GameObject RoomParent = Instantiate(Room);
        Room RoomOption = RoomParent.GetComponent<Room>();
         
        for (int y=0 ; y < rows+1 ; y++)
        {
            for(int x=0 ; x < columns+1; x++)
            {
                if(x==0 || x==columns || y==0 || y==rows)// Wall 타일을 테두리에 깔아주는 조건문
                {
                    GameObject Wall = Instantiate(WallTile, new Vector2(gameObject.transform.position.x + x, gameObject.transform.position.y + y), WallTile.transform.rotation);
                    Wall.name = "WallTile(" + x + "," + y + ")";
                    Wall.transform.parent = RoomParent.transform;
                    Wall.GetComponent<Tile>().SetTileInfo(x, y);
                    RoomOption.SetTileList(Wall.GetComponent<Tile>());
                }
                else // FloorTile 을 깔아주는 조건문
                {
                    GameObject Floor = Instantiate(FloorTile, new Vector2(gameObject.transform.position.x + x, gameObject.transform.position.y + y), FloorTile.transform.rotation);
                    Floor.name = "FloorTile(" + x + "," + y + ")";
                    Floor.transform.parent = RoomParent.transform;
                    Floor.GetComponent<Tile>().SetTileInfo(x, y);
                    RoomOption.SetTileList(Floor.GetComponent<Tile>());
                }
              
            }
        }
        
    }



}
