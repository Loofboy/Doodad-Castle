using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvUIMan : MonoBehaviour
{
    public GameObject m_slotPrefab;
    public Animator Invanim;
    bool invstate = false;
    // Start is called before the first frame update
    public void Start()
    {
        InventorySystem.current.onInventoryChangedEvent += OnUpdateInventory;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if(invstate == false)
            {
                JSAM.AudioManager.PlaySound(SoundLibrarySounds.click);
                Invanim.SetBool("InventoryOn", true);
                invstate = true;
            }
            else
            {
                JSAM.AudioManager.PlaySound(SoundLibrarySounds.click);
                Invanim.SetBool("InventoryOn", false);
                invstate = false;
            }
        }   
    }

    private void OnUpdateInventory()
    {
        foreach(Transform t in transform)
        {
            Destroy(t.gameObject);
        }

        DrawInventory();
    }

    public void DrawInventory()
    {

        foreach(InvItem item in InventorySystem.current.Inventory)
        {
            AddInventorySlot(item);
        }
    }

    public void AddInventorySlot(InvItem item)
    {
        GameObject obj = Instantiate(m_slotPrefab);
        obj.transform.SetParent(transform, false);

        SlotScript slot = obj.GetComponent<SlotScript>();
        slot.Set(item);
    }
}

