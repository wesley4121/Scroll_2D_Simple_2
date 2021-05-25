using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class c_move : MonoBehaviour
{
  [Range(0,1)]  public float c_speed;

     public Transform c_Trans;


    public Animator c_animator;
    
    void Start()
    {      
        c_Trans = gameObject.transform;
        c_animator = GetComponent<Animator>();

    }


    void Update()
    {
        GetAxi();
    }
    


    public void GetAxi()
    {
        Playermove();
    }

    public void Playermove()
    {
        
        if (Input.GetKey(KeyCode.RightArrow))
        {
            c_Trans.rotation = Quaternion.Euler(0, 0, -18.994F);
            c_animator.SetBool("Run",true);

        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {      
            c_Trans.rotation = Quaternion.Euler(0, 0, 18.994F);
            c_animator.SetBool("Run",true);

        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            c_Trans.rotation = Quaternion.Euler(0, 0, 0);
            c_animator.SetBool("Run",false);
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            c_Trans.rotation = Quaternion.Euler(0, 0, 0);
            c_animator.SetBool("Run",false);

        }


    }
}
