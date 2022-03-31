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
        if (other.tag == "Player")
        {
            if (minotaur.life <= (minotaur.maxLife / 2))
                player.TakeDamage(damagePhase2);
            else
                player.TakeDamage(damage);
            other.gameObject.GetComponent<Animator>().Play("Hit");
            Debug.Log("J'ai pris des dégats");
        }
    }
}
