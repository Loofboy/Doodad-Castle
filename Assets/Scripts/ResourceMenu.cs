using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceMenu : MonoBehaviour
{
    public NPCController assignedNPC;
    // Start is called before the first frame update
    public void CloseMenu()
    {
        assignedNPC = null;
        this.gameObject.SetActive(false);
    }

    public void SetObject(GameObject obj)
    {
        if (assignedNPC == null) return;
        assignedNPC.assignedResource = obj;
    }
}
