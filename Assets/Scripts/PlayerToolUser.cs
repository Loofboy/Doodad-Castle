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
    public ToolBarScript toolbar;
    public string currenttoolid = "none";
    public Animator playerAnim;
    // Start is called before the first frame update
    void Start()
    {
        toolpos = gameObject.transform.GetChild(0).GetChild(1).GetChild(1).GetChild(0).GetChild(0).gameObject;
        playerAnim = transform.GetChild(0).GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
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
    }
    public void compareTool(GameObject prefab, string toolid)
    {
        if (currenttoolid == toolid)
        {
            Object.Destroy(toolpos.transform.GetChild(0).gameObject);
            currenttoolid = "none";
            playerAnim.SetBool("IsHoldingTool", false);
            toolbar.DeselectAll();
            JSAM.AudioManager.PlaySound(SoundLibrarySounds.click);
        }
        else
        {
            if (currenttoolid != "none")
                Object.Destroy(toolpos.transform.GetChild(0).gameObject);
            currenttoolid = toolid;
            currenttool = Instantiate(prefab, toolpos.transform);
            currenttool.transform.SetParent(toolpos.transform);
            playerAnim.SetBool("IsHoldingTool", true);
            toolbar.SetToolSlot(currenttoolid);
            JSAM.AudioManager.PlaySound(SoundLibrarySounds.click);
        }
    }
    public void useTool()
    {
        playerAnim.SetTrigger("UseTool");
        JSAM.AudioManager.PlaySound(SoundLibrarySounds.woosh, transform);
    }
    public void CreateToolCollision()
    {
        Vector3 pos = new Vector3(transform.position.x + 1.8f, transform.position.y, transform.position.z);
        if (mov.flipped == true) pos.x = pos.x -3.6f;
        var hb = Instantiate(HitboxPrefab, pos, Quaternion.identity);
        hb.transform.SetParent(GameObject.Find("Player").transform);
    }

    public void DeleteToolCollision()
    {
        var hb = GameObject.Find("toolhitbox(Clone)");
        Object.Destroy(hb);
    }
}
