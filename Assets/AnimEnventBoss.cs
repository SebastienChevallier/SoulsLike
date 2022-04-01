using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimEnventBoss : MonoBehaviour
{
    public SO_Ennemis boss; 
    
    public void isAttack()
    {
        boss.isAttck = true;
    }
    public void isntAttack()
    {
        boss.isAttck = false;
    }

}
