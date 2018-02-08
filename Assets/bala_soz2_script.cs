using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bala_soz2_script : StateMachineBehaviour {
    GameObject shal;
    Animator shalAnimator;

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        shal = GameObject.Find("Asian_Nomad_Old_Man2");
        shalAnimator = shal.GetComponent<Animator>();
        shalAnimator.SetBool("isResponsed", true);
    }

    // OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}
}
