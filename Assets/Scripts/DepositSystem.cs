using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class BoxItem
{
    public InvItemData data;
    public int stackSize;

    public BoxItem(InvItemData src, int num)
    {
        data = src;
        stackSize = num;
    }
    public void AddToStack(int count)
    {
        stackSize += count;
    }
    public void RemoveFromStack(int count)
    {
        stackSize -= count;
    }
}

[Serializable]
public class DepositSystem : MonoBehaviour
{
    public static DepositSystem current;
    public int currentMissionIndex;
    public List<BoxItem> currentItemList;
    public SummonUIMan SUI;


    [Serializable]
    public class Item
    {
        public GameObject itemPrefab;
        public int itemCount;
    }

    [Serializable]
    public class DepositInfo
    {
        //public int numberOfItemSlots;
        public List<Item> items;
    }


    [SerializeField] public DepositInfo[] depositInfoArray;

    public void SetMission(int CMI)
    {
        for(int i = 0; i < depositInfoArray[CMI].items.Count; i++)
        {
            BoxItem itemObject = new BoxItem(depositInfoArray[CMI].items[i].itemPrefab.GetComponentInChildren<ItemObject>().referenceItem, depositInfoArray[CMI].items[i].itemCount);
            currentItemList.Add(itemObject);
        }

    }

    public void Add(InvItemData referenceData, int count)
    {
        foreach (BoxItem item in currentItemList)
            if (item.data == referenceData)
            {
                item.AddToStack(count);
                current.DepositChangedEvent();
            }
    }

    public void Remove(InvItemData referenceData, int count)
    {
        foreach (BoxItem item in currentItemList)
            if (item.data == referenceData)
            {
                item.RemoveFromStack(count);
                current.DepositChangedEvent();
                if (item.stackSize == 0)
                {
                    currentItemList.Remove(item);
                    if(currentItemList.Count == 0)
                    {
                        currentMissionIndex++;
                        SetMission(currentMissionIndex);
                        SUI.SummonCount++;
                        SUI.Counter.text = "Summons: " + SUI.SummonCount;
                    }
                    current.DepositChangedEvent();
                    return;
                }
            }
    }

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(depositInfoArray[0].items.Count);
        current = this;
        currentMissionIndex = 0;
        SetMission(currentMissionIndex);
    }

    // Update is called once per frame

    public event Action onDepositChangedEvent;
    public void DepositChangedEvent()
    {
        onDepositChangedEvent?.Invoke();
    }
}
