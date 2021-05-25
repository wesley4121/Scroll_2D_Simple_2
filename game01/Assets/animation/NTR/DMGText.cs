using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DMGText : MonoBehaviour
{
    [Range(0,0.1F)]public float Speed;
    public float Alpha;
    void Start()
    {
        Alpha = 255;
    }

    // Update is called once per frame
    void Update()
    {

        Alpha -= 1;
        gameObject.transform.Translate(Vector3.up*Speed);
        
    }
    
}
