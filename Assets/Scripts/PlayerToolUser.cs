using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerToolUser : MonoBehaviour
{
    public GameObject SwordPrefab;
    public GameObject AxePrefab;
    public GameObject PickPrefab;
    public GameObject HitboxPrefab;
    public GameObject toolpos;
    public GameObject currenttool;
    public PlayerController mov;
    public NPCController nmov;
    public ToolBarScript toolbar;
    public string currenttoolid = "none";
    public Animator playerAnim;
    public bool isPlayer = true;
    private GameObject hb;
    // Start is called before the first frame update
    void Start()
    {
        toolpos = gameObject.transform.GetChild(0).GetChild(1).GetChild(1).GetChild(0).GetChild(0).gameObject;
        playerAnim = transform.GetChild(0).GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isPlayer) return;

        if (Input.GetKeyDown("1"))
        {
            compareTool(SwordPrefab, "tool_starsword");
        }
        if (Input.GetKeyDown("2"))
        {
            compareTool(AxePrefab, "tool_staraxe");
        }
        if (Input.GetKeyDown("3"))
        {
            compareTool(PickPrefab, "tool_starpick");
        }
        if(Input.GetKeyDown(KeyCode.E) && currenttoolid != "none")
        {
            useTool();
        }
        //toolpos = gameObject.transform.GetChild(0).GetChild(1).GetChild(1).GetChild(0).GetChild(0).gameObject;
        //playerAnim = transform.GetChild(0).GetComponent<Animator>();
    }
    public void compareTool(GameObject prefab, string toolid)
    {
        toolpos = gameObject.transform.GetChild(0).GetChild(1).GetChild(1).GetChild(0).GetChild(0).gameObject;
        playerAnim = transform.GetChild(0).GetComponent<Animator>();
        if (currenttoolid == toolid)
        {
            if(isPlayer){
            Object.Destroy(toolpos.transform.GetChild(0).gameObject);
            currenttoolid = "none";
            playerAnim.SetBool("IsHoldingTool", false);
            toolbar.DeselectAll();
            JSAM.AudioManager.PlaySound(SoundLibrarySounds.click);
            }
        }
        else
        {
            if (currenttoolid != "none")
                Object.Destroy(toolpos.transform.GetChild(0).gameObject);
            currenttoolid = toolid;
            currenttool = Instantiate(prefab, toolpos.transform);
            currenttool.GetComponent<ToolObject>().owner = gameObject;
            currenttool.transform.SetParent(toolpos.transform);
            playerAnim.SetBool("IsHoldingTool", true);
            if(isPlayer){
            toolbar.SetToolSlot(currenttoolid);
            JSAM.AudioManager.PlaySound(SoundLibrarySounds.click);
            }
        }
    }
    public void UnEquipTool(){
        Object.Destroy(toolpos.transform.GetChild(0).gameObject);
        currenttoolid = "none";
        playerAnim.SetBool("IsHoldingTool", false);
    }
    public void useTool()
    {
        playerAnim.SetTrigger("UseTool");
        JSAM.AudioManager.PlaySound(SoundLibrarySounds.woosh, transform);
    }
    public void CreateToolCollision()
    {
        Vector3 pos = new Vector3(transform.position.x + 1.8f, transform.position.y, transform.position.z);
        if (isPlayer && mov.flipped == true) pos.x = pos.x -3.6f;
        else if (!isPlayer && nmov.flipped == true) pos.x = pos.x -3.6f;
        hb = Instantiate(HitboxPrefab, pos, Quaternion.identity);
        hb.transform.SetParent(transform);
        if(!isPlayer) hb.transform.localScale *= 6;
    }

    public void DeleteToolCollision()
    {
        Object.Destroy(hb);
    }
}
