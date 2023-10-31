using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    public InvItemData referenceItem;

    public void OnPickupItem()
    {
        InventorySystem.current.Add(referenceItem);
        Destroy(transform.parent.gameObject);
    }
}
