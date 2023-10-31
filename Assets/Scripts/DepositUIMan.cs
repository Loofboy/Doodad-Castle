using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepositUIMan : MonoBehaviour
{
    public GameObject m_slotPrefab;
    // Start is called before the first frame update
    public void Start()
    {
        DepositSystem.current.onDepositChangedEvent += OnUpdateDeposit;
    }

    private void OnUpdateDeposit()
    {
        foreach (Transform t in transform)
        {
            Destroy(t.gameObject);
        }

        DrawDeposit();
    }

    public void DrawDeposit()
    {
        foreach (BoxItem item in DepositSystem.current.currentItemList)
        {
            Debug.Log(item);
            AddDepositSlot(item);
        }
    }

    public void AddDepositSlot(BoxItem item)
    {
        GameObject obj = Instantiate(m_slotPrefab);
        obj.transform.SetParent(transform, false);

        SlotScript slot = obj.GetComponent<SlotScript>();
        slot.BoxSet(item);
    }
}

