using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimEvents : MonoBehaviour
{
    private MovementScript player;

    private void Start()
    {
        player = transform.parent.GetComponent<MovementScript>();
    }

    public void CanMove()
    {
        player.canMove = true;
    }

    public void CantMove()
    {
        player.canMove = false;
    }

    public void CantRotate()
    {
        player.canRotate = false;
    }
    public void CanRotate()
    {
        player.canRotate = true;
    }

    public void Invincible()
    {
        player.isInvincible = true;
    }
    public void vincible()
    {
        player.isInvincible = false;
    }

    public void CantAttack()
    {
        player.canAttack = false;
    }
    public void CanAttack()
    {
        player.canAttack = true;
    }

    public void IsRoll()
    {
        player.isRoll = true;
    }

    public void IsntRoll()
    {
        player.isRoll = false;
    }

    public void IsHit()
    {
        player.isHit = true;
    }

    public void IsntHit()
    {
        player.isHit = false;
    }

    public void Step()
    {
        player.Step();
    }
}
