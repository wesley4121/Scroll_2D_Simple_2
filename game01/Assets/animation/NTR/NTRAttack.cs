using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NTRAttack : StateMachineBehaviour
{
    
    public Animator ntrsni;
    public Rigidbody2D ntrRigi;
    public Transform ntrTras;
    public GameObject ntr;
    public GameObject Attack;
    public JoyStickMove JoyMove;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        JoyMove = GameObject.Find("NTR").GetComponent<JoyStickMove>();
        ntrRigi = GameObject.Find("NTR").GetComponent<Rigidbody2D>();
        ntrTras = GameObject.Find("NTR").GetComponent<Transform>();
        ntrsni = GameObject.Find("NTR").GetComponent<Animator>();
        ntr = GameObject.Find("NTR");
        Attack  = GameObject.Find("NTRAttack");
        JoyMove.IsAttack = true;
        Attack.transform.localScale = new Vector3(4, 4, 0);

    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (ntr.transform.localScale.x>0 )
        {

            ntrRigi.AddForce(Vector2.right*100);
        }
        else
        {

            ntrRigi.AddForce(Vector2.left*100);

        }
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        Attack.transform.localScale = new Vector3(0, 4, 0);

        JoyMove.IsAttack = false;
        

    }
}
