using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReloadSceneOnClick : MonoBehaviour
{
    public Button restartButton;
    void Start()
    {
        Debug.Log("The scene has started.");
        restartButton.onClick.AddListener(ReloadScene);
    }

    void ReloadScene()
    {
        Debug.Log("You clicked the button.");
    }
}
