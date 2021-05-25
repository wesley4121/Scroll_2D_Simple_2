using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM : MonoBehaviour
{
    // Start is called before the first frame update
    public int EventIndex;
    public GameObject SCCanvas,WSCanvas,OLCanvas;
    public Texture2D m_Cursor; 
    public Texture2D m_CursorOnButton;
    public Texture2D m_CursorPress;
    public BoolManage BoolMG;
    public CutScene cutscene;
    public TextAsset[] TextFileS;
    public GameObject textlabel;
    private NTRAniManager Player;
    private NPC1 npc1;
    void Start()
    {
        cutscene = gameObject.GetComponent<CutScene>();
        npc1 = GameObject.Find("NPC1").GetComponent<NPC1>();
        Player = GameObject.FindWithTag("Player").GetComponent<NTRAniManager>();
        BoolMG = gameObject.GetComponent<BoolManage>();
        Cursor.SetCursor(m_Cursor,Vector2.zero, CursorMode.ForceSoftware);

    }

    // Update is called once per frame
    void Update()
    {
        if (!BoolMG.IsEvent&&!BoolMG.IsStart&&!BoolMG.IsLoad&&!BoolMG.IsPause)
        {
            DisableCanvas(SCCanvas,false);
        }
        else
        {
            DisableCanvas(SCCanvas,true);

        }
        if (Input.GetMouseButton(0))
        {

            Cursor.SetCursor(m_CursorPress,Vector2.zero, CursorMode.ForceSoftware);
        }    
        if (Input.GetMouseButtonUp(0))
        {

            Cursor.SetCursor(m_Cursor,Vector2.zero, CursorMode.ForceSoftware);
        }

        if (Player.Hp<=0 || npc1.HP <=0)
        {
            textlabel.GetComponent<SaySys>().ChangeTextFile(TextFileS[0]);
            textlabel.SetActive(true);
        }
    }

    public void DisableCanvas(GameObject Canvas , bool var)
    {
        Canvas.SetActive(var);
    }
    
}
