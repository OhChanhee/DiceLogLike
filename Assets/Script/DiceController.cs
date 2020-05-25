using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DiceController : MonoBehaviour
{
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
        StartCoroutine(RollTheDice());
    }

    private IEnumerator RollTheDice()
    {
        int randomNum = 0;

         for (int i = 0;i<20;i++)
        {
            randomNum = Random.Range(0, 5);
            curimage.sprite = sprites[randomNum];

            yield return new WaitForSeconds(0.05f);
        }

        DiceNum = randomNum + 1;
    }

    
    // Update is called once per frame
    void Update()
    {
        
    }
}
