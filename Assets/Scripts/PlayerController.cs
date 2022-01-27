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

    AudioSource playerAudio;
    public AudioClip eatClip;

    List<GameObject> enemiesInRange;
    public float attackVal = 5; // damage of player attack

    // testing values below
    public bool takeDamage = false;
    public bool attack = false;

    void Start()
    {
        curHealth = maxHealth;
        attack = false;
        enemiesInRange = new List<GameObject>();
        playerAudio = GetComponent<AudioSource>();
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
        curHealth += curHealth + val <= maxHealth ? val : maxHealth - curHealth;
//        print(string.Format("set health to {0}", curHealth));
        healthBar.setHealth(curHealth / maxHealth);
        // TODO: play damaged, healing, or dying sound effect here
        
        if (curHealth <= 0)
        {
            // Player died
            ge.Lose();
        }
        else if (val > 0)
        {
            playerAudio.PlayOneShot(eatClip, Random.Range(0.75f, 1));
        }
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            print("adding enemy to list");
            enemiesInRange.Add(other.gameObject);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            print("removing enemy from list");
            enemiesInRange.Remove(other.gameObject);
        }
    }

    void OnAttack()
    {
        attack = true;
        // Note: switching to this if statement allows spamming the attack button,
        // but it introduces an awkward pause between each attack
        //if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        //{
        //    attack = true;
        //}
    }

    void AttackEnemies()
    {
        // called from animation event
        ZombieController zc = null;

        for (int i = 0; i < enemiesInRange.Count; i++)
        {
            if (enemiesInRange[i] != null)
            {
                zc = enemiesInRange[i].GetComponent<ZombieController>();
                zc.UpdateHealth(-attackVal);
            }
            else
            {
                enemiesInRange.Remove(enemiesInRange[i]);
            }
        }
    }

    public bool isAlive()
    {
        return curHealth > 0;
    }
}
