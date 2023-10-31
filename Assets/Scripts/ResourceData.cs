using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Resource Data")]
public class ResourceData : ScriptableObject
{
    public string id;
    public string allowedwpntype;
    public GameObject dropPrefab;
    public int resourceHealth;
    public int dropCount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
