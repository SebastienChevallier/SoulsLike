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

    void CanMove()
    {
        player.CanMove();
    }

    void CantMove()
    {
        player.CantMove();
    }

    public void CantRotate()
    {
        player.CantRotate();
    }
    public void CanRotate()
    {
        player.CanRotate();
    }

    public void Invincible()
    {
        player.Invincible();
    }
    public void vincible()
    {
        player.vincible();
    }

    public void CantAttack()
    {
        player.CantAttack();
    }
    public void CanAttack()
    {
        player.CanAttack();
    }

    public void IsRoll()
    {
        player.IsRoll();
    }

    public void IsntRoll()
    {
        player.IsntRoll();
    }
}
