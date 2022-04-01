using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinotaurAxe : MonoBehaviour
{
    public SO_Player player;
    public SO_Ennemis minotaur;

    public int damage;
    public int damagePhase2;


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && minotaur.isAttck)
        {
            if (minotaur.life <= (minotaur.maxLife / 2))
            {
                if (!player.isRolling && !player.isDeath)
                {
                    player.TakeDamage(damagePhase2);
                    other.gameObject.GetComponent<Animator>().Play("Hit");
                    if (player.isDeath)
                    {
                        minotaur.resetValue();
                    }
                }
                
            }
            else
            {
                if (!player.isRolling && !player.isDeath)
                {
                    player.TakeDamage(damage);
                    other.gameObject.GetComponent<Animator>().Play("Hit");
                    if (player.isDeath)
                    {
                        minotaur.resetValue();
                    }
                }
            }                
            
            
        }
    }
}
