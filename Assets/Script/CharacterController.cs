using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class CharacterController : MonoBehaviour
{
    const float CameraHeight = 16;
    const float Camerawidth = 28.6f;

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

    public Map map;

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
        if (GameManager.GetInstance().ActionPoint > 0 && Player.PlayerTurn)
        {
            switch (EventSystem.current.currentSelectedGameObject.name)
            {
                case "UP":
                    if(Player.RoomCoordinate == new Coordinate(10,11)||Player.RoomCoordinate == new Coordinate(11,11))                    
                    {
                        if (Player.CurCharacterRoom().TopDoor.GetComponent<Door>().isOpened)
                        {
                            character.transform.position += new Vector3(0f, 5f);
                            Player.RoomCoordinate = new Coordinate(Player.RoomCoordinate.x, 0);
                            Player.MapCoordinate.y++;
                            Camera.main.transform.Translate(new Vector3(0, CameraHeight));
                        }
                        else break;
                    }
                    else
                    {
                        if (Player.RoomCoordinate.y == 11) break;

                        character.transform.position += new Vector3(0f, 1f);
                        Player.RoomCoordinate.y++;
                        GameManager.GetInstance().ActionPoint--;
                    }                
                    break;
                case "DOWN":
                    if (Player.RoomCoordinate == new Coordinate(10,0) || Player.RoomCoordinate == new Coordinate(11,0))
                    {
                        if (Player.CurCharacterRoom().BottomDoor.GetComponent<Door>().isOpened)
                        {
                            character.transform.position += new Vector3(0f, -5f);
                            Player.RoomCoordinate = new Coordinate(10, 11);
                            Player.MapCoordinate.y--;
                            Camera.main.transform.Translate(new Vector3(0, -CameraHeight));
                        }
                        else break;
                    }
                    else
                    {
                        if (Player.RoomCoordinate.y == 0) break;

                        character.transform.position += new Vector3(0f, -1f);
                        Player.RoomCoordinate.y--;
                        GameManager.GetInstance().ActionPoint--;
                    }                   
                    break;
                case "LEFT":
                    if (Player.RoomCoordinate == new Coordinate(0, 6) || Player.RoomCoordinate == new Coordinate(0,5)) 
                    {
                        if(Player.CurCharacterRoom().LeftDoor.GetComponent<Door>().isOpened)
                        {
                            character.transform.position += new Vector3(-7.6f, 0f);
                            character.transform.localScale = new Vector3(1f, 1, 1);
                            Player.RoomCoordinate = new Coordinate(21, 6);
                            Player.MapCoordinate.x--;
                            Camera.main.transform.Translate(new Vector3(-Camerawidth, 0));
                        }
                        else break;
                    }
                    else
                    {
                        if (Player.RoomCoordinate.x == 0) break;

                        character.transform.position += new Vector3(-1f, 0f);
                        character.transform.localScale = new Vector3(1f, 1, 1);
                        Player.RoomCoordinate.x--;
                        GameManager.GetInstance().ActionPoint--;
                    }                
                    break;
                case "RIGHT":
                    if (Player.RoomCoordinate == new Coordinate(21, 6) || Player.RoomCoordinate == new Coordinate(21, 5))
                    {
                        if (Player.CurCharacterRoom().RightDoor.GetComponent<Door>().isOpened)
                        {
                            character.transform.position += new Vector3(7.6f, 0f);
                            character.transform.localScale = new Vector3(-1f, 1, 1);
                            Player.RoomCoordinate = new Coordinate(0, 6);
                            Player.MapCoordinate.x++;
                            Camera.main.transform.Translate(new Vector3(Camerawidth, 0));
                        }
                        else break;
                    }                    
                    else
                    {
                        if (Player.RoomCoordinate.x == 21) break;

                        character.transform.position += new Vector3(1f, 0f);
                        character.transform.localScale = new Vector3(-1f, 1, 1);
                        Player.RoomCoordinate.x++;
                        GameManager.GetInstance().ActionPoint--;
                    }                              
                    break;
            }
        } 
    }
    void ClickedAttackBT()//enum 사용 
    {
        if (GameManager.GetInstance().ActionPoint > 0 && Player.PlayerTurn)
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
        if (GameManager.GetInstance().ActionPoint > 0 && Player.PlayerTurn)
        {
            //플레이어좌표에 폭탄을 생성함
            GameManager.GetInstance().BombValue--;
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
        Room CurRoom = map.SearchRoom(Player.RoomCoordinate);
        List<GameObject> targets = Player.SearchInRangeEnemy(dirNum);
        
        if (targets.Count == 0) return;

        for(int i= 0;i < targets.Count;i++)
        {
            targets[i].GetComponent<Enemy>().Life -= Random.Range(Player.waepon.MinDamage, Player.waepon.MaxDamage);
            if(targets[i].GetComponent<Enemy>().Life <= 0)
            {
                Debug.Log(CurRoom.EnemyList);
                GameObject temp = targets[i];
               // CurRoom.EnemyList.Remove(temp);
                Destroy(temp);     
            }
        }
        GameManager.GetInstance().ActionPoint--;
    }
    
    void MoveRoom()
    {

    }
}

