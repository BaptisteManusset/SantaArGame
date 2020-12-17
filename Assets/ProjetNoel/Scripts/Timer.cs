using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{

    public FloatReference timeLeft;


    void Update()
    {
        if (!GameManager.instance.gameIsPlaying || GameManager.instance.gameIsOver) return;


        timeLeft.Value -= Time.deltaTime;
        if (timeLeft.Value < 0)
        {
            timeLeft.Value = 0;
            Time.timeScale = 0;
            Debug.Log("c'est fini putain");
            GameManager.instance.EndGame();
            this.enabled = false;
        }
    }
}
