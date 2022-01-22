using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameEnd : MonoBehaviour
{
    public GameObject winScreen;
    public GameObject loseScreen;

    private bool gameover;

    void Start()
    {
        // turn off ending screens
        winScreen.SetActive(false);
        loseScreen.SetActive(false);
        gameover = false;
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
        winScreen.SetActive(true);
    }
    public void Lose()
    {
        print("YOU LOSE!!");
        gameover = true;
        loseScreen.SetActive(true);
    }
    private void RestartScene()
    {
        print("Restarting scene");
    }
}
