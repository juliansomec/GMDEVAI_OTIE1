using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class Flee : NPCBaseFSM
{
    private Transform player;
    private float fleeSpeed = 5.0f;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        player = opponent.transform;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate(animator, stateInfo, layerIndex);

        Vector3 dir = NPC.transform.position - player.position;
        dir.Normalize();

        NPC.transform.rotation = Quaternion.Slerp(NPC.transform.rotation, Quaternion.LookRotation(dir), rotSpeed * Time.deltaTime);
        NPC.transform.Translate(dir * fleeSpeed * Time.deltaTime, Space.World);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateExit(animator, stateInfo, layerIndex);
    }
}
