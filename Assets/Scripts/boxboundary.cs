using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxboundary : MonoBehaviour
{
    public bool EnteredTrigger = false;
    public GameObject BoxUIobj;

    public DepositSystem DepSys;
    public InventorySystem InvSys;
    public Animator Chestanims;

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 8)
        {
            EnteredTrigger = true;
            Debug.Log("INBOUNDARY");
            BoxUIobj.SetActive(true);
            Chestanims.SetBool("IsOpen", true);
            BoxUIobj.GetComponentInChildren<DepositUIMan>().DrawDeposit();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 8)
        {
            EnteredTrigger = false;
            Debug.Log("OUTBOUNDARY");
            BoxUIobj.SetActive(false);
            Chestanims.SetBool("IsOpen", false);
            foreach (Transform child in BoxUIobj.transform.GetChild(0).transform)
            {
                GameObject.Destroy(child.gameObject);
            }
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && EnteredTrigger)
        {
            foreach(InvItem invitem in InvSys.Inventory)
            {
                foreach(BoxItem reqitem in DepSys.currentItemList)
                {
                    if(reqitem.data == invitem.data)
                    {
                        if(reqitem.stackSize >= invitem.stackSize)
                        {
                            DepSys.AnimateDeposit(invitem.prefab.GetComponentInChildren<SpriteRenderer>().sprite, invitem.stackSize);
                            DepSys.Remove(reqitem.data, invitem.stackSize);
                            InvSys.Remove(invitem.data, invitem.stackSize);
                        }
                        else
                        {
                            DepSys.AnimateDeposit(invitem.prefab.GetComponentInChildren<SpriteRenderer>().sprite, reqitem.stackSize);
                            InvSys.Remove(invitem.data, reqitem.stackSize);
                            DepSys.Remove(reqitem.data, reqitem.stackSize);  
                        }
                        return;
                    }
                }
            }

        }
    }
}
