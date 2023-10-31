using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SummonUIMan : MonoBehaviour
{

    public Animator anim;
    public int SummonCount;
    public TextMeshProUGUI Counter;
    private bool state = false;
    // Start is called before the first frame update
    void Start()
    {
        SummonCount = 0;
        Counter.text = "Summons: 0";
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
