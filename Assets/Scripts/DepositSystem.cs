using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class BoxItem
{
    public InvItemData data;

    public GameObject prefab;
    public string id;

    public int stackSize;

    public BoxItem(InvItemData src, int num)
    {
        data = src;
        prefab = data.prefab;
        id = data.id;
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
    public CastleScript castle;

    public GameObject AnimatedObjectPrefab;
    public float speed = 1f;
    private float timespentmult = 1;

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

    public void AddByPrefab(GameObject prefab, int count)
    {
        Add(prefab.transform.GetChild(0).gameObject.GetComponent<ItemObject>().referenceItem, count);
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
                        castle.GrowCastle(currentMissionIndex);
                        SetMission(currentMissionIndex);
                        SUI.SummonCount++;
                        SUI.Counter.text = "Summons: " + SUI.SummonCount;
                    }
                    current.DepositChangedEvent();
                    return;
                }
            }
    }
    public void AnimateDeposit(Sprite icon, int count)
    {
        timespentmult = 1;
        //StopAllCoroutines();
        Debug.Log(icon + "    " + count);
        StartCoroutine(SpawnFellas(icon, count));
    }
    public IEnumerator SpawnFellas(Sprite icon, int count)
    {
        for (int i = 0; i < count; i++)
        {
            yield return new WaitForSeconds(0.35f * timespentmult);
            float rannum = UnityEngine.Random.Range(-2f, 2f);
            Vector3 pos = new Vector3(transform.position.x + rannum, transform.position.y + 2f, transform.position.z);
            GameObject obj = Instantiate(AnimatedObjectPrefab, pos, Quaternion.identity);
            obj.transform.SetParent(transform);
            obj.GetComponent<SpriteRenderer>().sprite = icon;
            obj.GetComponent<SpriteRenderer>().size = new Vector2(1, 1);
            obj.GetComponent<MoveItem>().speed = speed;
            obj.GetComponent<MoveItem>().target = transform;
            if (timespentmult != 0.1f)
                timespentmult -= 0.1f; 

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
