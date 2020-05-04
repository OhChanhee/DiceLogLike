using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCrawler : MonoBehaviour
{
    public MapCrawler(int Num)
    {
        CrawlerNum = Num;
    }

    public Coordinate CrawlerCoordinate = new Coordinate();
    public int CrawlerNum;
    public Vector2 CrawlerPosition = new Vector2(0,0);
    private void Start()
    {
        CrawlerCoordinate.x = 0;
        CrawlerCoordinate.y = 0;
    }

    public void CrawlerReset()
    {
        CrawlerCoordinate.x = 0;
        CrawlerCoordinate.y = 0;
        CrawlerPosition = new Vector2(0,0);
    }

}
