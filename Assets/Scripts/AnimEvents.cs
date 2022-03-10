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

}
