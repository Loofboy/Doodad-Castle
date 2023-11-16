using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CharSlotHandler : MonoBehaviour
{
    public Image icon;
    public int CharID;
    public GameObject prefab;

    public GameObject NPCHolderprefab;

    public GameObject iconObj;
    public TextMeshProUGUI CharName;
    public TextMeshProUGUI CharDesc;

    public Button bt;

    public SummonUIMan SUI;
   
    // Start is called before the first frame update
    public void setDesc()
    {
        switch (CharID)
        {
            case 0:
                CharName.text = "Soda";
                CharDesc.text = "Chops rocks faster, wood slower";
                break;
            case 1:
                CharName.text = "Water bottle";
                CharDesc.text = "Chops rocks faster, wood slower";
                break;
            case 2:
                CharName.text = "Maple leaf";
                CharDesc.text = "Chops rocks faster, wood slower";
                break;
            case 3:
                CharName.text = "Torch";
                CharDesc.text = "Chops rocks faster, wood slower";
                break;
            case 4:
                CharName.text = "Lemon";
                CharDesc.text = "Chops rocks faster, wood slower";
                break;
            case 5:
                CharName.text = "Marker";
                CharDesc.text = "Chops rocks faster, wood slower";
                break;
            case 6:
                CharName.text = "Snowflake";
                CharDesc.text = "Chops rocks faster, wood slower";
                break;
            case 7:
                CharName.text = "Soccer ball";
                CharDesc.text = "Chops rocks faster, wood slower";
                break;
            case 8:
                CharName.text = "Rucksack";
                CharDesc.text = "Chops rocks faster, wood slower";
                break;
            case 9:
                CharName.text = "Magnifying glass";
                CharDesc.text = "Chops rocks faster, wood slower";
                break;
            case 10:
                CharName.text = "Trash can";
                CharDesc.text = "Chops rocks faster, wood slower";
                break;
            case 11:
                CharName.text = "Tower";
                CharDesc.text = "Chops rocks faster, wood slower";
                break;
        }
    }
    public void ClearDesc()
    {
        CharName.text = "";
        CharDesc.text = "";
    }

    public void SummonChar()
    {
        if(SUI.SummonCount > 0)
        {
            Vector3 pos = new Vector3(0, 10, 0);
            var parent = Instantiate(NPCHolderprefab, pos, Quaternion.identity);
            var child = Instantiate(prefab, pos, Quaternion.identity);
            child.transform.SetParent(parent.transform);
            bt.interactable = false;
            SUI.toswitch = parent;
        }
    }

    public void Addtolist(){
        if(SUI.SummonCount > 0)
        {
            SUI.SummonCount--;
            SUI.Counter.text = "Summons: " + SUI.SummonCount;
            SUI.Summonedcharacters.Add(CharID.ToString());
        }
    }


    void Start()
    {
        bt = GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
