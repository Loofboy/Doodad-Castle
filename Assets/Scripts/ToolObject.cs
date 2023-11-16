using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolObject : MonoBehaviour
{
    //private defaultdamage = 3;
    public GameObject player;
    public ToolData referenceTool;
    public string id;
    public string wpntype;
    public float damage;
    // Start is called before the first frame update
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Play");
        //Debug.Log(player);
        id = referenceTool.id;
        wpntype = referenceTool.wpnType;
        damage = referenceTool.damage;
        if(wpntype == "axe"){
            damage = damage + player.transform.GetChild(0).GetComponent<CharAnimEvents>().chardat.AxeBuff;
        }
        if(wpntype == "sword"){
            damage = damage + player.transform.GetChild(0).GetComponent<CharAnimEvents>().chardat.SwordBuff;
        }
        if(wpntype == "pick"){
            damage = damage + player.transform.GetChild(0).GetComponent<CharAnimEvents>().chardat.PickBuff;
        }
    }
}
