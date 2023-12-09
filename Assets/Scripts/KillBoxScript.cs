using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillBoxScript : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == 8)
        {
            collision.gameObject.GetComponent<PlayerController>().KillPlayer();
        }
    }
}
