using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour
{
    public Transform player;
    private Animator anim;
    public float detectionRange = 10;
    public float attackRange = 1;
    
    // testing variables
    public bool attack;
    public bool walk;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        attack = false;
        walk = false;
    }

    // Update is called once per frame
    void Update()
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

        // testing code
        if (attack)
        {
            anim.SetTrigger("attack");
            attack = false;
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

    private bool PlayerDetected()
    {
        // true if player is within range of zombie
        return Vector3.Distance(transform.position, player.position) < detectionRange;
    }

    private bool PlayerInAttackRange()
    {
        return Vector3.Distance(transform.position, player.position) < attackRange;
    }
}
