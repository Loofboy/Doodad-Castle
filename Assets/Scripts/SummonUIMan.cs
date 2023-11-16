using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SummonUIMan : MonoBehaviour
{

    public Animator anim;
    public int SummonCount;
    public GameObject toswitch;
    public TextMeshProUGUI Counter;
    private bool state = false;
    [SerializeField] public List<string> Summonedcharacters;
    // Start is called before the first frame update
    void Start()
    {
        SummonCount = 0;
        Counter.text = "Summons: 0";
        Summonedcharacters = new List<string>();
    }

    public void Resummon(string curid){
        SummonCount += Summonedcharacters.Count;
        foreach(string i in Summonedcharacters){
            transform.GetChild(0).GetChild(int.Parse(i) - 1).GetComponent<CharSlotHandler>().SummonChar();
            if(i == curid){
                toswitch.GetComponent<NPCController>().SwitchCharacter(true);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (state == false)
            {
                anim.SetBool("SummonOn", true);
                state = true;
            }
            else
            {
                anim.SetBool("SummonOn", false);
                state = false;
            }
        }
    }
}
