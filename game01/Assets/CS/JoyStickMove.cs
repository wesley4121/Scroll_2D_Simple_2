using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoyStickMove : MonoBehaviour
{
    protected Joystick joystick;
    public NTRAniManager cAniMG;
    public bool IsAttack;
    public bool Zero;
    public bool Right;
    public bool Left;

    [Range(1, 200)] public float Speed;
    void Start()
    {
        joystick = FindObjectOfType<Joystick>();
    }


    void Update()
    {
        if ( !cAniMG.IsDie)
        {
            var c_rigibody = gameObject.GetComponent<Rigidbody2D>();
            c_rigibody.velocity = new Vector2(joystick.Horizontal * Speed, c_rigibody.velocity.y);
            if (joystick.Horizontal>0 && !IsAttack )
            {          
                Zero = false;
                Left = false;
                Right = true;
            }
            else if(joystick.Horizontal<0 && !IsAttack)
            {
                Zero = false;
                Right = false;
                Left = true;
            }
            else if(joystick.Horizontal==0 && !IsAttack)
            {
                Right = false;
                Left = false;
                Zero = true;
            }
        }
       
    }
}
