using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "Player", menuName = "ScriptableObjects/Player", order = 1)]
public class SO_Player : ScriptableObject
{
    public int maxLife;
    public int life;

    public int maxStamina;
    public int stamina;
    public int nbHeal = 5;

    public bool isRolling;
    public bool isLock;
    public bool isDeath = false;

    [Header("Audio")]
    public AudioClip HitAudio;
    public AudioClip RollAudio;
    public AudioClip WaterStepAudio;
    public AudioClip StepAudio;
    public AudioClip SpecialAudio;

    public void ResetValue()
    {
        life = maxLife;
        stamina = maxStamina;
        isDeath = false;
        nbHeal = 5;
    }
    public void  TakeDamage(int damage)
    {
        if (!isRolling)
        {
            life -= damage;
            
        }                                                                      
    }    
    
    public void Heal(int value)
    {
        
        if(maxLife - life < value)
        {
            life += maxLife - life;
        }
        else
        {
            life += value;
        }
        nbHeal--;
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
