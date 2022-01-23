using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // This class controls the player health, attack, etc excluding movement
    public HealthBar healthBar;
    public float maxHealth = 100;
    float curHealth;

    public GameEnd ge;
    public Animator anim;

    // testing values below
    public bool takeDamage = false;
    public bool attack = false;

    void Start()
    {
        curHealth = maxHealth;
        attack = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (takeDamage)
        {
            takeDamage = false;
            UpdateHealth(-20);
        }
        if (attack)
        {
            attack = false;
            anim.SetTrigger("attack");
        }
    }

    public void UpdateHealth(float val)
    {
        curHealth += val;
        healthBar.setHealth(curHealth / maxHealth);

        if (curHealth <= 0)
        {
            // Player died
            ge.Lose();
        }
    }
}
