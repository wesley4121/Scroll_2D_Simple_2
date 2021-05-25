using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class NTRMove : MonoBehaviour
{
  [Range(0,1)]  public float speed;
  public bool IsAttack;
  public Rigidbody2D m_rigi2D;
    public Transform m_Trans;
    // Start is called before the first frame update
    void Start()
    {
        m_rigi2D = gameObject.GetComponent<Rigidbody2D>();
        m_Trans = gameObject.GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Nmove()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            m_rigi2D.AddForce(Vector2.right*speed);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            m_rigi2D.AddForce(Vector2.left*speed);
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            
        }

        yield return null;
    }

    public void Move()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            m_Trans.Translate(Vector3.right*speed);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            m_Trans.Translate(Vector3.left*speed);
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            
        }
    }
}
