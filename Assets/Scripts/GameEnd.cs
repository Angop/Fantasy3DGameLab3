using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using System;
using TMPro;

public class GameEnd : MonoBehaviour
{
    public GameObject winScreen;
    public GameObject loseScreen;

    private bool gameover;
    DateTime startTime;

    void Start()
    {
        // turn off ending screens
        winScreen.SetActive(false);
        loseScreen.SetActive(false);
        gameover = false;

        startTime = new DateTime();
        startTime = DateTime.Now;
    }

    public void OnRestart()
    {
        if (gameover)
        {
            print("Restarting scene");
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.buildIndex);
        }
        else
        {
            print("Game's not over yet");
        }
    }

    public void Win()
    {
        print("YOU WON!!");
        gameover = true;

        String totalTimeStr = GetCompletionTimeStr();

        TextMeshProUGUI textMesh = winScreen.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        textMesh.text = "Completion time: " + totalTimeStr;

        winScreen.SetActive(true);
    }
    public void Lose()
    {
        print("YOU LOSE!!");
        gameover = true;
        String totalTimeStr = GetCompletionTimeStr();

        TextMeshProUGUI textMesh = loseScreen.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        textMesh.text = "Completion time: " + totalTimeStr;

        loseScreen.SetActive(true);
    }
    private void RestartScene()
    {
        print("Restarting scene");
    }
    private String GetCompletionTimeStr()
    {
        DateTime endTime = DateTime.Now;
        DateTime totTime = new DateTime() + (endTime - startTime);
        String totalTimeStr = totTime.ToString("H:mm:ss");

        return totalTimeStr;
    }
}
