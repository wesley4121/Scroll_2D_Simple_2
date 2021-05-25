using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triger : MonoBehaviour
{
    public bool Tri;
    public bool PlayerTri;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
 
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (gameObject.CompareTag("NPCRange") && other.CompareTag("Player"))
        {
            Tri = true;
        }   
        if (gameObject.CompareTag("Player") && other.CompareTag("NPC"))
        {
            PlayerTri = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (gameObject.CompareTag("NPCRange") && other.CompareTag("Player"))
        {
            Tri = false;
        }  
        if (gameObject.CompareTag("Player") && other.CompareTag("NPC"))
        {
            PlayerTri = false;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (gameObject.CompareTag("NPCRange") && other.CompareTag("Player"))
        {
            Tri = true;
        }     
        if (gameObject.CompareTag("Player") && other.CompareTag("NPC"))
        {
            PlayerTri = true;
        }
    }
}
