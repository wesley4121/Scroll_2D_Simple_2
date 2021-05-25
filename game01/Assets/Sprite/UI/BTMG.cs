using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BTMG : MonoBehaviour
{
    public GameObject ATKBT;
    public CutScene Cut;
    public BoolManage BoolMG;
    public GameObject ntrBase;
    public GameObject EVText;
    public NTRAniManager cAniMG;
    public AudioSource ATKSound;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    public void StartBT()
    {

        StartCoroutine("OnStartBT");

    }

    IEnumerator OnStartBT()
    {
        BoolMG.IsStart = true;
        BoolMG.IsEvent = true;
        Cut.c1.SetActive(false);
        Cut.cn.SetActive(true);
        yield return new WaitForSeconds(1);
        EVText.SetActive(true);


    }
    public void Attack()
    {
        if (!cAniMG.IsDie)
        {
            ATKSound.Play();
            StartCoroutine("OnAttack");
        }
    }
    IEnumerator OnAttack()
    {
        ntrBase.GetComponent<Animator>().Play("Base Attack");
        yield return new WaitForSeconds(0.8F);
        ntrBase.GetComponent<Animator>().Play("Base Idle");
    }


}
