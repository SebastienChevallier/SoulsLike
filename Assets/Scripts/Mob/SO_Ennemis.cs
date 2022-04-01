using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Boss", menuName = "ScriptableObjects/Boss", order = 1)]
public class SO_Ennemis : ScriptableObject
{
    public string _name;
    public int maxLife;
    public int life;
    public bool isAttck;


    public void TakeDamage(int damage)
    {
        if (life > damage)
        {
            life -= damage;
        }
    }
}
