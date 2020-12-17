using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;


    public bool gameIsPlaying = false;
    public bool gameIsOver = false;


    [SerializeField] FloatReference score;
    [SerializeField] FloatReference scoreTarget;
    [Space(20)]
    [SerializeField] FloatReference timer;
    [SerializeField] FloatReference timerMax;

    private void Awake()
    {
        instance = this;
        score.Value = 0;
        timer.Value = timerMax.Value;
    }

    public void HideMenu() { UiController.i.menu.SetActive(false); Time.timeScale = 1; GameManager.instance.gameIsPlaying = true; }
    public void ShowMenu() { UiController.i.menu.SetActive(true); Time.timeScale = 0; GameManager.instance.gameIsPlaying = false; }


    public static void IncreaseScore(int value = 1)
    {
        AudioManager.PlayRecoltPresent();
        instance.score.Value += value;
    }


    public void EndGame()
    {
        gameIsOver = true;
        if (score.Value >= scoreTarget.Value)
        {
            UiController.i.OpenWinUi();
        } else
        {
            UiController.i.OpenGameOverUi();
        }

    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    [ContextMenu("Take Screen")]
    public void Screenshot()
    {
        DateTime dt = System.DateTime.Now;
        string path = "PhotoSanta" + dt.ToString("dd-MMMMM-yyyy_HH_mm_ss") + ".png";
        Debug.Log(path);
        UnityEngine.ScreenCapture.CaptureScreenshot(path);
    }


    //[ContextMenu("Take Screen 2")]
    //public void Screenshot2()
    //{
    //    StartCoroutine(TakeAndSaveScreenshot());
    //}

    //    IEnumerator TakeAndSaveScreenshot()
    //{

    //    yield return new WaitForEndOfFrame();

    //    Texture2D screenImage = new Texture2D(Screen.width, Screen.height);
    //    //Get Image from screen
    //    screenImage.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
    //    screenImage.Apply();
    //    //Convert to png
    //    byte[] imageBytes = screenImage.EncodeToPNG();

    //    //Save image to gallery
    //    NativeGallery.SaveImageToGallery(imageBytes, "AlbumName", "ScreenshotName.png", null);
    //}
}
