using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharAnimEvents : MonoBehaviour
{
    public GameObject parentChar;
    private PlayerToolUser ptu;
    //private NPCToolUser ntu;
    void Start()
    {
        if (parentChar.GetComponent<PlayerToolUser>() != null)
            ptu = parentChar.GetComponent<PlayerToolUser>();
       // if (parentChar.GetComponent<NPCToolUser>() != null)
       //     ntu = parentChar.GetComponent<NPCToolUser>();
    }

    public void Createhitbox()
    {
        ptu.CreateToolCollision();
    }

    public void Deletehitbox()
    {
        ptu.DeleteToolCollision();
    }
}
