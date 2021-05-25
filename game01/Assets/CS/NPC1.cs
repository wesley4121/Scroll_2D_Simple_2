using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class NPC1 : MonoBehaviour
{
    public NPC1 instens;
    [Range(0,300)]  public float c_speed;
    [Range(0,300)]  public float c_jump;
    public BoolManage BoolMG;
    public GameObject atkObj;
    public GameObject ntr;
    public GameObject NPCHPBar;
    public GameObject DMGText;
    public TextMeshProUGUI HPText;
    public float MaxHP;
    public Triger ATKrange;
    public Triger Dashrange;
    public Triger Stoprange;
    public bool IsGround;
    public Rigidbody2D m_rigi2D;
    public Animator m_Animator;
    public Transform m_Trans;
    public Vector3 mScale;
    public Vector3 HPScale;
    public HPBar HPbar;

    public Transform DMGPos;

[Range(0,500)]    public float HP;

private void Awake()
{
    instens = this;
}

void Start()
{
        m_rigi2D = gameObject.GetComponent<Rigidbody2D>();
        m_Trans = gameObject.GetComponent<Transform>();
        m_Animator = gameObject.GetComponent<Animator>();
        mScale = gameObject.transform.localScale;
        HPScale = NPCHPBar.GetComponent<RectTransform>().localScale;
        HPbar = gameObject.GetComponentInChildren<HPBar>();
        HPbar.setmaxHp(HP);
        MaxHP = HP;
        HPText.text = MaxHP + "/" + MaxHP;
    }

    // Update is called once per frame
    void Update()
    {
        NTRAniManager P = GameObject.FindWithTag("Player").GetComponent<NTRAniManager>();

        if (BoolMG.IsStart && !BoolMG.IsLoad && !BoolMG.IsPause &&!BoolMG.IsEvent && !IsDamage&& !IsDie&& P.Hp>0)
        {
            Movving();
        }

        if (HP<=0 && !IsDie)
        {
            StartCoroutine("Die");
        }

    }




    public string currenState;
    public void ChangeAnimeState(string newAni)
    {

        if (currenState== newAni) return;
        
        m_Animator.Play(newAni);
        currenState = newAni;

    }
    const string NPCIdle ="Idle";
    const string NPCMove ="Move";
    const string NPCAttack ="Attack";
    const string NPCWalk ="Walk";
    const string NPCDie ="ToDie";
    
    
    
    public bool IsDash;
    public bool IsWalk;
    public bool IsAttack;
    public bool IsDie;
    public bool IsDamage;
    IEnumerator Attack()
    {
        if (!IsAttack)
        {
            IsWalk = false;
            IsDash = false;
            StopCoroutine("Dash");
            StopCoroutine("Walk");
            IsAttack = true;
            ChangeAnimeState(NPCAttack);
            yield return new WaitForSeconds(0.3F);
            atkObj.transform.localScale = new Vector3(1, 1, 0);
            yield return new WaitForSeconds(0.08F);

            atkObj.transform.localScale = new Vector3(0, 0, 0);
            yield return new WaitForSeconds(0.1F);
            ChangeAnimeState(NPCIdle);
            IsAttack = false;

        }
    }
    IEnumerator Dash()
    {
        if (!IsDash && !IsAttack && !IsWalk)
        {
            IsDash = true;
            ChangeAnimeState(NPCMove);
            yield return new WaitForSeconds(0.6F);
            IsDash = false;


            if (!IsAttack)
            {
                ChangeAnimeState(NPCIdle);
                
            }
        }


    }

    public void WWalk()
    {
        if (IsWalk && !IsAttack)
        {
            print("MKM");
            m_Trans.transform.position = Vector3.MoveTowards(m_Trans.position,ntr.transform.position,0.05F);
        }
    }
    IEnumerator Walk()
    {

        if (ntr.transform.position.x > gameObject.transform.position.x && !IsAttack)
        {
            if (!IsDash && !IsAttack && !IsWalk)
            {
                print("LLL");
                m_Trans.localScale = new Vector3(-mScale.x, mScale.y, 0);
                ChangeAnimeState(NPCWalk);
 
                yield return new WaitForSeconds(0.6F);
                IsWalk = true;

   
   
                yield return new WaitForSeconds(0.2F);
                print("0.2");
                IsWalk = false;
                if (!IsAttack)
                {
                    ChangeAnimeState(NPCIdle);
                }
                
            }
        }
        else
        {
            if (!IsDash && !IsAttack && !IsWalk)
            {
                print("LLL");
                m_Trans.localScale = new Vector3(mScale.x, mScale.y, 0);
                ChangeAnimeState(NPCWalk);
                IsWalk = true;
                yield return new WaitForSeconds(0.7F);

                print("0.7");


                yield return new WaitForSeconds(0.2F);
                print("0.2");
                IsWalk = false;
                if (!IsAttack)
                {
                    ChangeAnimeState(NPCIdle);
                }
            }
        }

        yield return null;
    }

    public void Dashhing()
    {
        if (ntr.transform.position.x > gameObject.transform.position.x && !IsAttack)
        {
            if (!IsDash && !IsAttack && !IsWalk)
            {
                m_rigi2D.AddForce(Vector2.right*c_speed);
                m_rigi2D.AddForce(Vector2.up*c_jump);
            }
            StartCoroutine("Dash");
            m_Trans.localScale = new Vector3(-mScale.x, mScale.y, 0);
   
 

            

        }
        else  
        {     
            if (!IsDash && !IsAttack && !IsWalk && !IsAttack)
            {
                m_rigi2D.AddForce(Vector2.left*c_speed);
                m_rigi2D.AddForce(Vector2.up*c_jump);
            }
            StartCoroutine("Dash");
            m_Trans.localScale = new Vector3(mScale.x, mScale.y, 0);



        }

    }
    public void Movving()
    {

        WWalk();
        float ran = Random.Range(1, 6);
        if (ran == 1 && Dashrange.Tri && !ATKrange.Tri && !Stoprange.Tri)
        {
            StartCoroutine("Walk");
        }
        else if(ran==2 && !Dashrange.Tri && !Stoprange.Tri)
        {
            Dashhing();
        }
        else if(ATKrange.Tri)
        {
            StartCoroutine("Attack");
        }

        if (gameObject.transform.localScale.x>0)
        {
            NPCHPBar.GetComponent<RectTransform>().localScale = new Vector3(HPScale.x, HPScale.y, 0);
        }
        else
        {
            NPCHPBar.GetComponent<RectTransform>().localScale = new Vector3(-HPScale.x, HPScale.y, 0);

        }
    }
    
    // public void Axit()
    // {
    //
    //
    // }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Ground"))
        {
            IsGround = true;
        }


    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ground"))
        {
            IsGround = true;
        }
        if (gameObject.CompareTag("NPC") && other.CompareTag("NtrAttack"))
        {
            float ran = Random.Range(0, 11);
            TakeDamage(20+ran);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Ground"))
        {
            IsGround = false;
        }
    }

    public void TakeDamage(float DMG)
    {
        StartCoroutine("Damage");
        HP -=DMG;
        if (HP<0)
        {
            HP = 0;
        }
        HPText.text = MaxHP + "/" + HP;
        HPbar.setHp(HP);
        GameObject DMGT = Instantiate(DMGText, DMGPos.position, quaternion.identity);
        DMGT.GetComponent<TextMesh>().text = DMG.ToString();
        if (transform.localScale.x>0 && !IsDie)
        {

            gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right*150);
            gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up*50);
        }
        else
        {

            gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.left*150);
            gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up*50);

        }

    }

    IEnumerator Die()
    {
        ChangeAnimeState(NPCDie);
        IsDie = true;

        if (!IsDie)
        {

            if (transform.localScale.x>0 )
            {

                gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right*200);
                gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up*100);
            }
            else
            {

                gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.left*200);
                gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up*100);

            }
            
        }
 


        yield break;
    }

    IEnumerator Damage()
    {
        IsDamage = true;
        yield return new WaitForSeconds(0.8F);
        IsDamage = false;
        yield break;
    }
}