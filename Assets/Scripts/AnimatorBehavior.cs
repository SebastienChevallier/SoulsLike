using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorBehavior : StateMachineBehaviour
{

    private MovementScript player;
    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = animator.transform.parent.GetComponent<MovementScript>();
        player.CanMove();
    }
}

   

