using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    Transform TR;
    public int Speed = 1;
    void Start()
    {
        TR = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        float V = Input.GetAxis("Vertical");
        float H = Input.GetAxis("Horizontal");
        Flip(H);
        TR.Translate(new Vector2(H * Speed * Time.deltaTime, V * Time.deltaTime * Speed));
        
        
    }
    void Flip(float H)
    {
        if(H<0)
        {
            Debug.Log("X");
            TR.localScale = new Vector3(1, 1, 1);
        }
        else if(H>0)
        {
            Debug.Log("O");
            TR.localScale = new Vector3(-1, 1, 1);
        }
        
    }
}
