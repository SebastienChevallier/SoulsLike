using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player", menuName = "ScriptableObjects/Player", order = 1)]
public class SO_Player : ScriptableObject
{
    public int maxLife;
    public int life;

    public int maxStamina;
    public int stamina;

    public bool isRolling;

    
    public void  TakeDamage(int damage)
    {
        if (!isRolling)
        {
            life -= damage;            
        }                
    }

    public void UseStamina(int usedStamina)
    {
        if (stamina > usedStamina)
        {
            stamina -= usedStamina;
        }
    }

    public void GainStamina()
    {
        if(stamina < maxStamina)
        {
            stamina += 5;
        }
    }
}
