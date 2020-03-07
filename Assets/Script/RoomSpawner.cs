using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class RoomSpawner : MonoBehaviour
{
    public int OpeningDirection;
    // 0 --> 첫번쨰 방 스포너
    // 1 --> 위쪽 문이 필요함
    // 2 --> 아래쪽 문이 필요함
    // 3 --> 오른쪽 문이 필요함
    // 4 --> 왼쪽 문이 필요함

    private RoomTemplate Templates;
    private int rand;
    private Transform Rooms;
    private GameObject SpawnedRoom;
    private bool Spawned = false;
    void Awake()
    {
        Templates = GameObject.FindWithTag("RoomTemplate").GetComponent<RoomTemplate>();
        Rooms = GameObject.FindWithTag("Rooms").GetComponent<Transform>();
    }
    void Start()
    {      
        Invoke("Spawn", 1f);
    }

    void Spawn()
    {
        if(!Spawned)
        {
            if (OpeningDirection == 0)
            {
                rand = Random.Range(0, Templates.ALLROOM.Length);
                SpawnedRoom = Instantiate(Templates.ALLROOM[rand], transform.position, Templates.ALLROOM[rand].transform.rotation);
                SpawnedRoom.transform.parent = Rooms;
            }
            else if (OpeningDirection == 1)
            {
                rand = Random.Range(0, Templates.TopRoom.Length);
                SpawnedRoom = Instantiate(Templates.TopRoom[rand], transform.position, Templates.TopRoom[rand].transform.rotation);
                SpawnedRoom.transform.parent = Rooms;
            }
            else if (OpeningDirection == 2)
            {
                rand = Random.Range(0, Templates.BottomRoom.Length);
                SpawnedRoom = Instantiate(Templates.BottomRoom[rand], transform.position, Templates.BottomRoom[rand].transform.rotation);
                SpawnedRoom.transform.parent = Rooms;
            }
            else if (OpeningDirection == 3)
            {
                rand = Random.Range(0, Templates.RightRoom.Length);
                SpawnedRoom = Instantiate(Templates.RightRoom[rand], transform.position, Templates.RightRoom[rand].transform.rotation);
                SpawnedRoom.transform.parent = Rooms;
            }
            else if (OpeningDirection == 4)
            {
                rand = Random.Range(0, Templates.LeftRoom.Length);
                SpawnedRoom = Instantiate(Templates.LeftRoom[rand], transform.position, Templates.LeftRoom[rand].transform.rotation);
                SpawnedRoom.transform.parent = Rooms;
            }
            Spawned = true;
        }
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("SpawnPoint")&&other.GetComponent<RoomSpawner>().Spawned == true)
        {
            Destroy(gameObject);
        }
    }



}
