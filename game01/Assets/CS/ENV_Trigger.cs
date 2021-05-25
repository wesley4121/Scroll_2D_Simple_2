using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ENV_Trigger : MonoBehaviour
{
    public BoolManage BoolMG;
    public CutScene CutScene;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (gameObject.CompareTag("Cut")&&other.CompareTag("Player")&&!BoolMG.IsEvent&&!BoolMG.IsStart&&!BoolMG.IsLoad&&!BoolMG.IsPause)
        {
            
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
    }

    private void OnTriggerStay2D(Collider2D other)
    {
    }
}
