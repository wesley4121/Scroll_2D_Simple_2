using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DropSperm : MonoBehaviour
{
    public bool tri = false;
  [Range(0,10)]  public float timeD; 
  [Range(0,10)]  public float Split;
    public GameObject Sperm;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        StartCoroutine("DupeSPerm");
    }

    public void DDD()
    {
        print("OK");
        Instantiate(Sperm, transform.position, Quaternion.identity);

    }

    private void OnEnable()
    {

        tri = false;
    }

    public void ddd()
    {

    }
    IEnumerator DupeSPerm()
    {
        
        

        if (!tri)
        {

            var ranel = Quaternion.Euler(0, 0, Random.Range(0, 360));
            tri = true;
            print("OK");
            yield return new WaitForSeconds(timeD);
            GameObject clone = Instantiate(Sperm, transform.position, ranel);
            clone.GetComponent<Rigidbody2D>().AddForce(Vector2.right*Split);
            tri = false;
            print("OOK");

        }



    }
}
