using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DataManager : MonoBehaviour
{
    public SaveData save;

    public GameObject player;
    public InventorySystem inv;
    public Slider Healthbar;
    public TextMeshProUGUI slidertext;
    public DepositSystem depsys;
    public SummonUIMan summon;
    public CastleScript castle;

    private GameObject savobj;
    public Animator Fade;

    void Start(){
        StartCoroutine(RunSave());
    }
    private IEnumerator RunSave(){
        yield return new WaitForSeconds(0.5f);
        savobj = GameObject.FindGameObjectWithTag("SaveDat");
        if(savobj != null)
            {
                //Debug.Log("Got Save OBJ and putting values in now");
                save = savobj.GetComponent<Save>().SaveFile;

                player.GetComponent<PlayerController>().health = save.Health;
                Healthbar.value = save.Health;
                slidertext.text = "Health: " + save.Health; 

                //Vector3 testpos = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
                while(player.transform.position != save.PlayerPosition){
                    player.transform.position = save.PlayerPosition;
                }
                summon.SummonCount = save.SummonCount;
                summon.Counter.text = "Summons: " + summon.SummonCount;
                summon.Summonedcharacters = save.SummonedCharacterIds;
                summon.Resummon(save.CurrentCharacterId);

                inv.Inventory = save.Inventory;
                foreach(InvItem i in inv.Inventory){
                    InvItemData j = i.data;
                    inv.m_itemDictionary.Add(j, i);
                }
                inv.InventoryChangedEvent();

                depsys.currentMissionIndex = save.CurrentMissionID;
                castle.GrowCastle(depsys.currentMissionIndex);
                depsys.currentItemList = save.CurrentItemList;
                depsys.DepositChangedEvent();
            }
            Fade.SetTrigger("Finish");
        StopCoroutine(RunSave());
    }
    public void DelData(){
        if(savobj != null)
        Destroy(savobj);
    }
    // Start is called before the first frame update
    public void SetData(){
        save.SummonCount = summon.SummonCount;
        save.SummonedCharacterIds = summon.Summonedcharacters;
        save.Health = player.GetComponent<PlayerController>().health;
        save.PlayerPosition = player.transform.position;
        //save.CurrentCharacter = player.transform.GetChild(0).gameObject;
        
        save.Inventory = inv.Inventory;
        //save.m_itemDictionary = inv.m_itemDictionary;
        save.CurrentMissionID = depsys.currentMissionIndex;
        save.CurrentItemList = depsys.currentItemList;
        save.CurrentCharacterId = player.transform.GetChild(0).GetComponent<CharAnimEvents>().chardat.charnum;
    }
}
