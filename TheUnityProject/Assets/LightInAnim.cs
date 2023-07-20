using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightInAnim : StateMachineBehaviour
{
    [SerializeField] private float waitTime;
// OnStateUpdate is called before OnStateUpdate is called on any state inside this state machine
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (stateInfo.normalizedTime >= 1)
        {
            animator.GetComponent<CallCoroutine>().StartCoroutine(Enumerator());
    

        }
        IEnumerator Enumerator()
        { 
            
            yield return new WaitForSeconds(waitTime);
          animator.SetBool("IsTurningLightOn", false);
          
        }
    }
}