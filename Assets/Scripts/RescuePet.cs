using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RescuePet : MonoBehaviour
{
    public GameObject player;
    public GameEnd game;

    private void OnTriggerEnter(Collider other)
    {
        if (other .gameObject == player)
        {
            game.Win();
        }
    }
}
