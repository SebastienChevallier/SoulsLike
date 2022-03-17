using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockCollider : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)        
    {        
        if (other.gameObject.CompareTag("Player"))
        {            
            GameObject.Find("CamAnchor").GetComponent<JoystickCamera>().lockCible = transform.parent;            
        }
    }
}
