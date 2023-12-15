using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CharSlotHandler : MonoBehaviour
{
    //public Image icon;
    public int CharID;
    public GameObject prefab;

    public GameObject NPCHolderprefab;

    //public GameObject iconObj;
    public TextMeshProUGUI CharName;
    public TextMeshProUGUI CharDesc;

    public Button bt;

    public SummonUIMan SUI;
   
    // Start is called before the first frame update
    public void setDesc()
    {
        switch (CharID)
        {
            case 1:
                CharName.text = "Soda";
                CharDesc.text = "Chops rocks faster, wood slower";
                break;
            case 2:
                CharName.text = "Maple Leaf";
                CharDesc.text = "Is much weaker, but moves and jumps better";
                break;
            case 3:
                CharName.text = "Water Bottle";
                CharDesc.text = "Cool Description";
                break;
            case 4:
                CharName.text = "Torch";
                CharDesc.text = "Cool Description";
                break;
            case 5:
                CharName.text = "Lemon";
                CharDesc.text = "Cool Description";
                break;
            case 6:
                CharName.text = "Marker";
                CharDesc.text = "Cool Description";
                break;
            case 7:
                CharName.text = "Snowflake";
                CharDesc.text = "Cool Description";
                break;
            case 8:
                CharName.text = "Soccer ball";
                CharDesc.text = "Cool Description";
                break;
            case 9:
                CharName.text = "Rucksack";
                CharDesc.text = "Cool Description";
                break;
            case 10:
                CharName.text = "Magnifying glass";
                CharDesc.text = "Cool Description";
                break;
            case 11:
                CharName.text = "Trash can";
                CharDesc.text = "Cool Description";
                break;
            case 12:
                CharName.text = "Tower";
                CharDesc.text = "Cool Description";
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
            JSAM.AudioManager.PlaySound(SoundLibrarySounds.click);
            Vector3 pos = new Vector3(20, 120, 200);
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
