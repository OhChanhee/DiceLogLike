using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public GameObject RoomSpawner;
    public List<Room> Roomlist = new List<Room>();
    private MapCrawler crawler = new MapCrawler(2);
    public int MaxRoomNum;
    public int MinRoomNum;

    private void Start()
    {
        MapCrawling();
    }

    public void SetRoomList(Room room)
    {
        Roomlist.Add(room);
    }

    private Vector2 up = new Vector2(0,16);
    private Vector2 down = new Vector2(0,-16);
    private Vector2 left = new Vector2(-28.6f, 0f);
    private Vector2 right = new Vector2(28.6f, 0f);

    void MapCrawling()
    {
        RoomPlacement();// (0,0) 좌표의 기본방을 만들어주는역활 
        for (int Craw=0 ; Craw < crawler.CrawlerNum ; Craw++ )
        {
            int rand = Random.Range(MinRoomNum, MaxRoomNum + 1);// 방개수 설정
            for (int Count = 0; Count < rand; Count++)
            {
                int RandomDirection = Random.Range(1, 5); // 크롤러가 이동할 방향설정          
                if(RandomDirection == 1) // 만약에 크롤러가 위로이동
                {                 
                    crawler.CrawlerCoordinate.y++;
                    crawler.CrawlerPosition += up;               
                        if (!IsRoomCoordinate(crawler.CrawlerCoordinate))
                        {
                            RoomPlacement();
                        }
                        else
                        {
                            RandomDirection++;
                        }                                                             
                }
                if (RandomDirection == 2)//크롤러가 아래로이동
                {
                    crawler.CrawlerCoordinate.y--;
                    crawler.CrawlerPosition += down;

                        if (!IsRoomCoordinate(crawler.CrawlerCoordinate))
                        {
                            RoomPlacement();
                         }
                        else
                        {
                            RandomDirection++;
                        }                  
                }
                if (RandomDirection == 3)//크롤러가 왼쪽으로이동
                {
                    crawler.CrawlerCoordinate.x--;
                    crawler.CrawlerPosition += left;
                    
                        if (!IsRoomCoordinate(crawler.CrawlerCoordinate))
                        {
                            RoomPlacement();
                         }
                        else
                        {
                            RandomDirection++;                        
                        }                  
                }
                if (RandomDirection == 4)//크롤러가 오른쪽으로이동
                {
                    crawler.CrawlerCoordinate.x++;
                    crawler.CrawlerPosition += right;
                
                        if (!IsRoomCoordinate(crawler.CrawlerCoordinate))
                        {
                            RoomPlacement();    
                        }
                        else
                        {
                            RandomDirection++;
                        }
                }
                if (RandomDirection == 5) // 상하좌우다 빈칸이 없다면 
                {
                    crawler.CrawlerReset();
                    Count--;
                }
            }
        }
    }
    void RoomPlacement()
    {
        GameObject RoomInstance = Instantiate(RoomSpawner,crawler.CrawlerPosition,RoomSpawner.transform.rotation);
        RoomInstance.GetComponent<Room>().SetRoomInfo(crawler.CrawlerCoordinate.x, crawler.CrawlerCoordinate.y);
        RoomInstance.name = "ROOM(" + crawler.CrawlerCoordinate.x + "," + crawler.CrawlerCoordinate.y + ")";
        RoomInstance.transform.parent = this.transform;
        
        SetRoomList(RoomInstance.GetComponent<Room>());
    }

    public bool IsRoomCoordinate(Coordinate coordinate)
    {
        for (int i = 0; i < Roomlist.Count; i++)
        {       
            if (Roomlist[i].Roomcoordinate==coordinate)
            {
                return true;
            }
        }
        return false;
    }
    public bool IsRoomCoordinate(int x, int y)
    {
        for (int i = 0; i < Roomlist.Count; i++)
        {
            if (Roomlist[i].Roomcoordinate.x == x && Roomlist[i].Roomcoordinate.y == y)
            {
                return true;
            }
        }
        return false;
    }

    public Room SearchRoom(int x,int y)
    {
        for (int i = 0; i < Roomlist.Count; i++)
        {
            if (Roomlist[i].Roomcoordinate.x == x && Roomlist[i].Roomcoordinate.y == y)
            {
                return Roomlist[i];
            }
        }
        return null;
    }
    public Room SearchRoom(Coordinate coordinate)
    {
        for (int i = 0; i < Roomlist.Count; i++)
        {
            if (Roomlist[i].Roomcoordinate == coordinate)
            {
                return Roomlist[i];
            }
        }
        return null;
    }

    public void debugMapList()
    {
        for (int i = 0; i < Roomlist.Count;i++)
        {
            Debug.Log("x: "+Roomlist[i].Roomcoordinate.x + "y: "+Roomlist[i].Roomcoordinate.y);
        }
    }
}
