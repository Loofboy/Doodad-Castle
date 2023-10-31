using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{

    public GameObject Player;
    private Vector3 newpos;


    // Update is called once per frame
    void Update()
    {
        newpos = new Vector3(Player.transform.position.x, Player.transform.position.y + 4.4f, Player.transform.position.z - 12f);
        gameObject.transform.position = newpos;
    }
}
