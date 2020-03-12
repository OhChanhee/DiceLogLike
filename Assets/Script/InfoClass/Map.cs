﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public GameObject RoomSpawner;
    private List<Room> Roomlist = new List<Room>();
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

    private Vector2 up = new Vector2(0,14);
    private Vector2 down = new Vector2(0,-14);
    private Vector2 left = new Vector2(-22, 0f);
    private Vector2 right = new Vector2(22, 0f);

    void MapCrawling()
    {
        RoomPlacement();// (0,0) 좌표의 기본방을 만들어주는역활 
        for (int Craw=0 ; Craw < crawler.CrawlerNum ; Craw++ )
        {
            int rand = Random.Range(MinRoomNum, MaxRoomNum + 1);// 방개수 설정
            Debug.Log(Craw + "회차:" + rand+"개의방생성해야댐");
            for (int Count = 0; Count < rand; Count++)
            {
                int RandomDirection = Random.Range(1, 5); // 크롤러가 이동할 방향설정          
                if(RandomDirection == 1) // 만약에 크롤러가 위로이동
                {                 
                    crawler.CrawlerCoordinate.y++;
                    crawler.CrawlerPosition += up;               
                        if (IsRoomCoordinate(crawler.CrawlerCoordinate))
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

                        if (IsRoomCoordinate(crawler.CrawlerCoordinate))
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
                    
                        if (IsRoomCoordinate(crawler.CrawlerCoordinate))
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
                
                        if (IsRoomCoordinate(crawler.CrawlerCoordinate))
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
        bool IsPass = true;
        for (int i = 0; i < Roomlist.Count; i++)
        {       
            if (Roomlist[i].x==coordinate.x && Roomlist[i].y == coordinate.y)
            {
                IsPass = false;
                break;
            }
            else
            {
                IsPass = true;
            }
        }
        return IsPass;
    }
}
