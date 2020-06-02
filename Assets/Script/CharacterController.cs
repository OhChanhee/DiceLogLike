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
    void Attack()
    {
        if (GameManager.GetInstance().ActionPoint > 0 && Player.PlayerTurn == true)
        {
            switch (EventSystem.current.currentSelectedGameObject.name)
            {
                case "UPATK":
                    
                    GameManager.GetInstance().ActionPoint--;
                    break;
                case "DOWNATK":
                    
                    GameManager.GetInstance().ActionPoint--;
                    break;
                case "LEFTATK":
                
                    character.transform.localScale = new Vector3(1f, 1, 1);
                    GameManager.GetInstance().ActionPoint--;
                    break;
                case "RIGHTATK":
                  
                    character.transform.localScale = new Vector3(-1f, 1, 1);
                    GameManager.GetInstance().ActionPoint--;
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
        UpAttackBT.onClick.AddListener(Attack);
        DownAttackBT.onClick.AddListener(Attack);
        LeftAttackBT.onClick.AddListener(Attack);
        RightAttackBT.onClick.AddListener(Attack);
        BombBT.onClick.AddListener(SetBomb);
    }
}

