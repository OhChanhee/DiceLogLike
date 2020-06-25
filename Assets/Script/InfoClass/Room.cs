using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    //좌표
    public Coordinate Roomcoordinate;

    public List<GameObject> EnemyList = new List<GameObject>();//현재 룸에있는 적리스트
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
        Invoke("Spawn", 0.3f);
    }

    void Update()
    {
       
    }


    void Spawn()
    {
        if (!Spawned)
        {
            TilePlacement();
            SetObject(); 
            Spawned = true;
        }
    }


    void TilePlacement()
    {
        GameObject Floor;
        for (int y = 0; y < rows; y++)
        {
            for (int x = 0; x < columns; x++)
            {
                // FloorTile 을 깔아주는 조건문            
                Floor = Instantiate(FloorTile, new Vector2(gameObject.transform.position.x - 10.5f + x, gameObject.transform.position.y - 5.5f + y), FloorTile.transform.rotation);
                Floor.name = "FloorTile(" + x + "," + y + ")";
                Floor.transform.parent = this.transform;
                Floor.GetComponent<Tile>().SetTileInfo(x, y);
                SetTileList(Floor.GetComponent<Tile>());
            }
        }
    }
    void SetObject()//방타입에 따라 미리만들어둔 맵오브젝트 프리팹을 불러온다
    {
        GameObject ReadEnemyTemp = Resources.Load("Prefeb/EnemyTemps/EnemyTemp" + Random.Range(1, 6)) as GameObject;
        GameObject EnemyTemp = Instantiate(ReadEnemyTemp, this.transform);
        for (int i = 0; i< EnemyTemp.transform.childCount; i++)
        {
            EnemyTemp.transform.GetChild(i).GetComponent<Enemy>().MapCoordinate = Roomcoordinate;
            EnemyList.Add(EnemyTemp.transform.GetChild(i).gameObject);
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

    public Tile SearchTile(Coordinate coordinate)
    {
        for (int i = 0; i < Tilelist.Count; i++)
        {
            if (Tilelist[i].coordinate.x == coordinate.x && Tilelist[i].coordinate.y == coordinate.y)
            {
                return Tilelist[i];
            }
        }
        return null;
    }

    public void ChooseDoorDirection()
    {

        if (!map.IsRoomCoordinate(Roomcoordinate.x + 1, Roomcoordinate.y))
        {
            RightDoor.SetActive(false);
          
        }
        if (!map.IsRoomCoordinate(Roomcoordinate.x , Roomcoordinate.y + 1))
        {
            TopDoor.SetActive(false);
          
        }
        if (!map.IsRoomCoordinate(Roomcoordinate.x - 1, Roomcoordinate.y ))
        {
            LeftDoor.SetActive(false);
         
        }
        if (!map.IsRoomCoordinate(Roomcoordinate.x , Roomcoordinate.y -1 ))
        {
            BottomDoor.SetActive(false);
   
        }
    }
}
