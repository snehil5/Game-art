﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class idlebehaviour : StateMachineBehaviour {
    GameObject BOSS;
    BossHealth bosshp;
    Animator bossanim;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {

        BOSS = GameObject.Find("Boss1");
        bosshp = BOSS.GetComponent<BossHealth>();
        bossanim = BOSS.GetComponent<Animator>();

    }

	 
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	    if (bosshp.health <= 0)
        {
            animator.SetTrigger("death");
        }
	}

	
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	
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
