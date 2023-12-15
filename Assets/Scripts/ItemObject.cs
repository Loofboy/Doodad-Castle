using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    public InvItemData referenceItem;

    public void OnPickupItem()
    {
        JSAM.AudioManager.PlaySound(SoundLibrarySounds.pop, transform);
        InventorySystem.current.Add(referenceItem);
        Destroy(transform.parent.gameObject);
    }
}
