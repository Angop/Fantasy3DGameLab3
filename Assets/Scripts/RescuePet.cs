using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RescuePet : MonoBehaviour
{
    public GameObject player;
    public GameEnd game;
    public Animator anim;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            anim.SetTrigger("breakCage");
            print("Breaking cage");
        }
    }

    public void WinGame()
    {
        game.Win();
    }
}
