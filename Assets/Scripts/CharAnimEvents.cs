using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharAnimEvents : MonoBehaviour
{
    public CharacterData chardat;
    public GameObject parentChar;
    private PlayerToolUser ptu;
    //private NPCToolUser ntu;
    void Start()
    {
        parentChar = this.gameObject.transform.parent.gameObject;
       // if (parentChar.GetComponent<NPCToolUser>() != null)
       //     ntu = parentChar.GetComponent<NPCToolUser>();
    }

    public void Createhitbox()
    {
        if (parentChar.GetComponent<PlayerToolUser>() != null)
            ptu = parentChar.GetComponent<PlayerToolUser>();
        ptu.CreateToolCollision();
    }

    public void Deletehitbox()
    {
        if (parentChar.GetComponent<PlayerToolUser>() != null)
            ptu = parentChar.GetComponent<PlayerToolUser>();
        ptu.DeleteToolCollision();
    }

    public void PlayWalkSound()
    {
        JSAM.AudioManager.PlaySound(SoundLibrarySounds.step, transform);
    }
}
