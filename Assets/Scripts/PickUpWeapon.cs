using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpWeapon : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.parent.GetComponent<MovementScript>().weaponType = tag;
            other.transform.parent.GetComponent<MovementScript>().CheckWeapon();
        }
    }

}
