using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{

    public  Slider mSlider ;

    public float nowHP;


    private void Start()
    {

    }

    private void Update()
    {

    }

    public  void setHp(float nowHP)
    {
        mSlider.value = nowHP;
    }

    public  void setmaxHp(float maxHP)
    {
        mSlider.maxValue = maxHP;
        mSlider.value = maxHP;   
    }
}