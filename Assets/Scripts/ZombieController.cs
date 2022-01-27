using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour
{
    public Transform player; // contains position
    public PlayerController playerController; // player health, etc
    private Animator anim;

    public float detectionRange = 20;
    public float attackRange = 1;
    public float attackVal = 5;

    public float health = 20;
    bool isDead;

    AudioSource zombieAudioSource;
    public AudioClip searchSound;
    public AudioClip damagedSound;
    
    // testing variables
    public bool attack;
    public bool walk;
    public bool kill;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        isDead = false;
        attack = false;
        walk = false;
        zombieAudioSource = GetComponent<AudioSource>();
        // periodically makes sound
        StartCoroutine(SearchingZombieSound());
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead)
        {
            if (PlayerDetected())
            {
                if (PlayerInAttackRange())
                {
                    AttackPlayer();
                }
                else
                {
                    ChasePlayer();
                }
            }
            else if (anim.GetBool("isWalking"))
            {
                // idle
                print("Zombie stops walking");
                walk = false;
            }

            if (walk)
            {
                anim.SetBool("isWalking", true);
            }
            if (!walk)
            {
                anim.SetBool("isWalking", false);
            }
        }

        // testing code
        if (attack)
        {
            anim.SetTrigger("attack");
            attack = false;
        }
        if (kill)
        {
            UpdateHealth(-health);
        }
    }

    private void ChasePlayer()
    {
        transform.LookAt(player);
        if (!anim.GetBool("isWalking"))
        {
            print("Zombie starts walking");
            walk = true;
        }
    }
    private void AttackPlayer()
    {
        anim.SetTrigger("attack");
        // TODO: write the actual damage
    }

    void DamagePlayer()
    {
        // Called as an animation event on attack animation
        // if statement prevents damage when player has moved out of range
        if (PlayerInAttackRange() && playerController.isAlive())
        {
            playerController.UpdateHealth(-attackVal);
        }
    }

    private bool PlayerDetected()
    {
        // true if player is within range of zombie
        return Vector3.Distance(transform.position, player.position) < detectionRange;
    }

    private bool PlayerInAttackRange()
    {
        return Vector3.Distance(transform.position, player.position) < attackRange;
    }

    public void UpdateHealth(float val)
    {
        health += val;

        if (val < 0)
        {
            // on damage, make sound
            zombieAudioSource.PlayOneShot(damagedSound);
        }
        if (health <= 0)
        {
            // dies
            isDead = true;
            anim.SetTrigger("dies");
            anim.ResetTrigger("attack"); // prevents trying to attack after death
        }
    }
    void Dies()
    {
        // called from end of death animation
        Destroy(gameObject);
    }

    IEnumerator SearchingZombieSound()
    {
        while(!walk)
        {
            zombieAudioSource.PlayOneShot(searchSound);
            yield return new WaitForSeconds(Random.Range(5, 10));
        }
    }
}
