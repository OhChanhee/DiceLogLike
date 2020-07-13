using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StartGame : MonoBehaviour
{
    public Button Start_btn;
    void Start()
    {
        Start_btn.onClick.AddListener(OnClick_Startbtn);
    }

    void OnClick_Startbtn()
    {
        LoadingManager.LoadScene("GameScene");
    }


}
