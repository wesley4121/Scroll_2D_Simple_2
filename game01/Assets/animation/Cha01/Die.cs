using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die : StateMachineBehaviour
{
    public Animator NPC1;
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        NPC1 = GameObject.Find("NPC1").GetComponent<Animator>();
        NPC1.Play("Die");
    }
}
