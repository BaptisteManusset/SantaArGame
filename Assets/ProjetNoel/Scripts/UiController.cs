using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiController : MonoBehaviour
{

    public GameObject menu;
    public GameObject gameover;
    public GameObject win;
    public static int score;

    public static UiController i;




    private void Awake()
    {
        i = this;
        Time.timeScale = 0;

        menu.SetActive(true);


    }
    public void AddScore(int value)
    {
        score += value;
    }

    public void OpenGameOverUi()
    {
        gameover.SetActive(true);
    }
    public void OpenWinUi()
    {
        win.SetActive(true);
    }
}
