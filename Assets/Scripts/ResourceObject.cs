using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceObject : MonoBehaviour
{
    public ResourceData referenceResource;
    ToolObject tool;
    public int HP;
    Animator resAnim;

    private void Start()
    {
        HP = referenceResource.resourceHealth;
        resAnim = GetComponent<Animator>();
    }
    public void decreaseHP(int toolDamage)
    {
        HP -= toolDamage;
        resAnim.SetTrigger("Hit");
        if(HP <= 0)
        {
            OnDestroyResource();
        }
    }
    public void OnDestroyResource()
    {
        for(int i = 0; i < referenceResource.dropCount; i++)
        {
            Vector3 pos = new Vector3(transform.position.x, transform.position.y+i*2, transform.position.z);
            Instantiate(referenceResource.dropPrefab, pos, Quaternion.identity);
        }
        Object.Destroy(transform.parent.gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 9 || other.gameObject.layer == 11)
        {
            Debug.Log("Hit " + this.gameObject.name);
            tool = other.transform.parent.GetChild(0).GetChild(1).GetChild(1).GetChild(0).GetChild(0).GetChild(0).gameObject.GetComponent<ToolObject>();
            if(tool.wpntype == referenceResource.allowedwpntype)
            {
                decreaseHP(tool.damage);
                Object.Destroy(other.gameObject);
            }
        }
    }
}
