using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public float chargeCD = 15f;
    public float attackCD = 3f;

    private float currentChargeTime = 0;
    private float currentAttackTime = 0;

    Transform player;
    Animator animator;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        animator = GetComponent<Animator>();
    }

    public void Update()
    {
        StartCoroutine(Skills_Lag());
        Reset_Skills();
    }

    public void Rotate_Towards_Player(float rotationSpeed)
    {
        Vector3 direction = (player.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
    }

    public IEnumerator Skills_Lag()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("RamStart"))
        {
            Rotate_Towards_Player(12f);
            yield return new WaitForSeconds(.2f);
            animator.SetBool("Charging", false);
            animator.SetBool("hasCharged", true);
        }
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Walk"))
        {
            Rotate_Towards_Player(.3f);
            yield return null;
        }
    }

    public void Reset_Skills()
    {
        currentChargeTime += Time.deltaTime;
        currentAttackTime += Time.deltaTime;

        if (currentChargeTime >= chargeCD)
        {
            animator.SetBool("hasCharged", false);
            currentChargeTime = 0;
        }
        if (currentAttackTime >= attackCD)
        {
            animator.SetBool("hasAttacked", false);
            currentAttackTime = 0;
        }
    }
}
