using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolBarScript : MonoBehaviour
{
    public List<Animator> sloticons;

    public void SetToolSlot(string currenttoolid)
    {
        switch (currenttoolid)
        {
            case "tool_starsword":
                    AnimateSlot(0);
                    break;
            case "tool_staraxe":
                    AnimateSlot(1);
                    break;
            case "tool_starpick":
                    AnimateSlot(2);
                    break;
        }
    }

    public void AnimateSlot(int index)
    {
        DeselectAll();
        sloticons[index].SetBool("isSelected", true);
    }

    public void DeselectAll()
    {
        sloticons[0].SetBool("isSelected", false);
        sloticons[1].SetBool("isSelected", false);
        sloticons[2].SetBool("isSelected", false);
    }
}
