using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class RoomSpawner : MonoBehaviour
{
    public GameObject Room;
    public GameObject FloorTile;
    public GameObject WallTile;
    public int OpeningDirection;
    // 0 --> 첫번쨰 방 스포너
    // 1 --> 위쪽 문이 필요함
    // 2 --> 아래쪽 문이 필요함
    // 3 --> 오른쪽 문이 필요함
    // 4 --> 왼쪽 문이 필요함
    private int columns = 21;
    private int rows = 13;

    public List<GameObject[]> RoomInfo = new List<GameObject[]>();
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
                MakeRoom();
            }
            else if (OpeningDirection == 1)
            {
                MakeRoom();
            }
            else if (OpeningDirection == 2)
            {
                MakeRoom();
            }
            else if (OpeningDirection == 3)
            {
                MakeRoom();
            }
            else if (OpeningDirection == 4)
            {
                MakeRoom();
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

    void MakeRoom()
    {
        int rand = Random.Range(0, 16);//문방향 설정 0 상하좌우 1 
        GameObject RoomParent = Instantiate(Room);
        for (int x=0 ; x < columns+1 ; x++)
        {
            for(int y=0 ; y < rows+1; y++)
            {
                if(x==0 || x==columns || y==0 || y==rows)
                {
                    GameObject Wall = Instantiate(WallTile, new Vector2(gameObject.transform.position.x + x, gameObject.transform.position.y + y), WallTile.transform.rotation);
                    Wall.name = "WallTile(" + x + "," + y + ")";
                    Wall.transform.parent = RoomParent.transform;
                }
                else
                {
                    GameObject Floor = Instantiate(FloorTile, new Vector2(gameObject.transform.position.x + x, gameObject.transform.position.y + y), FloorTile.transform.rotation);
                    Floor.name = "FloorTile(" + x + "," + y + ")";
                    Floor.transform.parent = RoomParent.transform;
                }
              
            }
        }
        
    }



}
