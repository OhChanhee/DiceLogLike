using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TurnManager : MonoBehaviour
{
    public Button TurnBtn;//턴상태에 따라 이미지변경필요
    public Character Player;
    public Map Map;
    public List<Enemy> EnemyList = new List<Enemy>();

    void Start()
    {
        TurnBtn.onClick.AddListener(TurnEnd);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void BattleStart()
    {
        Room room = Map.SearchRoom(Player.MapCoordinate);
        Debug.Log(room.EnemyList.Count);
        for(int i=0;i<room.EnemyList.Count;i++)
        {
            this.EnemyList.Add(room.EnemyList[i].GetComponent<Enemy>());
        }
        StartCoroutine(PlayerTurn());          
    }
    IEnumerator PlayerTurn()
    {
        Debug.Log("플레이어턴 시작");
        GameManager.GetInstance().DiceCount++;
        Player.PlayerTurn = true;
        
       
        while(true)
        {
            if (GameManager.GetInstance().ActionPoint == 0 && !Player.PlayerTurn)//행동력을 다소모했을시
            {             
                Debug.Log("플레이어턴 끝");
                StartCoroutine(EnemyTurn());
                break;
            }
            else if(EnemyList.Count == 0)//몬스터를 다잡았을시 
            {
                Debug.Log("방클리어함");
                Room room = Map.SearchRoom(Player.MapCoordinate);
           
                if (room.TopDoor.activeSelf == true)
                {
                    room.TopDoor.GetComponent<Door>().isOpened = true;
                    
                    Debug.Log(room.TopDoor.GetComponent<Door>().isOpened);
                }
                if (room.BottomDoor.activeSelf == true)
                    room.BottomDoor.GetComponent<Door>().isOpened = true;
                if (room.LeftDoor.activeSelf == true)
                    room.LeftDoor.GetComponent<Door>().isOpened = true;
                if (room.RightDoor.activeSelf == true)
                    room.RightDoor.GetComponent<Door>().isOpened = true;
                break;
            }
        }
        yield return null;
    } 
    IEnumerator EnemyTurn()
    {
        Debug.Log("몬스터턴 시작");
        for(int i=0;i<EnemyList.Count;i++)//처음 enemylist의 크기만큼 반복문을돌림 
        {
           if(EnemyList[i]!= null)
            {
                EnemyList[i].EnemyTurn = true;
                EnemyList[i].Action();
                yield return new WaitWhile(() => !EnemyList[i].EnemyTurn);
            }          
        }
        Debug.Log("몬스터턴 끝");
        StartCoroutine(PlayerTurn());
        yield return null;
    }

    void TurnEnd()
    {
        if (GameManager.GetInstance().ActionPoint != 0) return;
        Player.PlayerTurn = false;
    }
}
  