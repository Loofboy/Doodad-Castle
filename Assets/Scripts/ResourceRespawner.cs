using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceRespawner : MonoBehaviour
{
    public float RespawnTimer = 30f;
    //private float timeNow;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    public void BeginRespawn(GameObject obj, bool isenemy)
    {
        StartCoroutine(StartTimer(obj, isenemy));
    }
    public IEnumerator StartTimer(GameObject obj, bool isenemy)
    {
        yield return new WaitForSeconds(RespawnTimer);
        obj.SetActive(true);
        obj.GetComponent<ResourceObject>().HP = obj.GetComponent<ResourceObject>().referenceResource.resourceHealth;
        if (isenemy)
        {
            gameObject.GetComponent<Rigidbody>().isKinematic = false;
            gameObject.GetComponent<BoxCollider>().enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
