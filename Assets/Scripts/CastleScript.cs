using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleScript : MonoBehaviour
{
    public List<GameObject> CastleList;

    public void GrowCastle(int index)
    {
        Destroy(transform.GetChild(0).gameObject);
        var obj = Instantiate(CastleList[index-1], transform.position, transform.rotation);
        obj.transform.localScale *= 2;
        obj.transform.SetParent(transform);
    }
}
