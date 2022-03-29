using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Boss_Run : StateMachineBehaviour
{
    public float wanderRadius;
    public float wanderTimer;
    private float timer;

    public float chargeRange;
    public float attack1Range;
    public float attack2Range;

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
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Charge");
        animator.ResetTrigger("Attack1");
        animator.ResetTrigger("Attack2");
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
                animator.SetTrigger("Attack2");
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


    public Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist;

        randDirection += origin;

        UnityEngine.AI.NavMeshHit navHit;

        UnityEngine.AI.NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);

        return navHit.position;
    }

    public void Random_Walk()
    {
        timer += Time.deltaTime;

        if (timer >= wanderTimer)
        {
            Vector3 newPos = RandomNavSphere(agent.transform.position, wanderRadius, -1);
            agent.SetDestination(newPos);
            timer = 0;
        }
    }
}
