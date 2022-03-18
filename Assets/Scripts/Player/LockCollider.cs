using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockCollider : MonoBehaviour
{
    public static bool looking;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameObject.Find("CamAnchor").GetComponent<JoystickCamera>().lockCible = transform.parent;
            looking = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            looking = false;
        }
    }
}