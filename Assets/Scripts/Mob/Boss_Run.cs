using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Boss_Run : StateMachineBehaviour
{
    public SO_Ennemis minotaur;

    public float wanderRadius;
    public float wanderTimer;
    private float timer;

    public float chargeRange;
    public float attack1Range;
    public float attack2Range;

    private float currentTime;
    private int currentHP;
    
    private int damageTaken;
    private bool phase2 = false;
    private bool taunt = false;

    Transform player;
    NavMeshAgent agent;

    Boss boss;


    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindWithTag("Player").transform;
        agent = animator.GetComponent<NavMeshAgent>();
        boss = animator.GetComponent<Boss>();
        timer = wanderTimer;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Follow_Player();
        Skills(animator);
        Phases(animator);
        CheckBurst(animator);
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Charge");
        animator.ResetTrigger("Attack1");
        animator.ResetTrigger("Attack2");
        animator.ResetTrigger("ComboAttack");
        animator.ResetTrigger("360");
        agent.ResetPath();
    }

    public void Follow_Player()
    {
        agent.SetDestination(player.position);
    }

    public void Skills(Animator animator)
    {
        float disToTarget = Vector3.Distance(player.position, agent.transform.position);
        float rand = Random.Range(0f, 1f);

        if (disToTarget <= attack2Range)
        {
            if (rand <= 0.5f && animator && !animator.GetBool("hasAttacked"))
            {
                if (!phase2)
                    animator.SetTrigger("Attack2");
                else
                    animator.SetTrigger("360");
            }
            else if (rand > 0.5f && animator && !animator.GetBool("hasAttacked"))
            {
                animator.SetTrigger("ComboAttack");
            }
            animator.SetBool("hasAttacked", true);
        }
        else if (disToTarget <= attack1Range)
        {
            animator.SetTrigger("Attack1");
            animator.SetBool("hasAttacked", true);
        }
        else if (disToTarget <= chargeRange)
        {
            animator.SetTrigger("Charge");
            animator.SetBool("Charging", true);
        }
    }
 
    public void Phases(Animator animator)
    {
        if (minotaur.life <= 0)
        {
            animator.SetTrigger("Death");
            agent.speed = 0;
        }
        else if (minotaur.life <= (minotaur.maxLife / 2) && !taunt)
        {
            animator.SetTrigger("Taunt");
            phase2 = true;
            taunt = true;
            agent.speed *= 2;
        }
    }

    private void CheckBurst(Animator animator)
    {
        currentTime += Time.fixedDeltaTime;
        damageTaken = currentHP - minotaur.life;

        if (damageTaken >= (minotaur.maxLife / 10))
        {
            animator.SetTrigger("Hit");
            damageTaken = 0;
            currentHP = minotaur.life;
            currentTime = 0;
        }
        else if (currentTime >= 3)
        {
            damageTaken = 0;
            currentHP = minotaur.life;
            currentTime = 0;
        }
    }
}
