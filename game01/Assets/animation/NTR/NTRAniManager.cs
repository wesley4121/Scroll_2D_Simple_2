using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class NTRAniManager : MonoBehaviour
{
  [Range(0,500)]  public float Hp;
  public NTRAniManager instens; 
    public JoyStickMove cJoyStick;
    public BoolManage BoolMG;
    public GameObject n1, n2, n3, n4;
    public GameObject HPBar;
    public GameObject DMGT;
    public AudioSource DamageSFX;
    public TextMeshProUGUI HPText;
    public HPBar NtrHPBar;
    public bool IsDie;

    public Vector3 HPScale;
    public Transform DMGPos;
    public float MaxHP;
    public Vector3 mScale;
   public Vector3 n1SSCale;         
   public Vector3 n2SSCale;      
   public Vector3 n3SSCale;    
   public Vector3 n4SSCale;
   public Vector3 disable;

   private void Awake()
   {
       instens = this;
   }

   void Start()
   {
        NtrHPBar = gameObject.GetComponentInChildren<HPBar>();
        n1SSCale = n1.transform.localScale;    
        n2SSCale = n2.transform.localScale;   
        n3SSCale = n3.transform.localScale;  
        n4SSCale = n4.transform.localScale;
        disable = new Vector3(0, 0, 0);
        mScale = gameObject.transform.localScale;
        n2.transform.localScale = new Vector3(0, 0, 0);
        n3.transform.localScale = new Vector3(0, 0, 0);
        n4.transform.localScale = new Vector3(0, 0, 0);
        HPScale = HPBar.GetComponent<RectTransform>().localScale;
        NtrHPBar.setmaxHp(Hp);
        MaxHP = Hp;
        HPText.text = MaxHP + "/" + MaxHP;
    }

    // Update is called once per frame
    void Update()
    {
        if (BoolMG.IsStart && !BoolMG.IsLoad && !BoolMG.IsPause &&!BoolMG.IsEvent)
        {
            getAxit();

            NTRDie();;
            
        }

    

    }

    private void FixedUpdate()
    {
        
    }
    
    const string Idle ="Base Idle";  
    const string ToWalk ="Base ToWalk";
    const string Walk ="Base Walk";
    const string Attack ="Base Attack";
    const string ToDie ="Base ToDie";
    const string Die ="Base Die";

    public string currenState;
    public void ChangeAnimeState(GameObject ani, string newAni)
    {

        if (currenState== newAni) return;
        
        ani.GetComponent<Animator>().Play(newAni);
        currenState = newAni;

    }

    public void Scaler(GameObject obj,Vector3 scale)
    {
        
        obj.transform.localScale = scale;
    }
    public void getAxit()
    {
        
        if (cJoyStick.Right && !IsDie)
        {
            ChangeAnimeState(n1,Walk);
            Scaler(n1,n1SSCale);
            gameObject.transform.localScale = new Vector3(mScale.x, gameObject.transform.localScale.y, 0);
            HPBar.GetComponent<RectTransform>().localScale = new Vector3(HPScale.x, HPScale.y, 0);

        }       
        if (cJoyStick.Left && !IsDie)
        {
            ChangeAnimeState(n1,Walk);
            Scaler(n1,n1SSCale);
            gameObject.transform.localScale = new Vector3(-mScale.x, gameObject.transform.localScale.y, 0);
            HPBar.GetComponent<RectTransform>().localScale = new Vector3(-HPScale.x, HPScale.y, 0);


        }     
        else if (cJoyStick.Zero && !IsDie)
        {
            ChangeAnimeState(n1,Idle);

        }     
        else if (cJoyStick.Zero && !IsDie)
        {
            ChangeAnimeState(n1,Idle);

        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        float RanFMG = Random.Range(1, 6);

        if (gameObject.CompareTag("Player") && other.CompareTag("NpcAttack"))
        {
            TakeDMG(10 + RanFMG);
        }
    }

    public void TakeDMG(float DMG)
    {
        DamageSFX.Play();
        if (transform.localScale.x<0 && !IsDie)
        {

            gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right*100);
            gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up*50);
        }
        else
        {

            gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.left*100);
            gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up*50);

        }

        GameObject DMGText = Instantiate(DMGT, DMGPos.transform.position, Quaternion.identity);
        DMGText.GetComponent<TextMesh>().text = DMG.ToString();
        Hp -= DMG;
        if (Hp<0)
        {
            Hp = 0;
        }
        HPText.text = MaxHP + "/" + Hp;
        NtrHPBar.setHp(Hp);
    }

    public void NTRDie()
    {

        if (Hp <= 0 && !IsDie) 
        {

            IsDie = true;
            ChangeAnimeState(n1,ToDie);
        }
            
    }
}
