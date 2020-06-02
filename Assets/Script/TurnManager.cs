using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public Character Player;
    public Map Map;
    List<Enemy> EnemyList = new List<Enemy>();

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void BattleStart()
    {

        StartCoroutine(PlayerTurn());
            
    }
    IEnumerator PlayerTurn()
    {
        Player.PlayerTurn = true;
        yield return null;
        while(true)
        {
            if (GameManager.GetInstance().ActionPoint == 0)//행동력을 다소모했을시
            {
                Player.PlayerTurn = false;
                StartCoroutine(EnemyTurn());
                break;
            }
            else if(EnemyList.Count == 0)//몬스터를 다잡았을시 
            {
                Room room = Map.SearchRoom(Player.RoomCoordinate);
                room.TopDoor.GetComponent<Door>().isOpened = true;
                room.BottomDoor.GetComponent<Door>().isOpened = true;
                room.LeftDoor.GetComponent<Door>().isOpened = true;
                room.RightDoor.GetComponent<Door>().isOpened = true;
                break;
            }
        }
       
    } 
    IEnumerator EnemyTurn()
    {
        
        for(int i=0;i<EnemyList.Capacity;i++)//처음 enemylist의 크기만큼 반복문을돌림 
        {
           if(EnemyList[i]!= null)
            {
                EnemyList[i].Action();
                yield return new WaitForSeconds(3f);
                EnemyList[i].EnemyTurn = false;
            }          
        }
        StartCoroutine(PlayerTurn());
        yield return null;
    }
}
  