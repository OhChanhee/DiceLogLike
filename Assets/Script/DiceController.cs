using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DiceController : MonoBehaviour
{
    public Character character;
    public Sprite[] sprites;
    public Button RollBtn;
    Image curimage;
    private int DiceNum;
   
    void Start()
    {
        curimage = gameObject.GetComponent<Image>();
        RollBtn.onClick.AddListener(ClickedRollBtn);
    }

    public void ClickedRollBtn()
    {
        if(character.PlayerTurn && GameManager.GetInstance().DiceCount>0)
        {
            StartCoroutine(RollTheDice());
        }
        else
        {
            Debug.Log("플레이어의 턴이아니라서 주사위를 굴릴수없습니다");
            //플레이어의 턴이아니라서 주사위를 굴릴수없음을 알려줌
        }
    }

    private IEnumerator RollTheDice()
    {
        GameManager.GetInstance().DiceCount--;
        int randomNum = 0;

         for (int i = 0;i<20;i++)
        {
            randomNum = Random.Range(0, 5);
            curimage.sprite = sprites[randomNum];

            yield return new WaitForSeconds(0.05f);
        }

        DiceNum = randomNum + 1;
        GameManager.GetInstance().ActionPoint += DiceNum;
    }

}
