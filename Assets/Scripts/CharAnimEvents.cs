using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharAnimEvents : MonoBehaviour
{
    public CharacterData chardat;
    public GameObject parentChar;
    private PlayerToolUser ptu;

    Animator anim;
    //private NPCToolUser ntu;
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
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
    public void PlayInteractAnim(bool bickering = false)
    {
        if (bickering)
        {
            anim.SetBool("IsBickering", true);
            StartCoroutine(StopAnim());
        }
        else
        {
            anim.SetBool("IsChatting", true);
            StartCoroutine(StopAnim());
        }

    }
    IEnumerator StopAnim()
    {
        yield return new WaitForSeconds(10f);
        anim.SetBool("IsBickering", false);
        anim.SetBool("IsChatting", false);
    }
}
