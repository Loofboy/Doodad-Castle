using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SlotScript : MonoBehaviour
{
    [SerializeField]
    private Image m_icon;

    [SerializeField]
    private TextMeshProUGUI m_label;

    [SerializeField]
    private GameObject m_stackObj;

    [SerializeField]
    private TextMeshProUGUI m_stackLabel;

    public void Set(InvItem item)
    {
        m_icon.sprite = item.data.icon;
        //m_label.text = item.data.displayName;
        if(item.stackSize <= 1)
        {
            m_stackObj.SetActive(false);
            return;
        }
        m_stackLabel.text = item.stackSize.ToString();
    }

    public void BoxSet(BoxItem item)
    {
        m_icon.sprite = item.data.icon;
        //m_label.text = item.data.displayName;
        if (item.stackSize <= 1)
        {
            m_stackObj.SetActive(false);
            return;
        }
        m_stackLabel.text = item.stackSize.ToString();
    }
}
