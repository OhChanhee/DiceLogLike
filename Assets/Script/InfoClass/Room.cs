using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    //좌표
    public Coordinate Roomcoordinate;

    private List<Tile> Tilelist = new List<Tile>();
    ROOMType RooMType; 

    public GameObject TopDoor;
    public GameObject BottomDoor;
    public GameObject LeftDoor;
    public GameObject RightDoor;

    public GameObject RoomTemp; // 방 기본 구조 오브젝트

    public GameObject FloorTile;
    public GameObject WallTile;
    public GameObject DoorTile;

    private Map map; // 맵정보

    private int rows = 12; // 방세로 타일갯수
    private int columns = 22; //방가로 타일갯수

    private bool Spawned = false;

    void Start()
    {
        map = GameObject.Find("Map").GetComponent<Map>();
        ChooseDoorDirection();
    }

    void Update()
    {
        CheckNearCharacter();
    }


    void Spawn()
    {
        if (!Spawned)
        {
            TilePlacement();
            Spawned = true;
        }
    }


    void TilePlacement()
    {
        int DoorDirection = Random.Range(0, 16);//문방향 설정 0  


        for (int y = 0; y < rows; y++)
        {
            for (int x = 0; x < columns; x++)
            {
                // FloorTile 을 깔아주는 조건문            
                GameObject Floor = Instantiate(FloorTile, new Vector2(gameObject.transform.position.x - 10.5f + x, gameObject.transform.position.y - 5.5f + y), FloorTile.transform.rotation);
                Floor.name = "FloorTile(" + x + "," + y + ")";
                Floor.transform.parent = this.transform;
                Floor.GetComponent<Tile>().SetTileInfo(x, y);
                SetTileList(Floor.GetComponent<Tile>());
            }
        }
    }

    public void SetTileList(Tile tile)
    {
        Tilelist.Add(tile);
    }

    public void SetRoomInfo(int x, int y)
    {
        Roomcoordinate = new Coordinate();
        this.Roomcoordinate.x = x;
        this.Roomcoordinate.y = y;

    }

    public void CheckNearCharacter()
    {
        if ((this.Roomcoordinate.x + 1 == GameManager.GetInstance().Ch_RoomCordinate.x ||
            this.Roomcoordinate.x - 1 == GameManager.GetInstance().Ch_RoomCordinate.x ||
            this.Roomcoordinate.x == GameManager.GetInstance().Ch_RoomCordinate.x)
            && (this.Roomcoordinate.y - 1 == GameManager.GetInstance().Ch_RoomCordinate.y ||
            this.Roomcoordinate.y + 1 == GameManager.GetInstance().Ch_RoomCordinate.y ||
            this.Roomcoordinate.y == GameManager.GetInstance().Ch_RoomCordinate.y))
        {
            Invoke("Spawn", 0.1f);
        }
    }

    public void ChooseDoorDirection()
    {

        if (map.IsRoomCoordinate(Roomcoordinate.x + 1, Roomcoordinate.y))
        {
            RightDoor.SetActive(true);
          
        }
        if (map.IsRoomCoordinate(Roomcoordinate.x , Roomcoordinate.y + 1))
        {
            TopDoor.SetActive(true);
          
        }
        if (map.IsRoomCoordinate(Roomcoordinate.x - 1, Roomcoordinate.y ))
        {
            LeftDoor.SetActive(true);
         
        }
        if (map.IsRoomCoordinate(Roomcoordinate.x , Roomcoordinate.y -1 ))
        {
            BottomDoor.SetActive(true);
   
        }
    }
}
