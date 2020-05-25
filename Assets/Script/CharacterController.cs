using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class CharacterController : MonoBehaviour
{
    public GameObject character;

    public Button UpMoveBT;
    public Button DownMoveBT;
    public Button LeftMoveBT;
    public Button RightMoveBT;

    void Start()
    {
        SetMoveButton();
        SetStartPosition();
    }

    public void Move()
    {
        switch (EventSystem.current.currentSelectedGameObject.name)
        {
            case "UP":         
                character.transform.position += new Vector3(0f, 1f);                
                break;
            case "DOWN":
                character.transform.position += new Vector3(0f, -1f);
                break;
            case "LEFT":
                character.transform.position += new Vector3(-1f, 0f);
                character.transform.localScale = new Vector3(1f, 1, 1);
                break;
            case "RIGHT":
                character.transform.position += new Vector3(1f, 0f);
                character.transform.localScale = new Vector3(-1f,1,1);
                break;
        }
    }
    
    private void SetStartPosition()
    {
        character.transform.position = new Vector2(0.5f, 0.7f);
    }

    private void SetMoveButton()
    {
        UpMoveBT.onClick.AddListener(Move);
        DownMoveBT.onClick.AddListener(Move);
        LeftMoveBT.onClick.AddListener(Move);
        RightMoveBT.onClick.AddListener(Move);
    }
}
