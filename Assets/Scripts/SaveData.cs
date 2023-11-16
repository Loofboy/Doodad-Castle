using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class SaveData
{
    public float Health;
    public Vector3 PlayerPosition;
    public int SummonCount;
    public string CurrentCharacterId;
    public List<string> SummonedCharacterIds;
    public int CurrentMissionID;
    public List<BoxItem> CurrentItemList;

    public List<InvItem> Inventory;
    public Dictionary<InvItemData, InvItem> m_itemDictionary;
    
}
