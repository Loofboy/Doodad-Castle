using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Character Data")]
[System.Serializable]
public class CharacterData : ScriptableObject
{
    public string charnum;
    public string displayName;
    public float HealthModifier;
    public float SpeedBuff;
    public float JumpBuff;
    public float SwordBuff;
    public float AxeBuff;
    public float PickBuff;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
