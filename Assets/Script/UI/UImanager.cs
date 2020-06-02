﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UImanager : MonoBehaviour
{
    public Character character;

    public Text Coin_txt; 
    public Text Key_txt;
    public Text Bomb_txt;
    public Text ActionPoint_txt;
    public Image WaeponImage;
    public Image ItemImage;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ShowUI();
    }

    void ShowUI()
    {
        Coin_txt.text = "x " + GameManager.GetInstance().CoinValue;
        Key_txt.text = "x " + GameManager.GetInstance().KeyValue;
        Bomb_txt.text = "x " + GameManager.GetInstance().BombValue;
        ActionPoint_txt.text = "행동력 :" + GameManager.GetInstance().ActionPoint;
        WaeponImage.sprite = character.waepon.WaeponSprite;
        ItemImage.sprite = character.item.ItemSprite;
    }
}
