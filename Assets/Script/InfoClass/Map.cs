using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public GameObject RoomSpawner;
    public List<Room> Roomlist = new List<Room>();
    private GameObject RoomInstance;
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

    private Vector2 up = new Vector2(0,13);
    private Vector2 down = new Vector2(0,-13);
    private Vector2 left = new Vector2(-21, 0f);
    private Vector2 right = new Vector2(21, 0f);

    void MapCrawling()
    {
        RoomPlacement();// (0,0) 좌표의 기본방을 만들어주는역활 
        for (int Craw=0 ; Craw < crawler.CrawlerNum ; Craw++ )
        {
            int rand = Random.Range(MinRoomNum, MaxRoomNum + 1);// 방개수 설정
            for(int Count = 0; Count < rand; Count++)
            {
                int RandomDirection = Random.Range(1, 5); // 크롤러가 이동할 방향설정
                if(RandomDirection == 1) // 만약에 크롤러가 위로이동
                {                 
                    crawler.CrawlerCoordinate.y++;
                    crawler.CrawlerPosition += up;
                    for (int i = 0; i<Roomlist.Count; i++)
                    {
                        if (IsRoomCoordinate(crawler.CrawlerCoordinate))
                        {
                            Debug.Log("ㅇㅇ");
                            RoomPlacement();
                        }
                        else
                        {
                            Debug.Log("dd");
                            RandomDirection++;
                            break;
                        }                                          
                    }
                    if(Roomlist.Count == 0)
                    {
                        RoomPlacement();
                    }

                }
                else if (RandomDirection == 2)//크롤러가 아래로이동
                {
                    crawler.CrawlerCoordinate.y--;
                    crawler.CrawlerPosition += down;
                    for (int i = 0; i < Roomlist.Count; i++)
                    {
                        if (IsRoomCoordinate(crawler.CrawlerCoordinate))
                        {
                            Debug.Log("ㅇㅇ");
                            RoomPlacement();
                        }
                        else
                        {
                            Debug.Log("dd");
                            RandomDirection++;
                            break;
                        }

                    }
                    if (Roomlist.Count == 0)
                    {
                        RoomPlacement();
                    }
                }
                else if (RandomDirection == 3)//크롤러가 왼쪽으로이동
                {
                    crawler.CrawlerCoordinate.x--;
                    crawler.CrawlerPosition += left;
                    for (int i = 0; i < Roomlist.Count; i++)
                    {
                        if (IsRoomCoordinate(crawler.CrawlerCoordinate))
                        {
                            Debug.Log("ㅇㅇ");
                            RoomPlacement();
                        }
                        else
                        {
                            Debug.Log("dd");
                            RandomDirection++;
                            break;
                        }

                    }
                    if (Roomlist.Count == 0)
                    {
                        RoomPlacement();
                    }
                }
                else if (RandomDirection == 4)//크롤러가 오른쪽으로이동
                {
                    crawler.CrawlerCoordinate.x++;
                    crawler.CrawlerPosition += right;
                    for (int i = 0; i < Roomlist.Count; i++)
                    {
                        if (IsRoomCoordinate(crawler.CrawlerCoordinate))
                        {
                            Debug.Log("ㅇㅇ");
                            RoomPlacement();
                        }
                        else
                        {
                            Debug.Log("dd");
                            RandomDirection++;
                            break;
                        }

                    }
                    if (Roomlist.Count == 0)
                    {
                        RoomPlacement();
                    }
                }
                else // 상하좌우다 빈칸이 없다면 
                {
                    crawler.CrawlerReset();
                }
            }
        }
    }
    void RoomPlacement()
    {
        RoomInstance = Instantiate(RoomSpawner,crawler.CrawlerPosition,RoomSpawner.transform.rotation) ;
        RoomInstance.name = "ROOM(" + crawler.CrawlerCoordinate.x + "," + crawler.CrawlerCoordinate.y + ")";
        RoomInstance.transform.parent = this.transform;
        RoomInstance.GetComponent<Room>().SetRoomInfo(crawler.CrawlerCoordinate.x, crawler.CrawlerCoordinate.y);
        
        SetRoomList(RoomInstance.GetComponent<Room>());
        for(int i = 0; i<Roomlist.Count; i++)
        {
            Debug.Log(Roomlist[i]);
        }
    }

    public bool IsRoomCoordinate(Coordinate coordinate)
    {
        bool IsPass = true;
        for (int i = 0; i < Roomlist.Count; i++)
        {
           
            if (Roomlist[0].x==coordinate.x && Roomlist[0].y == coordinate.y)
            {
                Debug.Log(Roomlist[0].x + "," + Roomlist[0].y + "/" + coordinate.x + coordinate.y);
                IsPass = false;
            }
            else
            {
                IsPass = true;
            }
        }
        Debug.Log(IsPass);
        return IsPass;
    }
}
