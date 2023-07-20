using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalScriptAnim : StateMachineBehaviour
{
    public static bool wallAnimOk = false;
// OnStateUpdate is called before OnStateUpdate is called on any state inside this state machine
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (stateInfo.normalizedTime >= 1)
        {
            if (animator.GetBool("IsInWall") == false)
            {
                animator.SetBool("IsHittingWall", false);
                animator.SetBool("TheFinalBool", true);
            }
            else
            {
                animator.SetBool("TheFinalBool", false);
            }

        }
    }
}