using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[Serializable]
public class InvItem
{
    public InvItemData data { get; private set; }
    public int stackSize { get; private set; }

    public InvItem(InvItemData src)
    {
        data = src;
        AddToStack();
    }
    public void AddToStack()
    {
        stackSize++;
    }
    public void RemoveFromStack()
    {
        stackSize--;
    }
    public void RemoveMulti(int num)
    {
        stackSize -= num;
    }
}

[Serializable]
public class InventorySystem : MonoBehaviour
{
    public static InventorySystem current;
    private Dictionary<InvItemData, InvItem> m_itemDictionary;
    public List<InvItem> Inventory { get; private set; }
    // Start is called before the first frame update
    private void Awake()
    {
        current = this;
        Inventory = new List<InvItem>();
        m_itemDictionary = new Dictionary<InvItemData, InvItem>();
    }

    public InvItem Get(InvItemData referenceData)
    {
        if(m_itemDictionary.TryGetValue(referenceData, out InvItem value))
        {
            return value;
        }
        return null;
    }

    public void Add(InvItemData referenceData)
    {
        if(m_itemDictionary.TryGetValue(referenceData, out InvItem value))
        {
            value.AddToStack();
        }
        else
        {
            InvItem newItem = new InvItem(referenceData);
            Inventory.Add(newItem);
            m_itemDictionary.Add(referenceData, newItem);
        }
        Debug.Log(Inventory);
        current.InventoryChangedEvent();
    }
    public void Remove(InvItemData referenceData, int count)
    {
        if (m_itemDictionary.TryGetValue(referenceData, out InvItem value))
        {
            if (count == 1)
                value.RemoveFromStack();
            else
                value.RemoveMulti(count);

            if(value.stackSize == 0)
            {
                Inventory.Remove(value);
                m_itemDictionary.Remove(referenceData);
            }
        }
        current.InventoryChangedEvent();
    }
    public event Action onInventoryChangedEvent;
    public void InventoryChangedEvent()
    {
        onInventoryChangedEvent?.Invoke();
    }
}
