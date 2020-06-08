using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class CharacterController : MonoBehaviour
{
    public GameObject character;
    private Character Player;
    public Button UpMoveBT;
    public Button DownMoveBT;
    public Button LeftMoveBT;
    public Button RightMoveBT;
    public Button UpAttackBT;
    public Button DownAttackBT;
    public Button LeftAttackBT;
    public Button RightAttackBT;
    public Button BombBT;


    private void Awake()
    {
        Player = character.GetComponent<Character>();
    }
    void Start()
    {
        SetActionButton();
        SetStartPosition();
    }

    public void Move()
    {
        if (GameManager.GetInstance().ActionPoint > 0 && Player.PlayerTurn == true)
        {
            switch (EventSystem.current.currentSelectedGameObject.name)
            {
                case "UP":
                    character.transform.position += new Vector3(0f, 1f);
                    Player.RoomCoordinate.y++;
                    GameManager.GetInstance().ActionPoint--;
                    break;
                case "DOWN":
                    character.transform.position += new Vector3(0f, -1f);
                    Player.RoomCoordinate.y--;
                    GameManager.GetInstance().ActionPoint--;
                    break;
                case "LEFT":
                    character.transform.position += new Vector3(-1f, 0f);
                    character.transform.localScale = new Vector3(1f, 1, 1);
                    Player.RoomCoordinate.x--;
                    GameManager.GetInstance().ActionPoint--;
                    break;
                case "RIGHT":
                    character.transform.position += new Vector3(1f, 0f);
                    character.transform.localScale = new Vector3(-1f, 1, 1);
                    Player.RoomCoordinate.x++;
                    GameManager.GetInstance().ActionPoint--;                
                    break;
            }
        } 
    }
    void ClickedAttackBT()
    {
        if (GameManager.GetInstance().ActionPoint > 0 && Player.PlayerTurn == true)
        {
            switch (EventSystem.current.currentSelectedGameObject.name)
            {
                case "UPATK":
                    Attack(1);                
                    break;
                case "DOWNATK":
                    Attack(2);
                    break;
                case "LEFTATK":
                    Attack(3);
                    character.transform.localScale = new Vector3(1f, 1, 1);
                    break;
                case "RIGHTATK":
                    Attack(4);
                    character.transform.localScale = new Vector3(-1f, 1, 1);
                    break;
            }
        }
    }
    void SetBomb()
    {
        if (GameManager.GetInstance().ActionPoint > 0 && Player.PlayerTurn == true)
        {
            //플레이어좌표에 폭탄을 생성함
        }
    }
    private void SetStartPosition()
    {
        character.transform.position = new Vector2(0.5f, 0.7f);
    }

    private void SetActionButton()
    {
        UpMoveBT.onClick.AddListener(Move);
        DownMoveBT.onClick.AddListener(Move);
        LeftMoveBT.onClick.AddListener(Move);
        RightMoveBT.onClick.AddListener(Move);
        UpAttackBT.onClick.AddListener(ClickedAttackBT);
        DownAttackBT.onClick.AddListener(ClickedAttackBT);
        LeftAttackBT.onClick.AddListener(ClickedAttackBT);
        RightAttackBT.onClick.AddListener(ClickedAttackBT);
        BombBT.onClick.AddListener(SetBomb);
    }

    void Attack(int dirNum)// 1: 위쪽 2:아래쪽 3:왼쪽 4:오른쪽
    {
        List<Enemy> targets = Player.SearchInRangeEnemy(dirNum);

        if (targets.Count == 0) return;

        for(int i= 0;i < targets.Count;i++)
        {
            targets[i].Life -= Random.Range(Player.waepon.MinDamage, Player.waepon.MaxDamage);  
        }
        GameManager.GetInstance().ActionPoint--;
    }
}

