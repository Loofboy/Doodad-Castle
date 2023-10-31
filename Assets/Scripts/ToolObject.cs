using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolObject : MonoBehaviour
{
    public ToolData referenceTool;
    public string id;
    public string wpntype;
    public int damage;
    // Start is called before the first frame update
    private void Start()
    {
        id = referenceTool.id;
        wpntype = referenceTool.wpnType;
        damage = referenceTool.damage;
    }
}
