using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NTRDie : StateMachineBehaviour
{
    public Animator Base;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Base = GameObject.Find("Base").GetComponent<Animator>();

    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Base.Play("Base Die");
    }
}
