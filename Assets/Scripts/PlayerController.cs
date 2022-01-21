using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // This class controls the player health, attack, etc excluding movement
    public HealthBar healthBar;
    public float maxHealth = 100;
    float curHealth;

    // testing values below
    public bool takeDamage = false;

    void Start()
    {
        curHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (takeDamage)
        {
            takeDamage = false;
            UpdateHealth(-20);
        }
    }

    void UpdateHealth(float val)
    {
        curHealth += val;
        healthBar.setHealth(curHealth / maxHealth);
    }
}
